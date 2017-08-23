//----------------------------------------------------------------------------
//
//  $Workfile: RomiBuzzer.h$
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
#pragma once

#include <stdint.h>
#include <memory>
#include <string>

#include "I2C.h"

namespace frc 
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: RomiBuzzer
    // 
    // Purpose:
    //      This class sends and recieves I2C commands to play tones on the buzzer
    //
    //----------------------------------------------------------------------------
    class RomiBuzzer
    {
    public:
        //----------------------------------------------------------------------------
        // Purpose:
        //      Constructor
        //
        //----------------------------------------------------------------------------
        RomiBuzzer(I2C::Port port, int deviceAddress);

        //----------------------------------------------------------------------------
        // Purpose:
        //      Sends a command to play a tone
        //
        //----------------------------------------------------------------------------
        void PlayTone(int key, int length);

    protected:
        //----------------------------------------------------------------------------
        //  Class Attrubutes
        //----------------------------------------------------------------------------
        I2C mI2C;
        I2C::Port mPort;
        int mDeviceAddress;

        //----------------------------------------------------------------------------
        // Purpose:
        //      Calculate the check byte, this class needs refactoring for inheitance
        //
        //----------------------------------------------------------------------------
        uint8_t CalcCheckByte(uint8_t* data, uint8_t start, uint8_t number);
    };

}