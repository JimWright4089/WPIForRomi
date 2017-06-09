// Class for handling interrupts.
// Copyright (c) National Instruments 2008.  All Rights Reserved.

#include "FRC_FPGA_ChipObject/tSystem.h"
#include "FRC_FPGA_ChipObject/tInterruptManager.h"

using namespace nFPGA;

tInterruptManager::tInterruptManager(uint32_t interruptMask, bool watcher, tRioStatusCode *status) :
	tSystem(status)
{
}

tInterruptManager::~tInterruptManager()
{
}

void tInterruptManager::registerHandler(tInterruptHandler handler, void *param, tRioStatusCode *status)
{
}

uint32_t tInterruptManager::watch(int32_t timeoutInMs, bool ignorePrevious, tRioStatusCode *status)
{
	return 0;
}

void tInterruptManager::enable(tRioStatusCode *status)
{
}

void tInterruptManager::disable(tRioStatusCode *status)
{
}

bool tInterruptManager::isEnabled(tRioStatusCode *status)
{
	return false;
}

