#include "FRC_NetworkCommunication/FRCComm.h"
#include <stdio.h>
#include <pthread.h>
#include <unistd.h>
#include <memory.h>
#include "FRC_FPGA_ChipObject/nRoboRIO_FPGANamespace/tDIO.h"
#include "FRC_FPGA_ChipObject/nRoboRIO_FPGANamespace/tRelay.h"
#include "FRC_FPGA_ChipObject/nRoboRIO_FPGANamespace/tPWM.h"
#include "FRC_FPGA_ChipObject/nRoboRIO_FPGANamespace/tSPI.h"
#include <stdlib.h>
#include <string.h>
#include <netdb.h>
#include <sys/types.h> 
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>

#include "Messages.hpp"

#define BUFSIZE 1024

using namespace nFPGA::nFRC_2017_17_0_2;

const char* WPILibVersion = "TEST";
pthread_t theThread;
pthread_cond_t* theSem = NULL;
ControlWord_t thecontrolWord;
int theCount = 0;

#define MAX_JOYSTICK 6

Controller_Message* theJoySticks[MAX_JOYSTICK];
JoystickPOV_t* theJoystickPOV[MAX_JOYSTICK];
byte mAllianceStation;

Controller_Message joyStick0;
Controller_Message joyStick1;
Controller_Message joyStick2;
Controller_Message joyStick3;
Controller_Message joyStick4;
Controller_Message joyStick5;

JoystickPOV_t joystickPOV0;
JoystickPOV_t joystickPOV1;
JoystickPOV_t joystickPOV2;
JoystickPOV_t joystickPOV3;
JoystickPOV_t joystickPOV4;
JoystickPOV_t joystickPOV5;

void* runThread(void*);

int EXPORT_FUNC FRC_NetworkCommunication_Reserve(void *instance)
{
    theJoySticks[0] = &joyStick0;
    theJoySticks[1] = &joyStick1;
    theJoySticks[2] = &joyStick2;
    theJoySticks[3] = &joyStick3;
    theJoySticks[4] = &joyStick4;
    theJoySticks[5] = &joyStick5;

    theJoystickPOV[0] = &joystickPOV0;
    theJoystickPOV[1] = &joystickPOV1;
    theJoystickPOV[2] = &joystickPOV2;
    theJoystickPOV[3] = &joystickPOV3;
    theJoystickPOV[4] = &joystickPOV4;
    theJoystickPOV[5] = &joystickPOV5;

    pthread_create(&theThread, NULL, &runThread, NULL);
    return 0;
}

void EXPORT_FUNC getFPGAHardwareVersion(uint16_t *fpgaVersion, uint32_t *fpgaRevision)
{
}

int EXPORT_FUNC setErrorData(const char *errors, int errorsLength, int wait_ms)
{
    return 0;
}

/**
* Send a console output line to the Driver Station
* @param line a null-terminated string
* @return 0 on success, other on failure
*/
int EXPORT_FUNC FRC_NetworkCommunication_sendConsoleLine(const char *line)
{
    return 0;
}

/**
* Send an error to the Driver Station
* @param isError true if error, false if warning
* @param errorCode value of error condition
* @param isLVCode true if error code is defined in errors.txt, false if not (i.e. made up for C++)
* @param details error description that contains details such as which resource number caused the failure
* @param location Source file, function, and line number that the error was generated - optional
* @param callStack The details about what functions were called through before the error was reported - optional
* @return 0 on success, other on failure
*/

int EXPORT_FUNC FRC_NetworkCommunication_sendError(int isError, int32_t errorCode, int isLVCode,
    const char *details, const char *location, const char *callStack)
{
    printf("FRC_NetworkCommunication_sendError\n");
    return 0;
}

void EXPORT_FUNC setNewDataSem(pthread_cond_t *sem)
{
    theSem = sem;
    printf("setNewDataSem(pthread_cond_t *)\n");
}

int EXPORT_FUNC setNewDataOccurRef(uint32_t refnum)
{
    printf("setNewDataOccurRef(uint32_t refnum)\n");
    return 0;
}

int EXPORT_FUNC FRC_NetworkCommunication_getControlWord(struct ControlWord_t *controlWord)
{
    //	printf("FRC_NetworkCommunication_getControlWord\n");
    memcpy(controlWord, &thecontrolWord, sizeof(ControlWord_t));
    return 0;
}

int EXPORT_FUNC FRC_NetworkCommunication_getAllianceStation(enum AllianceStationID_t *allianceStation)
{
    *allianceStation = (AllianceStationID_t)mAllianceStation;
    return 0;
}

int EXPORT_FUNC FRC_NetworkCommunication_getMatchTime(float *matchTime)
{
    return 0;
}

int EXPORT_FUNC FRC_NetworkCommunication_getJoystickAxes(uint8_t joystickNum, struct JoystickAxes_t *axes, uint8_t maxAxes)
{
    if ((joystickNum<MAX_JOYSTICK) && (theJoySticks[joystickNum] != NULL))
    {
        axes->count = 10;
        for (int i = 0; i<10; i++)
        {
            axes->axes[i] = (float)theJoySticks[joystickNum]->GetAnalog(i);
        }
        return 0;
    }
    return -1;
}

int EXPORT_FUNC FRC_NetworkCommunication_getJoystickButtons(uint8_t joystickNum, uint32_t *buttons, uint8_t *count)
{
    if ((joystickNum<MAX_JOYSTICK) && (theJoySticks[joystickNum] != NULL))
    {
        *buttons = theJoySticks[joystickNum]->GetAllButtons();
        *count = 32;
        return 0;
    }
    return -1;
}

int EXPORT_FUNC FRC_NetworkCommunication_getJoystickPOVs(uint8_t joystickNum, struct JoystickPOV_t *povs, uint8_t maxPOVs)
{
    if ((joystickNum<MAX_JOYSTICK) && (theJoystickPOV[joystickNum] != NULL))
    {
        povs = theJoystickPOV[joystickNum];
        return 0;
    }
    return -1;
}

int EXPORT_FUNC FRC_NetworkCommunication_setJoystickOutputs(uint8_t joystickNum, uint32_t hidOutputs, uint16_t leftRumble, uint16_t rightRumble)
{
    return 0;
}

int EXPORT_FUNC FRC_NetworkCommunication_getJoystickDesc(uint8_t joystickNum, uint8_t *isXBox, uint8_t *type, char *name, uint8_t *axisCount, uint8_t *axisTypes, uint8_t *buttonCount, uint8_t *povCount)
{
    *axisCount = 10;
    *buttonCount = 32;
    *povCount = 0;
    return 0;
}

void EXPORT_FUNC FRC_NetworkCommunication_getVersionString(char *version)
{
    printf("FRC_NetworkCommunication_getVersionString\n");
}

int EXPORT_FUNC FRC_NetworkCommunication_observeUserProgramStarting(void)
{
    printf("FRC_NetworkCommunication_observeUserProgramStarting(void)\n");
    return 0;
}

void EXPORT_FUNC FRC_NetworkCommunication_observeUserProgramDisabled(void)
{
    //	printf("FRC_NetworkCommunication_observeUserProgramDisabled\n");
}

void EXPORT_FUNC FRC_NetworkCommunication_observeUserProgramAutonomous(void)
{
    //	printf("FRC_NetworkCommunication_observeUserProgramAutonomous\n");
}

void EXPORT_FUNC FRC_NetworkCommunication_observeUserProgramTeleop(void)
{
    //	printf("FRC_NetworkCommunication_observeUserProgramTeleop\n");
}

void EXPORT_FUNC FRC_NetworkCommunication_observeUserProgramTest(void)
{
}

tDIO* tDIO::create(int *status)
{
    return NULL;
}

tSPI* tSPI::create(int *status)
{
    return NULL;
}

void* runThread(void*)
{
    int sockfd; /* socket */
    int portno = 11111; /* port to listen on */
    int clientlen; /* byte size of client's address */
    struct sockaddr_in serveraddr; /* server's addr */
    struct sockaddr_in clientaddr; /* client addr */
    struct sockaddr_in clientSendAddr; /* client addr */
    bool clientIsOpen = false;
    char buf[BUFSIZE]; /* message buf */
    int optval; /* flag value for setsockopt */
    int numberOfBytes; /* message byte size */
    RC_Status_Message* rcMessage = new RC_Status_Message();

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
    setsockopt(sockfd, SOL_SOCKET, SO_REUSEADDR, (const char *)&optval, sizeof(int));

    /*
    * build the server's Internet address
    */
    memset((char *)&serveraddr, 0, sizeof(serveraddr));
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
        memset(buf, 0, BUFSIZE);
        numberOfBytes = recvfrom(sockfd, buf, BUFSIZE, 0, (struct sockaddr *) &clientaddr, (socklen_t*)&clientlen);
        if (numberOfBytes < 0)
            printf("ERROR in recvfrom");

        thecontrolWord.dsAttached = 1;

        if (numberOfBytes > 0)
        {
            Message* curMessage = MessageFactory::Build((byte*)buf, numberOfBytes);
            if (NULL != curMessage)
            {
                if (Message::DS_STATUS == curMessage->GetMessageID())
                {
                    DS_Status_Message* dsMessage = (DS_Status_Message*)curMessage;

                    mAllianceStation = dsMessage->GetAll();

                    switch (dsMessage->GetStatus())
                    {
                    case(0):
                        thecontrolWord.enabled = 0;
                        thecontrolWord.autonomous = 0;
                        thecontrolWord.test = 0;
                        break;
                    case(1):
                        thecontrolWord.enabled = 1;
                        thecontrolWord.autonomous = 1;
                        thecontrolWord.test = 0;
                        break;
                    case(2):
                        thecontrolWord.enabled = 1;
                        thecontrolWord.autonomous = 0;
                        thecontrolWord.test = 0;
                        break;
                    case(3):
                        thecontrolWord.enabled = 1;
                        thecontrolWord.autonomous = 0;
                        thecontrolWord.test = 1;
                        break;
                    }
                    pthread_cond_signal(theSem);
                    rcMessage->SetSequence(dsMessage->GetSequence());
                    rcMessage->GetData((byte*)buf, &numberOfBytes);

                    if (false == clientIsOpen)
                    {
                        memset((char *)&clientSendAddr, 0, sizeof(clientSendAddr));
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

                if (Message::CONNTROLLER == curMessage->GetMessageID())
                {
                    Controller_Message* controlMessage = (Controller_Message*)curMessage;
                    if (controlMessage->GetNumber()<MAX_JOYSTICK)
                    {
                        theJoySticks[controlMessage->GetNumber()] = controlMessage;
                    }
                    /*
                    printf("Buttons:%d %d %d %d %d\n",
                    controlMessage->GetNumber(),
                    controlMessage->GetButton(0),
                    controlMessage->GetButton(1),
                    controlMessage->GetButton(2),
                    controlMessage->GetButton(3));
                    */
                }
            }
        }
        usleep(20);
    }
    return NULL;
}

