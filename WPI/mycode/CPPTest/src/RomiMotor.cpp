//----------------------------------------------------------------------------
//
//  $Workfile: RomiMotor.cpp$
//
//  $Revision: X$
//
//  Project:    WPI for PI
//
//                            Copyright (c) 2017
//                               James A Wright
//                            All Rights Reserved
//
//  Modification History:
//  $Log:
//  $
//
//----------------------------------------------------------------------------
#include "RomiMotor.h"

using namespace frc;

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
RomiMotor::RomiMotor(I2C::Port port, int deviceAddress) :
    mI2C(port, deviceAddress),
    mPort(port),
    mDeviceAddress(deviceAddress),
    mP(0.0),
    mI(0.0),
    mD(0.0),
    mSetPower(0.0),
    mInverted(false),
    mLeftMotor(true)
{

}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
double RomiMotor::Get() const
{
    return mSetPower;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiMotor::Set(double value)
{
    mSetPower = value;
    short powerToSend = (short)(MAX_POWER*value);

    if (true == mInverted)
    {
        powerToSend *= -1;
    }

    uint8_t data[5];
    uint8_t dataLength = 5;
    uint8_t recLength = 4;
    uint8_t recData[4];

    data[0] = 0xA1;
    data[1] = 0x22;
    if (true == mLeftMotor)
    {
        data[1] = 0x21;
    }

    // Put the key of the tone in  the packet
    data[3] = (powerToSend >> 8) & 0xFF;
    data[2] = (powerToSend) & 0xFF;

    data[4] = CalcCheckByte(data, 0, 4);
    
    //printf("%x %x %x %x %x\n",
    //    data[0], data[1], data[2], data[3],
    //    data[4]);

    mI2C.Transaction(data, dataLength, recData, recLength);
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiMotor::SetLeftMotor(bool isLeft)
{
    mLeftMotor = isLeft;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiMotor::SetInverted(bool isInverted)
{
    mInverted = isInverted;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiMotor::Disable()
{
    Set(0.0);
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
bool RomiMotor::GetInverted() const
{
    return mInverted;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiMotor::StopMotor()
{
    Set(0.0);
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiMotor::PIDWrite(double output)
{
    
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
uint8_t RomiMotor::CalcCheckByte(uint8_t* data, uint8_t start, uint8_t number)
{
    uint8_t checkByte = 0xFF;

    for (uint8_t index = 0; index < number; index++)
    {
        checkByte ^= data[start + index];
    }
    return checkByte;
}

