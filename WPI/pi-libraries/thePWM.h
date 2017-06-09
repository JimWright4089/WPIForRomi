#include "FRC_FPGA_ChipObject/nRoboRIO_FPGANamespace/tPWM.h"

using namespace nFPGA;
using namespace nFPGA::nFRC_2017_17_0_2;

class thePWM : tPWM
{
public:
   tSystemInterface* getSystemInterface();
   void writeConfig(tConfig value, tRioStatusCode *status);
   void writeConfig_Period(unsigned short value, tRioStatusCode *status);
   void writeConfig_MinHigh(unsigned short value, tRioStatusCode *status);
   tConfig readConfig(tRioStatusCode *status);
   unsigned short readConfig_Period(tRioStatusCode *status);
   unsigned short readConfig_MinHigh(tRioStatusCode *status);
   unsigned short readLoopTiming(tRioStatusCode *status);
   void writePeriodScaleMXP(unsigned char bitfield_index, unsigned char value, tRioStatusCode *status);
   unsigned char readPeriodScaleMXP(unsigned char bitfield_index, tRioStatusCode *status);
   void writePeriodScaleHdr(unsigned char bitfield_index, unsigned char value, tRioStatusCode *status);
   unsigned char readPeriodScaleHdr(unsigned char bitfield_index, tRioStatusCode *status);
   void writeZeroLatch(unsigned char bitfield_index, bool value, tRioStatusCode *status);
   bool readZeroLatch(unsigned char bitfield_index, tRioStatusCode *status);
   void writeHdr(unsigned char reg_index, unsigned short value, tRioStatusCode *status);
   unsigned short readHdr(unsigned char reg_index, tRioStatusCode *status);
   void writeMXP(unsigned char reg_index, unsigned short value, tRioStatusCode *status);
   unsigned short readMXP(unsigned char reg_index, tRioStatusCode *status);
};

