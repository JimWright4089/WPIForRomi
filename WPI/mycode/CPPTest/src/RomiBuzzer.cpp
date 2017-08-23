//----------------------------------------------------------------------------
//
//  $Workfile: RomiBuzzer.cpp$
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
#include "RomiBuzzer.h"

using namespace frc;

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
RomiBuzzer::RomiBuzzer(I2C::Port port, int deviceAddress) :
    mI2C(port, deviceAddress),
    mPort(port),
    mDeviceAddress(deviceAddress)
{
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
void RomiBuzzer::PlayTone(int key, int length)
{
    uint8_t data[8];
    uint8_t dataLength = 8;
    uint8_t recLength = 4;
    uint8_t recData[4];

    data[0] = 0xA1;
    data[1] = 0x90;
    data[2] = 0x70;
    data[3] = 0x08;
    data[4] = 0x02;
    data[5] = 0x02;
    data[6] = 0x00;

    // Put the key of the tone in  the packet
    data[3] = (key >> 8) & 0xFF;
    data[4] = (key) & 0xFF;
    
    // Put the length of the tone in  the packet
    data[5] = (length >> 8) & 0xFF;
    data[6] = (length) & 0xFF;

    data[7] = CalcCheckByte(data,0,7);

    printf("%x %x %x %x %x %x %x %x \n",
        data[0], data[1], data[2], data[3], 
        data[4], data[5], data[6], data[7]);

    mI2C.Transaction(data, dataLength, recData, recLength);
}

//----------------------------------------------------------------------------
// See header 
//----------------------------------------------------------------------------
uint8_t RomiBuzzer::CalcCheckByte(uint8_t* data, uint8_t start, uint8_t number)
{
    uint8_t checkByte = 0xFF;

    for (uint8_t index = 0; index < number; index++)
    {
        checkByte ^= data[start + index];
    }
    return checkByte;
}

