#pragma once
#include "Arduino.h"
#include <MultiStepper.h>
#include <AccelStepper.h>
#include <string.h>
#include <ResponsiveAnalogRead.h>
#include <Filters.h>
class ArduinoIO
{
private:
	int pulsePin;
	int dirPin;
	int enblPin;
	int ExtruderHeizPin;
	int ExtruderTempPin;
	int ExtruderTempVoltagePin;
	int DruckbettTempPin;
  int DruckbettHeizPin;
	int SetExtruderFanPin;
	int previousMillis;
	float filterFrequency;
	bool turn;
	float aktuelleExtruderTemperatur;
  float aktuelleDruckbettTemperatur;
	float zielExtruderTemperatur;
  float zielDruckbettTemperatur;
	bool newPostion;
	bool setDruckbett;
	bool setExtruderheizen;
  bool newETemp;
  bool newBTemp;
	AccelStepper mystepper;
  ResponsiveAnalogRead analog1;
  ResponsiveAnalogRead analog2;
	FilterOnePole lowpassFilterDruckbett;
	FilterOnePole lowpassFilterExtruder;

public:
	ArduinoIO();
	void SetSpeed(float);
	void SetMoveE(float);
	void SetOk();
	double GetExtruderTemperatur();
	void SetExtruderTemperatur(float);
  void ExtruderTemperaturRegelung();
  void DruckbettTemperaturRegelung();
	void Initialisieren();
	void Run();
	void UpdateSerial();
	void NewCommand(String, String);
	void Checkfinish(bool);
	void SetZero();
 double GetDruckbettTemperatur();
 void SetDruckbettTemperatur(float);

};
