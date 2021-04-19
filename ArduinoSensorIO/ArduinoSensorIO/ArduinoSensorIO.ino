/*
 Name:		ArduinoSensorIO.ino
 Created:	26.03.2021 10:27:17
 Author:	stein
*/
#include <ResponsiveAnalogRead.h>
#include <MultiStepper.h>
#include <AccelStepper.h>
#include <string.h>
#include "ArduinoIO.h"




ArduinoIO ArduinoIO;

void setup()
{

	ArduinoIO.Initialisieren();
}

// the loop function runs over and over again until power down or reset
void loop()
{
	ArduinoIO.Run();
}
