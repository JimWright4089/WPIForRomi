#include "RomiEncoder.h"
#include "RomiMotor.h"

using namespace frc;

RomiEncoder* mRomiEncoder;
RomiMotor* mRomiMotor;

int main(void)
{
    mRomiEncoder = new RomiEncoder(I2C::kOnboard, 12);
    mRomiMotor = new RomiMotor(12, I2C::kOnboard, 12);

}