.PHONY : all clean
                
ROOT_DIR     = ./
LIB_DIR      = ../../
OBJ_DIR      = $(ROOT_DIR)bins/
                  
INC =   -I. \
        -I$(LIB_DIR)ntcore-master/wpiutil/include \
        -I$(LIB_DIR)ntcore-master/include \
        -I$(LIB_DIR)allwpilib-master/wpilibc/athena/include \
        -I$(LIB_DIR)allwpilib-master/wpilibc/shared/include \
        -I$(LIB_DIR)allwpilib-master/hal/include \
        -I$(LIB_DIR)allwpilib-master/ni-libraries/include \
        -I$(LIB_DIR)cscore-master/include

CC       = g++
MKDIR_P  = mkdir -p

CFLAGS   = -std=c++11 -Wformat=2 -Wall -Wextra -pedantic \
	   -Wno-psabi -Wno-unused-parameter -fPIC -rdynamic \
           -Wno-error=deprecated-declarations -pthread -Wignored-qualifiers -Wpedantic \
     	   -std=gnu++14
