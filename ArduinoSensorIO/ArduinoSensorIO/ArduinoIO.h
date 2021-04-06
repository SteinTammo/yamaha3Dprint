#pragma once
#include "Arduino.h"
#include <MultiStepper.h>
#include <AccelStepper.h>
#include <string.h>
class ArduinoIO
{
private:
	int pulsePin;
	int dirPin;
	int enblPin;
	int ExtruderHeizPin;
	int ExtruderTempPin;
	int ExtruderTempVoltagePin;
	int SetExtruderFanPin;
	int previousMillis;
	const int ThermistorTable[32][2]{ { 1, 713 }, { 17,300 }, { 20, 290 }, { 23,280 }, { 27,270 }, { 31,260 }, { 37, 250 }, { 43,240 }, { 51,230 },{61,220},{73,210},{87,200},{106,190},{128,180},{155,170},{189,	160},{230,150},{278,140},{336,130},{402,120},{476,110},{554,100},{635,90},{713,80},{784,70},{846,60},{897,50},{937,40},{966,30},{986,20},{1000,10},{1010,0} };

	float aktuelleExtruderTemperatur;
	float zielExtruderTemperatur;
	bool newPostion;
	bool setDruckbett;
	bool setExtruderheizen;
	AccelStepper mystepper;

public:
	ArduinoIO();
	void SetSpeed(float);
	void SetMoveE(float);
	void SetOk();
	float GetExtruderTemperatur();
	void SetExtruderTemperatur(float);
	void ExtruderTemperaturRegelung();
	void Initialisieren();
	void Run();
	void UpdateSerial();
	void NewCommand(String, String);
	void Checkfinish(bool);
	void SetZero();

};

