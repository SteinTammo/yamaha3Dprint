#include "ArduinoIO.h"


ArduinoIO::ArduinoIO()
{
	this->pulsePin = CONTROLLINO_D1;		// Pin fuer stepper
	this->dirPin = CONTROLLINO_D2;		// Richtungspin
	this->enblPin = CONTROLLINO_D3;		// Anschalten des Drivers
	this->ExtruderHeizPin = CONTROLLINO_R5;
	this->ExtruderTempVoltagePin = CONTROLLINO_D4;
	this->SetExtruderFanPin = CONTROLLINO_DO1;
	this->ExtruderTempPin = CONTROLLINO_A6;
	this->aktuelleExtruderTemperatur = 0;
	this->newPostion = false;
	this->setDruckbett = false;
	this->setExtruderheizen = false;
	mystepper = AccelStepper(1,pulsePin,dirPin);
}

void ArduinoIO::SetSpeed(float speed)
{
	mystepper.setSpeed(speed);
	delay(20);
	SetOk();
}

void ArduinoIO::SetMoveE(float amount)
{
	int Steps = amount * 409;
	mystepper.move(Steps);
	newPostion = true;
}

void ArduinoIO::SetOk()
{
	Serial.println("OK");
}
void ArduinoIO::Checkfinish(bool move)
{
	if (move == false && newPostion == true)
	{
		SetOk();
		newPostion = false;
	}
}

void ArduinoIO::ExtruderTemperaturRegelung()
{
	this->aktuelleExtruderTemperatur = GetExtruderTemperatur();
	if (zielExtruderTemperatur >= aktuelleExtruderTemperatur+1)
	{
		digitalWrite(ExtruderHeizPin, LOW);
	}
	if (zielExtruderTemperatur <= aktuelleExtruderTemperatur-1)
	{
		digitalWrite(ExtruderHeizPin, HIGH);
	}
}

void ArduinoIO::Initialisieren()
{
	pinMode(pulsePin, OUTPUT);
	pinMode(dirPin, OUTPUT);
	pinMode(enblPin, OUTPUT);
	pinMode(ExtruderHeizPin, OUTPUT);
	pinMode(ExtruderTempVoltagePin, OUTPUT);
	pinMode(ExtruderTempPin, INPUT);
	pinMode(SetExtruderFanPin, OUTPUT);
	digitalWrite(ExtruderTempVoltagePin, HIGH);
	digitalWrite(enblPin, HIGH);
	digitalWrite(dirPin, LOW);
	digitalWrite(SetExtruderFanPin, LOW);
	Serial.begin(9600);
	mystepper.setMaxSpeed(20000);
	mystepper.setAcceleration(5000 * 409);
}

void ArduinoIO::Run()
{
	UpdateSerial();
	mystepper.run();
	bool inBewegung = false;
	inBewegung = mystepper.isRunning();
	Checkfinish(inBewegung);
	ExtruderTemperaturRegelung();
}

void ArduinoIO::UpdateSerial()
{
	if (Serial.available() > 0)
	{
		String choise = Serial.readStringUntil('&');
		String data = Serial.readStringUntil('&');

		if (data != "" && choise != "")
		{
			NewCommand(choise, data);
		}
	}
}

void ArduinoIO::NewCommand(String choise, String data)
{
	if (choise == "G1E")
	{
		SetMoveE(data.toFloat());
	}
	else if (choise == "G1F")
	{
		SetSpeed(data.toFloat());
	}
	else if (choise == "M104")
	{
		SetExtruderTemperatur(data.toFloat());
	}
	else if (choise == "")
	{

	}
}

void ArduinoIO::SetExtruderTemperatur(float Temperatur)
{
	this->zielExtruderTemperatur = Temperatur;
}

float ArduinoIO::GetExtruderTemperatur()
{
	float Temperatur=0;
	int inputValue = analogRead(ExtruderTempPin);
	float Voltage = inputValue * 5/ 1024;
	Serial.println(Voltage);
	return Temperatur;
}