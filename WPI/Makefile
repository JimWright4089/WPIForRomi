
include Makefile.inc
               
MODULE   = wpilibc
OBJ      = $(OBJ_DIR)$(MODULE).a
MKDIR_P  = mkdir -p
              
C_SRC    = $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/ADXL345_I2C.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/ADXL345_SPI.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/ADXL362.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/ADXRS450_Gyro.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/AnalogAccelerometer.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/AnalogGyro.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/AnalogInput.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/AnalogOutput.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/AnalogPotentiometer.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/AnalogTrigger.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/AnalogTriggerOutput.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/BuiltInAccelerometer.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/CameraServer.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Compressor.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/ControllerPower.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Counter.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/DigitalGlitchFilter.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/DigitalInput.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/DigitalOutput.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/DoubleSolenoid.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/DriverStation.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Encoder.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/GearTooth.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/GenericHID.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/I2C.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/InterruptableSensorBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/IterativeRobot.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Jaguar.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Joystick.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/MotorSafetyHelper.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Notifier.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/PIDController.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/PowerDistributionPanel.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Preferences.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/PWM.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/PWMSpeedController.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Relay.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/RobotBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/RobotDrive.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/SafePWM.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/SampleRobot.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/SD540.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/SensorBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/SerialPort.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Servo.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/SolenoidBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Solenoid.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Spark.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/SPI.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Talon.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/TalonSRX.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Task.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Threads.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Timer.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Ultrasonic.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Utility.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Victor.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/VictorSP.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/XboxController.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/athena/src/Internal/HardwareHLReporting.cpp \
           $(ROOT_DIR)ntcore-master/src/Dispatcher.cpp \
	   $(ROOT_DIR)ntcore-master/src/DsClient.cpp \
	   $(ROOT_DIR)ntcore-master/src/Log.cpp \
	   $(ROOT_DIR)ntcore-master/src/Message.cpp \
	   $(ROOT_DIR)ntcore-master/src/NetworkConnection.cpp \
	   $(ROOT_DIR)ntcore-master/src/Notifier.cpp \
	   $(ROOT_DIR)ntcore-master/src/ntcore_c.cpp \
	   $(ROOT_DIR)ntcore-master/src/ntcore_cpp.cpp \
	   $(ROOT_DIR)ntcore-master/src/ntcore_test.cpp \
	   $(ROOT_DIR)ntcore-master/src/RpcServer.cpp \
	   $(ROOT_DIR)ntcore-master/src/SequenceNumber.cpp \
	   $(ROOT_DIR)ntcore-master/src/Storage.cpp \
	   $(ROOT_DIR)ntcore-master/src/Value.cpp \
	   $(ROOT_DIR)ntcore-master/src/WireDecoder.cpp \
	   $(ROOT_DIR)ntcore-master/src/WireEncoder.cpp \
	   $(ROOT_DIR)ntcore-master/src/tables/ITableListener.cpp \
	   $(ROOT_DIR)ntcore-master/src/tables/TableKeyNotDefinedException.cpp \
	   $(ROOT_DIR)ntcore-master/src/networktables/NetworkTable.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/ConvertUTF.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/ConvertUTFWrapper.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/ErrorHandling.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/Hashing.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/raw_os_ostream.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/raw_ostream.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/SmallPtrSet.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/SmallVector.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/StringExtras.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/StringMap.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/llvm/StringRef.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/support/Base64.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/support/leb128.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/support/raw_istream.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/support/raw_socket_istream.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/support/raw_socket_ostream.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/support/timestamp.cpp \
           $(ROOT_DIR)ntcore-master/wpiutil/src/tcpsockets/SocketError.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/tcpsockets/TCPAcceptor.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/tcpsockets/TCPConnector.cpp \
	   $(ROOT_DIR)ntcore-master/wpiutil/src/tcpsockets/TCPStream.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Accelerometer.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/AnalogAccumulator.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/AnalogGyro.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/AnalogInput.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/AnalogInternal.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/AnalogOutput.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/AnalogTrigger.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Compressor.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Constants.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Counter.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/DigitalInternal.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/DIO.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Encoder.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/FPGAEncoder.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/FRCDriverStation.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/HAL.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/I2C.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Interrupts.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Notifier.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/OSSerialPort.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/PCMInternal.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/PDP.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Ports.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Power.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/PWM.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Relay.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/SerialPort.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Solenoid.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/SPI.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/Threads.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/cpp/priority_mutex.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/cpp/Semaphore.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/cpp/SerialHelper.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/ctre/CtreCanNode.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/ctre/PCM.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/athena/ctre/PDP.cpp \
	   $(ROOT_DIR)allwpilib-master/hal/lib/shared/handles/HandlesInternal.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/ErrorBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Error.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/GamepadBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/GyroBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/HLUsageReporting.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/JoystickBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/PIDSource.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Resource.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/RobotState.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/Button.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/ButtonScheduler.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/CancelButtonScheduler.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/HeldButtonScheduler.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/InternalButton.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/JoystickButton.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/NetworkButton.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/PressedButtonScheduler.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/ReleasedButtonScheduler.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/ToggleButtonScheduler.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Buttons/Trigger.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/Command.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/CommandGroup.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/CommandGroupEntry.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/ConditionalCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/InstantCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/PIDCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/PIDSubsystem.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/PrintCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/Scheduler.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/StartCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/Subsystem.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/TimedCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/WaitCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/WaitForChildren.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Commands/WaitUntilCommand.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Filters/Filter.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/Filters/LinearDigitalFilter.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/interfaces/Potentiometer.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/LiveWindow/LiveWindow.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/LiveWindow/LiveWindowStatusListener.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/SmartDashboard/SendableChooserBase.cpp \
	   $(ROOT_DIR)allwpilib-master/wpilibc/shared/src/SmartDashboard/SmartDashboard.cpp \
	   $(ROOT_DIR)pi-libraries/FRCComm.cpp \
	   $(ROOT_DIR)pi-libraries/tSystem.cpp \
	   $(ROOT_DIR)pi-libraries/tAlarm.cpp \
	   $(ROOT_DIR)pi-libraries/theRelay.cpp \
	   $(ROOT_DIR)pi-libraries/thePWM.cpp \
	   $(ROOT_DIR)pi-libraries/theGlobal.cpp \
	   $(ROOT_DIR)pi-libraries/theSystemInterface.cpp \
	   $(ROOT_DIR)pi-libraries/tPower.cpp \
	   $(ROOT_DIR)pi-libraries/UsageReporting.cpp \
	   $(ROOT_DIR)pi-libraries/nInterfaceGlobals.cpp \
	   $(ROOT_DIR)pi-libraries/tSysWatchdog.cpp \
	   $(ROOT_DIR)pi-libraries/tInterruptManager.cpp \
	   $(ROOT_DIR)pi-libraries/i2c-lib.cpp \
	   $(ROOT_DIR)pi-libraries/Messages.cpp \
	   $(ROOT_DIR)pi-libraries/Utils.cpp


OBJ_FILES	  = 	$(OBJ_DIR)/ntcore-master/src/tables/*.o \
			$(OBJ_DIR)/ntcore-master/src/networktables/*.o \
			$(OBJ_DIR)/ntcore-master/src/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/athena/src/*.o \
			$(OBJ_DIR)/allwpilib-master/hal/lib/athena/*.o \
			$(OBJ_DIR)/allwpilib-master/hal/lib/athena/cpp/*.o \
			$(OBJ_DIR)/allwpilib-master/hal/lib/athena/ctre/*.o \
			$(OBJ_DIR)/allwpilib-master/hal/lib/shared/handles/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/athena/src/Internal/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/Buttons/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/Commands/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/Filters/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/interfaces/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/LiveWindow/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/SmartDashboard/*.o \
			$(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/*.o \
			$(OBJ_DIR)/ntcore-master/wpiutil/src/llvm/*.o \
			$(OBJ_DIR)/ntcore-master/wpiutil/src/support/*.o \
			$(OBJ_DIR)/ntcore-master/wpiutil/src/tcpsockets/*.o \
			$(OBJ_DIR)/pi-libraries/*.o

C_OBJ    = $(patsubst $(ROOT_DIR)%.cpp, $(OBJ_DIR)/%.o, $(C_SRC))

#############################################################################
# The main Targets
#############################################################################

.PHONY: direct 

all : direct compiles

direct:
	@$(MKDIR_P) $(OBJ_DIR)/ntcore-master/src/tables/
	@$(MKDIR_P) $(OBJ_DIR)/ntcore-master/src/networktables/
	@$(MKDIR_P) $(OBJ_DIR)/ntcore-master/src/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/athena/src
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/hal/lib/athena
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/hal/lib/athena/cpp
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/hal/lib/athena/ctre
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/hal/lib/shared/handles/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/athena/src/Internal/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/Buttons/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/Commands/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/Filters/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/interfaces/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/LiveWindow/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/SmartDashboard/
	@$(MKDIR_P) $(OBJ_DIR)/allwpilib-master/wpilibc/shared/src/
	@$(MKDIR_P) $(OBJ_DIR)/ntcore-master/wpiutil/src/llvm/
	@$(MKDIR_P) $(OBJ_DIR)/ntcore-master/wpiutil/src/support/
	@$(MKDIR_P) $(OBJ_DIR)/ntcore-master/wpiutil/src/tcpsockets/
	@$(MKDIR_P) $(OBJ_DIR)/pi-libraries/

compiles:	$(C_OBJ) $(EXECUTABLE)
		@echo 'Linking' $(OBJ)
		@ar rcs $(OBJ) $(OBJ_FILES)

clean :
	@echo 'Cleaning'
	@rm -rf $(OBJ_DIR)/

#############################################################################
# How to build the .elf files from the given .o-files
#############################################################################

$(EXECUTABLE) : $(C_OBJ)

#############################################################################
# This are generic targets how to build .o files out of the given .cpp/.s files
#############################################################################

$(OBJ_DIR)/%.o : $(ROOT_DIR)%.cpp   
	@echo Compiling $< ...
	@$(CC) $(CFLAGS) $(INC) -c -o $@ $<
