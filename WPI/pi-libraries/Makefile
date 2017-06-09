
include Makefile.inc
               
MODULE   = libntcore
OBJ      = $(OBJ_DIR)/$(MODULE).a
MAP      = $(OBJ_DIR)/$(MODULE).map

               
C_SRC    = $(SRC_DIR)/FRCComm.cpp \
	   $(SRC_DIR)/tSystem.cpp \
	   $(SRC_DIR)/tAlarm.cpp \
	   $(SRC_DIR)/tPower.cpp \
	   $(SRC_DIR)/tGlobal.cpp \
	   $(SRC_DIR)/UsageReporting.cpp \
	   $(SRC_DIR)/nInterfaceGlobals.cpp \
	   $(SRC_DIR)/tSysWatchdog.cpp \
	   $(SRC_DIR)/tInterruptManager.cpp

C_OBJ    = $(patsubst $(SRC_DIR)/%.cpp, $(OBJ_DIR)/lib%.so, $(C_SRC))

#############################################################################
# The main Targets
#############################################################################

all : $(C_OBJ) $(EXECUTABLE)

clean :
	mkdir -p $(OBJ_DIR)
	rm -f $(OBJ_DIR)/*.so

#############################################################################
# How to build the .elf files from the given .o-files
#############################################################################

$(EXECUTABLE) : $(C_OBJ)

#############################################################################
# This are generic targets how to build .o files out of the given .cpp/.s files
#############################################################################

$(OBJ_DIR)/lib%.so : $(SRC_DIR)/%.cpp   
	@echo Compiling $< ...
	@$(CC) $(CFLAGS) $(INC) -c -o $@ $<
