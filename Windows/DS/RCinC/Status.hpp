#ifndef STATUS_HPP
#define STATUS_HPP

#include "Common.h"

class DSStatus
{
	public:
	static const byte STATUS_DISA = 0x00;
	static const byte STATUS_AUTO = 0x01;
	static const byte STATUS_TELE = 0x02;
	static const byte STATUS_TEST = 0x03;
};

class RCStatus
{
	public:
	static const byte STATUS_GOOD = 0x04;
	static const byte STATUS_FAIL = 0x05;
};

#endif
