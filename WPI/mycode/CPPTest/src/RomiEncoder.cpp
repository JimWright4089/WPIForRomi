#include "RomiEncoder.h"

using namespace frc;

RomiEncoder::RomiEncoder(I2C::Port port, int deviceAddress) :
    mI2C(port,deviceAddress)
{

}

int RomiEncoder::Get() const
{
    return 0;
}

void RomiEncoder::Reset()
{

}

double RomiEncoder::GetPeriod() const
{
    return 0.0;
}

void RomiEncoder::SetMaxPeriod(double maxPeriod)
{

}

bool RomiEncoder::GetStopped() const
{
    return false;
}

bool RomiEncoder::GetDirection() const
{
    return false;
}

double RomiEncoder::PIDGet()
{
    return 0.0;
}
