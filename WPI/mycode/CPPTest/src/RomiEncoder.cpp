//----------------------------------------------------------------------------
//
//  $Workfile: RomiEncoder.cpp$
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
#include "RomiEncoder.h"

using namespace frc;

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
RomiEncoder::RomiEncoder(I2C::Port port, int deviceAddress) :
    mI2C(port, deviceAddress),
    mPort(port),
    mDeviceAddress(deviceAddress),
    mCount(0),
    mLeftEncoder(true)
{

}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiEncoder::SetLeftEncoder(bool isLeft)
{
    mLeftEncoder = isLeft;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
int RomiEncoder::Get()
{
    uint8_t data[3];
    uint8_t dataLength = 3;
    uint8_t recLength = 8;
    uint8_t recData[8];

    data[0] = 0xA1;
    data[1] = 0x42;
    if (true == mLeftEncoder)
    {
        data[1] = 0x41;
    }
    data[2] = CalcCheckByte(data, 0, 2);

    mI2C.Transaction(data, dataLength, recData, recLength);

    uint8_t check = CalcCheckByte(recData, 0, 8);

    if (check == recData[7])
    {
        memcpy(&mCount, &recData[2], sizeof(int));
    }
    
    return (int)mCount;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiEncoder::Reset()
{
    uint8_t data[3];
    uint8_t dataLength = 3;
    uint8_t recLength = 4;
    uint8_t recData[4];

    data[0] = 0xA1;
    data[1] = 0x32;
    if (true == mLeftEncoder)
    {
        data[1] = 0x31;
    }
    data[2] = CalcCheckByte(data, 0, 2);

    mI2C.Transaction(data, dataLength, recData, recLength);
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
double RomiEncoder::GetPeriod() const
{
    return 0.0;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiEncoder::SetMaxPeriod(double maxPeriod)
{

}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
bool RomiEncoder::GetStopped() const
{
    return false;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
bool RomiEncoder::GetDirection() const
{
    return false;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
double RomiEncoder::PIDGet()
{
    return 0.0;
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
uint8_t RomiEncoder::CalcCheckByte(uint8_t* data, uint8_t start, uint8_t number)
{
    uint8_t checkByte = 0xFF;

    for (uint8_t index = 0; index < number; index++)
    {
        checkByte ^= data[start + index];
    }
    return checkByte;
}
