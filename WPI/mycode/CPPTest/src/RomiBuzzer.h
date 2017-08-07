#pragma once

#include <stdint.h>

#include <memory>
#include <string>

#include "I2C.h"


namespace frc {

    class RomiBuzzer 
    {
    public:
        RomiBuzzer(I2C::Port port, int deviceAddress);

        void PlayTone(int key, int length);

    protected:
        I2C mI2C;
        I2C::Port mPort;
        int mDeviceAddress;

        uint8_t CalcCheckByte(uint8_t* data, uint8_t start, uint8_t number);
    };

}