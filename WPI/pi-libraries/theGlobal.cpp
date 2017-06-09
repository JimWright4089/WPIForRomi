#include <stdio.h>
#include "theGlobal.h"

using namespace nFPGA::nFRC_2017_17_0_2;

tSystemInterface* theGlobal::getSystemInterface()
{
   return NULL;
}

void theGlobal::writeLEDs(tLEDs value, tRioStatusCode *status)
{
}

void theGlobal::writeLEDs_Comm(unsigned char value, tRioStatusCode *status)
{
}

void theGlobal::writeLEDs_Mode(unsigned char value, tRioStatusCode *status)
{
}

void theGlobal::writeLEDs_RSL(bool value, tRioStatusCode *status)
{
}

tGlobal::tLEDs theGlobal::readLEDs(tRioStatusCode *status)
{
	return mLEDs;
}

unsigned char theGlobal::readLEDs_Comm(tRioStatusCode *status)
{
	return 0;
}

unsigned char theGlobal::readLEDs_Mode(tRioStatusCode *status)
{
	return 0;
}

bool theGlobal::readLEDs_RSL(tRioStatusCode *status)
{
	return false;
}

unsigned short theGlobal::readVersion(tRioStatusCode *status)
{
	return 0;
}
unsigned int theGlobal::readLocalTime(tRioStatusCode *status)
{
	return 0;
}
bool theGlobal::readUserButton(tRioStatusCode *status)
{
	return false;
}
unsigned int theGlobal::readRevision(tRioStatusCode *status)
{
	return 0;
}


tGlobal* tGlobal::create(tRioStatusCode *status)
{
	return (tGlobal*)new theGlobal();
}

