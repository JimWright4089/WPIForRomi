/*
 * udpserver.c - A simple UDP echo server
 * usage: udpserver <port>
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <memory.h>
#include <winsock2.h>
#include <ws2tcpip.h>

#include "Messages.hpp"

#define BUFSIZE 1024

/*
 * error - wrapper for perror
 */
void error(char *msg) {
    perror(msg);
    exit(1);
}

int main(int argc, char **argv) {
    int sockfd; /* socket */
    int portno; /* port to listen on */
    int clientlen; /* byte size of client's address */
    struct sockaddr_in serveraddr; /* server's addr */
    struct sockaddr_in clientaddr; /* client addr */
    struct sockaddr_in clientSendAddr; /* client addr */
    bool clientIsOpen = false;
    struct hostent *hostp; /* client host info */
    char buf[BUFSIZE]; /* message buf */
    char *hostaddrp; /* dotted decimal host addr string */
    int optval; /* flag value for setsockopt */
    int numberOfBytes; /* message byte size */
    RC_Status_Message* rcMessage = new RC_Status_Message();

    /*
     * check command line arguments
     */
    if (argc != 2) {
        fprintf(stderr, "usage: %s <port>\n", argv[0]);
        exit(1);
    }
    portno = atoi(argv[1]);


    WSADATA wsaData;

    // holds address info for socket to connect to
    struct addrinfo *result = NULL,
        *ptr = NULL,
        hints;

    // Initialize Winsock
    WSAStartup(MAKEWORD(2, 2), &wsaData);


    /*
     * socket: create the parent socket
     */
    sockfd = socket(AF_INET, SOCK_DGRAM, 0);
    if (sockfd < 0)
        printf("ERROR opening socket");

    /* setsockopt: Handy debugging trick that lets
     * us rerun the server immediately after we kill it;
     * otherwise we have to wait about 20 secs.
     * Eliminates "ERROR on binding: Address already in use" error.
     */
    optval = 1;
    setsockopt(sockfd, SOL_SOCKET, SO_REUSEADDR,(const char *)&optval, sizeof(int));

    /*
     * build the server's Internet address
     */
    memset((char *)&serveraddr, sizeof(serveraddr), 0);
    serveraddr.sin_family = AF_INET;
    serveraddr.sin_addr.s_addr = htonl(INADDR_ANY);
    serveraddr.sin_port = htons((unsigned short)portno);

    /*
     * bind: associate the parent socket with a port
     */
    if (bind(sockfd, (struct sockaddr *) &serveraddr,
        sizeof(serveraddr)) < 0)
        printf("ERROR on binding");

    /*
     * main loop: wait for a datagram, then echo it
     */
    clientlen = sizeof(clientaddr);
    while (1) 
    {
        /*
         * recvfrom: receive a UDP datagram from a client
         */
        memset(buf, BUFSIZE, 0);
        numberOfBytes = recvfrom(sockfd, buf, BUFSIZE, 0, (struct sockaddr *) &clientaddr, &clientlen);
        if (numberOfBytes < 0)
            printf("ERROR in recvfrom");

        if (numberOfBytes > 0)
        {
            Message* curMessage = MessageFactory::Build((byte*)buf, numberOfBytes);
            if (NULL != curMessage)
            {
                DS_Status_Message* dsMessage = (DS_Status_Message*)curMessage;

                printf("Status:%d  ", dsMessage->GetStatus());
                printf("Seq:%d ", dsMessage->GetSequence());

                rcMessage->SetSequence(dsMessage->GetSequence());
                rcMessage->GetData((byte*)buf, &numberOfBytes);
            }

            if (false == clientIsOpen)
            {
                memset((char *)&clientSendAddr, sizeof(clientSendAddr), 0);
                clientSendAddr.sin_family = AF_INET;
                clientSendAddr.sin_addr.s_addr = clientaddr.sin_addr.s_addr;
                clientSendAddr.sin_port = htons((unsigned short)11110);
                
                clientIsOpen = true;
            }

            numberOfBytes = sendto(sockfd, buf, numberOfBytes, 0, (struct sockaddr *) &clientSendAddr, sizeof(clientSendAddr));
            //printf("sent %d bytes\n", numberOfBytes);
            if (numberOfBytes < 0)
                printf("ERROR in sendto");
        }

        memset(buf, BUFSIZE, 0);
        numberOfBytes = recvfrom(sockfd, buf, BUFSIZE, 0, (struct sockaddr *) &clientaddr, &clientlen);
        if (numberOfBytes < 0)
            printf("ERROR in recvfrom");

        if (numberOfBytes > 0)
        {
            Message* curMessage = MessageFactory::Build((byte*)buf, numberOfBytes);
            if (NULL != curMessage)
            {
                Controller_Message* controlMessage = (Controller_Message*)curMessage;

                printf("Buttons:%d %d %d %d\n", 
                    controlMessage->GetButton(0),
                    controlMessage->GetButton(1),
                    controlMessage->GetButton(2),
                    controlMessage->GetButton(3));
            }
        }

    }
}