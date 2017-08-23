#include<stdio.h>
#include <iostream>
#include <memory.h>
#include <unistd.h>
#include <errno.h>
#include <sys/ioctl.h>
#include <asm/ioctl.h>
#include <wiringPiI2C.h>
#include <stdio.h>
#include <fcntl.h>
#include <linux/i2c-dev.h>

#include "I2C.h"
#include "i2clib/i2c-lib.h"

int gFileI2C = 0;
const int WAIT_TIME = 125;

int i2clib_open(const char *device)
{
    //----- OPEN THE I2C BUS -----
    char *filename = (char*)"/dev/i2c-1";
    if ((gFileI2C = open(filename, O_RDWR)) < 0)
    {
        //ERROR HANDLING: you can check errno to see what went wrong
        printf("Failed to open the i2c bus");
        return 0;
    }

    return gFileI2C;
}

void i2clib_close(int handle)
{
    close(gFileI2C);
}

int i2clib_read(int handle, uint8_t dev_addr, char *recv_buf, int32_t recv_size)
{
    if (ioctl(gFileI2C, I2C_SLAVE, dev_addr) < 0)
    {
        printf("Failed to acquire bus access and/or talk to device.\n");
        //ERROR HANDLING; you can check errno to see what went wrong
        return 0;
    }

    if (read(gFileI2C, recv_buf, recv_size) != recv_size)
    {
        printf("Failed to read from the i2c bus.\n");
        return -1;
    }
    
    return 0;
}

int i2clib_write(int handle, uint8_t dev_addr, const char *send_buf, int32_t send_size)
{
    if (ioctl(gFileI2C, I2C_SLAVE, dev_addr) < 0)
    {
        printf("Failed to acquire bus access and/or talk to device.\n");
        //ERROR HANDLING; you can check errno to see what went wrong
        return 0;
    }

    if (write(gFileI2C, send_buf, send_size) != send_size)
    {
        printf("Failed to write to the i2c bus.\n");
        return -1;
    }

    usleep(WAIT_TIME);
    
    return 0;
}

int i2clib_writeread(int handle, uint8_t dev_addr,
    const char *send_buf, int32_t send_size,
    char *recv_buf, int32_t recv_size)
{
    if (ioctl(gFileI2C, I2C_SLAVE, dev_addr) < 0)
    {
        printf("Failed to acquire bus access and/or talk to device.\n");
        //ERROR HANDLING; you can check errno to see what went wrong
        return 0;
    }

    if (write(gFileI2C, send_buf, send_size) != send_size)
    {
        printf("Failed to write to the i2c bus.\n");
        return -1;
    }

    usleep(WAIT_TIME);
    if (read(gFileI2C, recv_buf, recv_size) != recv_size)
    {
        printf("Failed to read from the i2c bus.\n");
        return -1;
    }
    return 0;
}
