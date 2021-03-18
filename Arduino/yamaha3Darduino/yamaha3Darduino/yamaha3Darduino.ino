/*
 Name:		yamaha3Darduino.ino
 Created:	16.03.2021 15:34:44
 Author:	stein
*/

#include <MultiStepper.h>
#include <AccelStepper.h>
#include <string.h>

void setSpeed(float);
void SetMoveE(float amount);
void setOk();
float UpdateExtruderTemperatur();




int PulsePin=2;		// Pin fuer stepper
int DirPin=3;		// Richtungspin
int ENBLPin=4;		// Anschalten des Drivers

bool newPostion = false;
bool setDruckbett = false;
bool setExtruderheizen = false;

// Set to 16x microstepping
AccelStepper Stepper(1,PulsePin,DirPin);

void setup() 
{
	pinMode(PulsePin, OUTPUT);
	pinMode(DirPin, OUTPUT);
	pinMode(ENBLPin, OUTPUT);	
	Stepper.setEnablePin(ENBLPin);
	pinMode(A0, OUTPUT);
	Serial.begin(9600);
}

// the loop function runs over and over again until power down or reset
void loop() 
{
	if (Serial.available() > 0)
	{	
		String choise = Serial.readStringUntil('&');		
		String data = Serial.readStringUntil('&');
		
		if (data != "" && choise != "")
		{
			newCommand(choise, data);
		}
	}	
	Stepper.run();
	bool inBewegung = false;
	inBewegung = Stepper.isRunning();
	Checkfinish(inBewegung);

}
void setSpeed(float flow)
{
	Stepper.setSpeed(flow);
	delay(20);
	setOk();
}
void SetMoveE(float amount)
{
	int Steps = amount * 409;
	Stepper.move(amount);
	newPostion = true;
}

void Checkfinish(bool move)
{
	if (move == false && newPostion==true)
	{
		setOk();
		newPostion = false;
	}
}
void setOk()
{
	Serial.println("OK");
}
float UpdateExtruderTemperatur()
{
	float voltage = analogRead(A0) * (5.0 / 1023.0);
	float Temperatur = 0.003498 * voltage + 1.167;
	return Temperatur;
}

void newCommand(String choise, String data)
{
	if (choise == "G1E")
	{
		SetMoveE(data.toFloat());
	}
	else if (choise == "G1F")
	{
		setSpeed(data.toFloat());
	}
	else if (choise == "")
	{

	}
	else if (choise == "")
	{

	}
}
