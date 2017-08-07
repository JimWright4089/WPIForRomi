#include "RomiMotor.h"

using namespace frc;

RomiMotor::RomiMotor(int aChannel, I2C::Port port, int deviceAddress) :
    mI2C(port, deviceAddress),
    mD(0.0),
    mI(0.0),
    mP(0.0)
{

}

double RomiMotor::Get() const
{
    return 0.0;
}

void RomiMotor::Set(double value)
{

}

void RomiMotor::SetInverted(bool isInverted)
{

}

void RomiMotor::Disable()
{

}

bool RomiMotor::GetInverted() const
{
    return false;
}

void RomiMotor::StopMotor()
{

}

void RomiMotor::PIDWrite(double output)
{

}
