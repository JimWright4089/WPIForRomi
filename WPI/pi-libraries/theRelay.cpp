#include "theRelay.h"

using namespace nFPGA::nFRC_2017_17_0_2;

tSystemInterface* theRelay::getSystemInterface()
{
   return NULL;
}

void theRelay::writeValue(tValue value, tRioStatusCode *status)
{
}

void theRelay::writeValue_Forward(unsigned char value, tRioStatusCode *status)
{
}
void theRelay::writeValue_Reverse(unsigned char value, tRioStatusCode *status)
{
}
theRelay::tValue theRelay::readValue(tRioStatusCode *status)
{
	tRelay::tValue theValue;
	theValue.Forward = 0;
	theValue.Reverse = 0;
	return theValue;
}
unsigned char theRelay::readValue_Forward(tRioStatusCode *status)
{
	return 0;
}
unsigned char theRelay::readValue_Reverse(tRioStatusCode *status)
{
	return 0;
}

tRelay* tRelay::create(tRioStatusCode *status)
{
	return (tRelay*)new theRelay();
}


