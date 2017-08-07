/*----------------------------------------------------------------------------*/
/* Copyright (c) FIRST 2016-2017. All Rights Reserved.                        */
/* Open Source Software - may be modified and shared by FRC teams. The code   */
/* must be accompanied by the FIRST BSD license file in the root directory of */
/* the project.                                                               */
/*----------------------------------------------------------------------------*/
#include <stdio.h>
#include "WPILib.h"
#include "StopWatch.hpp"
#include <networktables/NetworkTable.h>
#include <math.h>

class MyRobot : public IterativeRobot {
  /**
   * This function is run when the robot is first started up and should be
   * used for any initialization code.
   */

  std::shared_ptr<NetworkTable> tables;
  double count = 0.0;
  bool debugPrint = false;
  StopWatch* mStopWatch;

  void RobotInit() override 
  {
    mStopWatch = new StopWatch(5000);
    tables = NetworkTable::GetTable("datatable");
    printf("---RobotInit---\n");
    debugPrint = false;
  }

  /**
   * This function is run once each time the robot enters autonomous mode
   */
  void AutonomousInit() override 
  {
    printf("---AutonomousInit---\n");
    debugPrint = false;
    mStopWatch->Reset();
  }

  /**
   * This function is called periodically during autonomous
   */
  void AutonomousPeriodic() override 
  {
    if(false == debugPrint)
    {
      debugPrint = true;
      printf("---AutonomousPeriodic---\n");
    }

    if(!mStopWatch->IsExpired())
    {
      printf("---Waiting---:%ld\n",mStopWatch->GetTimeLeft());
    }

    double theSin = sin(count);
    double theCos = cos(count);
  
    tables->PutNumber("sin",theSin);
    tables->PutNumber("cos",theCos);
    tables->PutNumber("double",theSin*100.0);
//    printf("Count:%d\n",count);
    count += 0.01;
  }

  /**
   * This function is called once each time the robot enters tele-operated mode
   */
  void DisabledInit() override 
  {
    printf("---DisabledInit---\n");
    debugPrint = false;
  }

  /**
   * This function is called periodically during operator control
   */
  void DisabledPeriodic() override 
  {
    if(false == debugPrint)
    {
      debugPrint = true;
      printf("---DisabledPeriodic---\n");
    }
  }

  /**
   * This function is called once each time the robot enters tele-operated mode
   */
  void TeleopInit() override 
  {
    printf("---TeleopInit---\n");
    debugPrint = false;
  }

  /**
   * This function is called periodically during operator control
   */
  void TeleopPeriodic() override 
  {
    if(false == debugPrint)
    {
      debugPrint = true;
      printf("---TeleopPeriodic---\n");
    }
  }

  /**
   * This function is called once each time the robot enters tele-operated mode
   */
  void TestInit() override 
  {
    printf("---TestInit---\n");
    debugPrint = false;
  }

  /**
   * This function is called periodically during test mode
   */
  void TestPeriodic() override 
  {
    if(false == debugPrint)
    {
      debugPrint = true;
      printf("---TestPeriodic---\n");
    }
  }

  /**
   * This function is called periodically during all modes
   */
  void RobotPeriodic() override 
  {
//    printf("---RobotPeriodic---\n");
  }
};

START_ROBOT_CLASS(MyRobot)
