
include Makefile.inc
               
MODULE   = ccptest
OBJ      = $(ROOT_DIR)$(MODULE)
              
C_SRC    = $(ROOT_DIR)src/OI.cpp \
	   $(ROOT_DIR)src/Robot.cpp \
	   $(ROOT_DIR)src/RobotMap.cpp \
	   $(ROOT_DIR)src/StopWatch.cpp \
	   $(ROOT_DIR)src/Commands/AutonomousCommand.cpp \
	   $(ROOT_DIR)src/Commands/SimpleCommand.cpp \
	   $(ROOT_DIR)src/Subsystems/SimpleSubsystem.cpp

C_OBJ    = $(patsubst $(ROOT_DIR)%.cpp, $(OBJ_DIR)/%.o, $(C_SRC))

#############################################################################
# The main Targets
#############################################################################

.PHONY: direct 

all : direct compiles

direct:
	@$(MKDIR_P) $(OBJ_DIR)
	@$(MKDIR_P) $(OBJ_DIR)src
	@$(MKDIR_P) $(OBJ_DIR)src/Commands
	@$(MKDIR_P) $(OBJ_DIR)src/Subsystems

compiles:	$(C_OBJ) $(EXECUTABLE)
		@echo 'Linking' $(OBJ)
		@$(CC) -o $(OBJ) $(C_OBJ) $(CFLAGS) $(INC) -lpthread -L../../bins/ -lwpilibc


clean :
	@echo 'Removing the bins directory'
	@rm -rf $(OBJ_DIR)

#############################################################################
# This are generic targets how to build .o files out of the given .cpp/.s files
#############################################################################

$(OBJ_DIR)/%.o : $(ROOT_DIR)%.cpp   
	@echo Compiling $< ...
	@$(CC) $(CFLAGS) $(INC) -c -o $@ $<
