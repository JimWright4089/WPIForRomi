#include <stdio.h>
#include "FRC_NetworkCommunication/UsageReporting.h"

using namespace nUsageReporting;

uint32_t EXPORT_FUNC report(tResourceType resource, uint8_t instanceNumber, uint8_t context = 0, const char *feature = NULL)
{
	printf("report QQ\n");
	return 0;
}

uint32_t EXPORT_FUNC FRC_NetworkCommunication_nUsageReporting_report(uint8_t resource, uint8_t instanceNumber, uint8_t context, const char *feature)
{
	printf("FRC_NetworkCommunication_nUsageReporting_report\n");
	return 0;
}

