#include <stdint.h>
#include "FRC_FPGA_ChipObject/fpgainterfacecapi/NiFpga.h"
typedef NiFpga_Status tRioStatusCode;
#include "FRC_FPGA_ChipObject/tSystemInterface.h"

using namespace nFPGA;

class theSystemInterface : tSystemInterface
{
public:
   theSystemInterface(){}

   const uint16_t getExpectedFPGAVersion();
   const uint32_t getExpectedFPGARevision();
   const uint32_t * const getExpectedFPGASignature();
   void getHardwareFpgaSignature(uint32_t *guid_ptr, tRioStatusCode *status);
   uint32_t getLVHandle(tRioStatusCode *status);
   uint32_t getHandle();
   void reset(tRioStatusCode *status);
};


