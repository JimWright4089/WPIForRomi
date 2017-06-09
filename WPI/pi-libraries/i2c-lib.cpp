#include<stdio.h>
#include "I2C.h"
#include "i2clib/i2c-lib.h"

int i2clib_open(const char *device)
{
	printf("i2clib_open\n");
	return 0;
}

void i2clib_close(int handle)
{
	printf("i2clib_close\n");
}

int i2clib_read(int handle, uint8_t dev_addr, char *recv_buf, int32_t recv_size)
{
	printf("i2clib_read\n");
	return 0;
}

int i2clib_write(int handle, uint8_t dev_addr, const char *send_buf, int32_t send_size)
{
	printf("i2clib_write\n");
	return 0;
}

int i2clib_writeread(int handle, uint8_t dev_addr, const char *send_buf, int32_t send_size, char *recv_buf, int32_t recv_size)
{
	printf("i2clib_writeread\n");
	return 0;
}



