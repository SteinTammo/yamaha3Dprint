/*
 Name:		yamaha3Darduino.ino
 Created:	16.03.2021 15:34:44
 Author:	stein
*/
#include <Controllino.h>
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


