#include "FRC_NetworkCommunication/CANSessionMux.h"
#include "FRC_NetworkCommunication/CANInterfacePlugin.h"
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
using namespace nCANSessionMux;


void FRC_NetworkCommunication_CANSessionMux_sendMessage(uint32_t messageID, const uint8_t *data, uint8_t dataSize, int32_t periodMs, int32_t *status)
{

}

void FRC_NetworkCommunication_CANSessionMux_receiveMessage(uint32_t *messageID, uint32_t messageIDMask, uint8_t *data, uint8_t *dataSize, uint32_t *timeStamp, int32_t *status)
{

}

void FRC_NetworkCommunication_CANSessionMux_openStreamSession(uint32_t *sessionHandle, uint32_t messageID, uint32_t messageIDMask, uint32_t maxMessages, int32_t *status)
{

}

void FRC_NetworkCommunication_CANSessionMux_closeStreamSession(uint32_t sessionHandle)
{

}

void FRC_NetworkCommunication_CANSessionMux_readStreamSession(uint32_t sessionHandle, struct tCANStreamMessage *messages, uint32_t messagesToRead, uint32_t *messagesRead, int32_t *status)
{

}

void FRC_NetworkCommunication_CANSessionMux_getCANStatus(float *percentBusUtilization, uint32_t *busOffCount, uint32_t *txFullCount, uint32_t *receiveErrorCount, uint32_t *transmitErrorCount, int32_t *status)
{

}





