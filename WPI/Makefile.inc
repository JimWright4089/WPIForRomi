.PHONY : all clean

ROOT_DIR     = ./
OBJ_DIR      = ./bins/
                  
INC =   -I. \
        -I$(ROOT_DIR)allwpilib-master/wpilibc/athena/include \
        -I$(ROOT_DIR)allwpilib-master/wpilibc/shared/include \
        -I$(ROOT_DIR)allwpilib-master/hal/include \
        -I$(ROOT_DIR)allwpilib-master/ni-libraries/include \
        -I$(ROOT_DIR)ntcore-master/wpiutil/include \
        -I$(ROOT_DIR)ntcore-master/include \
        -I$(ROOT_DIR)cscore-master/include

CC       = g++
AR       = ar

CFLAGS   = -std=c++11 -Wformat=2 -Wall -Wextra -pedantic \
	   -Wno-psabi -Wno-unused-parameter -fPIC -rdynamic \
           -Wno-error=deprecated-declarations -pthread -Wignored-qualifiers -Wpedantic \
     	   -std=gnu++14

ARFLAGS	 = -rcs

