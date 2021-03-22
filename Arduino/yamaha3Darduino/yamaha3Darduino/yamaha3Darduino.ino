/*
 Name:		yamaha3Darduino.ino
 Created:	16.03.2021 15:34:44
 Author:	stein
*/
#include <Controllino.h>
#include <MultiStepper.h>
#include <AccelStepper.h>
#include <string.h>

void setSpeed(float);
void SetMoveE(float amount);
void setOk();
float UpdateExtruderTemperatur();




int PulsePin=CONTROLLINO_D1;		// Pin fuer stepper
int DirPin=CONTROLLINO_D2;		// Richtungspin
int ENBLPin=CONTROLLINO_D3;		// Anschalten des Drivers
float ExtruderTemperatur = 0;
bool newPostion = false;
bool setDruckbett = false;
bool setExtruderheizen = false;
bool runspeed=false;
String recieve;

// Set to 16x microstepping
AccelStepper mystepper(1,PulsePin,DirPin);

void setup() 
{
	pinMode(PulsePin, OUTPUT);
	pinMode(DirPin, OUTPUT);
	digitalWrite(DirPin,LOW);
	pinMode(ENBLPin, OUTPUT);	
	digitalWrite(ENBLPin, HIGH);
	Serial.begin(9600);
	mystepper.setMaxSpeed(20000);
	mystepper.setAcceleration(5000*409);
	mystepper.setSpeed(200);
	//Serial.setTimeout(100);
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
	mystepper.run();
	bool inBewegung = false;
	inBewegung = mystepper.isRunning();
	Checkfinish(inBewegung);
	ExtruderRegelung();
}
void setSpeed(float flow)
{
	mystepper.setSpeed(flow);
	delay(20);
	setOk();
}
void SetMoveE(float amount)
{
	int Steps = amount * 409;
	mystepper.move(Steps);
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
	else if (choise == "M104")
	{
		setExtruderTemp(data.toFloat());
	}
	else if (choise == "")
	{

	}
}

void setExtruderTemp(float Temperatur)
{
	ExtruderTemperatur = Temperatur;
}

void ExtruderRegelung()
{
	
}
