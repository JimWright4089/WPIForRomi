#include "RomiBuzzer.h"

using namespace frc;

RomiBuzzer::RomiBuzzer(I2C::Port port, int deviceAddress) :
    mI2C(port, deviceAddress),
    mPort(port),
    mDeviceAddress(deviceAddress)
{
}

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

    data[3] = (key >> 8) & 0xFF;
    data[4] = (key) & 0xFF;
    
    data[5] = (length >> 8) & 0xFF;
    data[6] = (length) & 0xFF;

    data[7] = CalcCheckByte(data,0,7);

    mI2C.Transaction(data, dataLength, recData, recLength);
}

uint8_t RomiBuzzer::CalcCheckByte(uint8_t* data, uint8_t start, uint8_t number)
{
    uint8_t checkByte = 0xFF;

    for (uint8_t index = 0; index < number; index++)
    {
        checkByte ^= data[start + index];
    }
    return checkByte;
}

