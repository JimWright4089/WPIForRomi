//----------------------------------------------------------------------------
//
//  $Workfile: RomiEncoder.h$
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

#include "Encoder.h"
#include "I2C.h"


namespace frc 
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: RomiEncoder
    // 
    // Purpose:
    //      This class sends and recieves I2C commands to find the encoder counts
    //
    //----------------------------------------------------------------------------
    class RomiEncoder : public SensorBase,
                     //   public CounterBase,
                        public PIDSource
    {
    public:
        //----------------------------------------------------------------------------
        // Purpose:
        //      Constructor
        //
        //----------------------------------------------------------------------------
        RomiEncoder(I2C::Port port, int deviceAddress);

        //----------------------------------------------------------------------------
        // Purpose:
        //      Set the encoder to left(true) or right(false)
        //
        //----------------------------------------------------------------------------
        void SetLeftEncoder(bool isLeft);

        //----------------------------------------------------------------------------
        // Purpose:
        //      Get the current count of the encoder
        //
        //----------------------------------------------------------------------------
        int Get();

        //----------------------------------------------------------------------------
        // Purpose:
        //      Reset the encoder to zero
        //
        //----------------------------------------------------------------------------
        void Reset();

        //----------------------------------------------------------------------------
        // Purpose:
        //      Return the period of the PID calc
        //
        //----------------------------------------------------------------------------
        double GetPeriod() const;

        //----------------------------------------------------------------------------
        // Purpose:
        //      Sets the period of the PID calc
        //
        //----------------------------------------------------------------------------
        void SetMaxPeriod(double maxPeriod);

        //----------------------------------------------------------------------------
        // Purpose:
        //      Return if the encoder is stopped
        //
        //----------------------------------------------------------------------------
        bool GetStopped() const;

        //----------------------------------------------------------------------------
        // Purpose:
        //      Return the direction of the encoder
        //
        //----------------------------------------------------------------------------
        bool GetDirection() const;

        //----------------------------------------------------------------------------
        // Purpose:
        //      Return the PID value of the encoder
        //
        //----------------------------------------------------------------------------
        double PIDGet();

    protected:
        //----------------------------------------------------------------------------
        //  Class Attrubutes
        //----------------------------------------------------------------------------
        I2C mI2C;
        I2C::Port mPort;
        int mDeviceAddress;
        long mCount;
        bool mLeftEncoder;

        //----------------------------------------------------------------------------
        // Purpose:
        //      Calculate the check byte, this class needs refactoring for inheitance
        //
        //----------------------------------------------------------------------------
        uint8_t CalcCheckByte(uint8_t* data, uint8_t start, uint8_t number);
    };

}