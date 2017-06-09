.PHONY : all clean

DEBUGCFG = _NDEBUG
ifeq "$(DEBUG)" "1"
    DEBUGCFG = _DEBUG
endif
                
SRC_DIR      = .
APP_DIR      = ../../
OBJ_DIR      = ./bins
APP_OBJS_DIR = $(APP_DIR)/bins
                  
INC =   -I. \
        -I$(APP_DIR)/wpilibc/athena/include \
        -I$(APP_DIR)/wpilibc/shared/include \
        -I$(APP_DIR)/hal/include \
        -I$(APP_DIR)/pi-libraries/include \
        -I$(APP_DIR)../ntcore-master/wpiutil/include \
        -I$(APP_DIR)../ntcore-master/include \
        -I$(APP_DIR)../cscore-master/include

CC       = g++
AR       = ar

CFLAGS   = -std=c++11 -Wformat=2 -Wall -Wextra -pedantic \
	   -Wno-psabi -Wno-unused-parameter -fPIC -rdynamic \
           -Wno-error=deprecated-declarations -pthread -shared

ARFLAGS	 = -rcs

OBJCPYFLAGS = --output-target=srec

