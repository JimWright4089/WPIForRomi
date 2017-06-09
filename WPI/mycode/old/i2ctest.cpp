#include <stdio.h>
#include "I2C.h"

using namespace frc;

int main(void)
{
	printf("Test\n");
	I2C* i2cPort = new I2C(I2C::Port::kOnboard, 0x08);

	i2cPort->Write(0x2D,0x08);
	return 0;
}
