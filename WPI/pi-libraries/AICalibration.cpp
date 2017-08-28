#include "FRC_NetworkCommunication/AICalibration.h"
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

using namespace nFPGA::nFRC_2017_17_0_2;

uint32_t FRC_NetworkCommunication_nAICalibration_getLSBWeight(const uint32_t aiSystemIndex, const uint32_t channel, int32_t *status)
{
    return 0;
}

int32_t FRC_NetworkCommunication_nAICalibration_getOffset(const uint32_t aiSystemIndex, const uint32_t channel, int32_t *status)
{
    return 0;
}



