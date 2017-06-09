#include "theSystemInterface.h"

const uint16_t theSystemInterface::getExpectedFPGAVersion()
{
	return 0;
}

const uint32_t theSystemInterface::getExpectedFPGARevision()
{
	return 0;
}

const uint32_t * const theSystemInterface::getExpectedFPGASignature()
{
	return 0;
}

void theSystemInterface::getHardwareFpgaSignature(uint32_t *guid_ptr, tRioStatusCode *status)
{
}

uint32_t theSystemInterface::getLVHandle(tRioStatusCode *status)
{
	return 0;
}

uint32_t theSystemInterface::getHandle()
{
	return 0;
}

void theSystemInterface::reset(tRioStatusCode *status)
{
}

