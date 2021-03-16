/*
 Name:		yamaha3Darduino.ino
 Created:	16.03.2021 15:34:44
 Author:	stein
*/

#include <AccelStepper.h>
int PulsePin=2;
int DirPin=3;
int ENBLPin=4;
AccelStepper Stepper();
void setup() {
	pinMode(PulsePin, OUTPUT);
	pinMode(DirPin, OUTPUT);
	pinMode(ENBLPin, OUTPUT);
}

// the loop function runs over and over again until power down or reset
void loop() {
  
}
