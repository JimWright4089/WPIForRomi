#pragma once

#include <stdint.h>

#include <memory>
#include <string>

#include "SpeedController.h"
#include "I2C.h"


namespace frc {

    class RomiMotor : public SpeedController
    {
    public:
        RomiMotor(int aChannel, I2C::Port port, int deviceAddress);

        double Get() const;
        void Set(double value);
        void SetInverted(bool isInverted);
        void Disable();
        bool GetInverted() const;
        void StopMotor();

        void PIDWrite(double output);


    protected:
        I2C mI2C;
        double mP;
        double mD;
        double mI;

    };

}