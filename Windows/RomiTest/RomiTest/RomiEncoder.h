#pragma once

#include <stdint.h>

#include <memory>
#include <string>

#include "Encoder.h"
#include "I2C.h"


namespace frc {

    class RomiEncoder : public SensorBase,
                        public CounterBase,
                        public PIDSource
    {
    public:
        RomiEncoder(I2C::Port port, int deviceAddress);

        int Get() const;
        void Reset();
        double GetPeriod() const;
        void SetMaxPeriod(double maxPeriod);
        bool GetStopped() const;
        bool GetDirection() const;

        double PIDGet();


    protected:
        I2C mI2C;

    };

}