#include "ArduinoIO.h"


ArduinoIO::ArduinoIO()
{
	this->pulsePin = CONTROLLINO_D1;		// Pin fuer stepper
	this->dirPin = CONTROLLINO_D2;		// Richtungspin
	this->enblPin = CONTROLLINO_D3;		// Anschalten des Drivers
	this->ExtruderHeizPin = CONTROLLINO_R5;
	this->ExtruderTempVoltagePin = CONTROLLINO_D4;
	this->SetExtruderFanPin = CONTROLLINO_DO0;
	this->ExtruderTempPin = CONTROLLINO_A1;
	this->aktuelleExtruderTemperatur = 0;
	this->zielExtruderTemperatur = 30;
	this->newPostion = false;
	this->setDruckbett = false;
	this->setExtruderheizen = false;
	mystepper = AccelStepper(1,pulsePin,dirPin);
	mystepper.setAcceleration(10000);
  
}

void ArduinoIO::SetSpeed(float speed)
{
	mystepper.setMaxSpeed(speed);
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
		digitalWrite(ExtruderHeizPin, HIGH);
	}
	if (zielExtruderTemperatur <= aktuelleExtruderTemperatur-1)
	{
		digitalWrite(ExtruderHeizPin, LOW);
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
	digitalWrite(enblPin, LOW);
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
 Serial.println(analogRead(ExtruderTempPin));
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
	double bWert = 4267; 
	double widerstand1 = 100000.0;
	double widerstandNTC = 0;
	double kelvintemp = 273.15;                
	double Tn = kelvintemp + 25;                 
	double TKelvin = 0;                        
	double T = 0;                              
	double* tempfeld = new double[100];
	/*for (int i = 0; i < 100; i++)
	{
		tempfeld[i] = (double)analogRead(ExtruderTempPin);
	}
	double bitwertNTC = 0;
	for (int i = 0; i < 100; i++)
	{
		bitwertNTC += tempfeld[i];
	}
	bitwertNTC = bitwertNTC / 100;*/
	double bitwertNTC = (double)analogRead(ExtruderTempPin);
	widerstandNTC = widerstand1 * (bitwertNTC/1024)/(1-bitwertNTC/1024);

	// berechne den Widerstandswert vom NTC
	TKelvin = 1 / ((1 / Tn) + (1.0 / bWert) * log(widerstandNTC / widerstand1));

	// ermittle die Temperatur in Kelvin
	T = TKelvin - kelvintemp;                    // ermittle die Temperatur in �C

	Serial.println(widerstandNTC);
	return T;
}
