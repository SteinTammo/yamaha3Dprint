#include "ArduinoIO.h"


ArduinoIO::ArduinoIO()
{
	this->pulsePin = 2;		// Pin fuer stepper
	this->dirPin = 3;		// Richtungspin
	this->enblPin = 4;		// Anschalten des Drivers
	this->ExtruderHeizPin = 5;
	this->ExtruderTempPin = A0;
	this->aktuelleExtruderTemperatur = 0;
	this->DruckbettTempPin = 1;
	this->zielExtruderTemperatur = 20;
	this->newPostion = false;
	this->setDruckbett = false;
	this->setExtruderheizen = false;
	this->previousMillis = 0;
	this->filterFrequency = 3;
	this->turn = false;
  this->newTemp=false;
	mystepper = AccelStepper(1, pulsePin, dirPin);
	mystepper.setPinsInverted(true, false, false);
	analog1 = ResponsiveAnalogRead(ExtruderTempPin, true);
	lowpassFilterExtruder = FilterOnePole(LOWPASS, filterFrequency);
	lowpassFilterDruckbett = FilterOnePole(LOWPASS, filterFrequency);

}

void ArduinoIO::SetSpeed(float speeed)
{
	float umrechnung;
	umrechnung = speeed/60*100;
	mystepper.setSpeed(speeed);
	delay(100);
	SetOk();
}

void ArduinoIO::SetMoveE(float amount)
{
	if (amount > 0)
	{
		this->turn = true;
	}
	else if (amount < 0)
	{
		this->turn = true;
		mystepper.setSpeed(mystepper.speed() * -1);
	}
	else
	{
		this->turn = false;
	}
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
	this -> aktuelleExtruderTemperatur = GetExtruderTemperatur();
	if (zielExtruderTemperatur >= aktuelleExtruderTemperatur-2)
	{
		digitalWrite(ExtruderHeizPin, HIGH);
	}
	if (zielExtruderTemperatur <= aktuelleExtruderTemperatur+2)
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
	pinMode(DruckbettTempPin, INPUT);
	digitalWrite(ExtruderTempVoltagePin, HIGH);
	digitalWrite(enblPin, HIGH);
	digitalWrite(dirPin, LOW);
	digitalWrite(SetExtruderFanPin, LOW);
	Serial.begin(57600);
	mystepper.setMaxSpeed(50000);
	mystepper.setAcceleration(5000 * 409);
}

void ArduinoIO::Run()
{	
	UpdateSerial();
	if (turn == true)
	{
		mystepper.runSpeed();
	}
	bool inBewegung = false;
	inBewegung = mystepper.isRunning();
	Checkfinish(inBewegung);
	ExtruderTemperaturRegelung();
  if(this->newTemp==true)
  {
    if(this->zielExtruderTemperatur <= this->aktuelleExtruderTemperatur+4 && this->zielExtruderTemperatur >= this->aktuelleExtruderTemperatur-4)
    {      
      SetOk();
      newTemp=false;
    }
  }
	lowpassFilterExtruder.input(analogRead(ExtruderTempPin));
	lowpassFilterDruckbett.input(analogRead(DruckbettTempPin));
 double bitwertNTC = (double)lowpassFilterExtruder.output();
 double v = (double)analogRead(A0)/1024*5;
 //Serial.print(v);
 //Serial.print("    ");
 //Serial.println(GetExtruderTemperatur());
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
		Serial.println(choise+data);
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
	else if (choise == "G92")
	{
		SetZero();
	}
	else if (choise == "GETETEMP")
	{
		Serial.println(GetExtruderTemperatur());
	}
	else if (choise == "GETBTEMP")
	{
		Serial.println(analogRead(DruckbettTempPin));
	}
}
void ArduinoIO::SetZero()
{
	mystepper.setCurrentPosition(0);
	Serial.println("SetZero");
	delay(20);
	SetOk();
}
void ArduinoIO::SetExtruderTemperatur(float Temperatur)
{
	this->zielExtruderTemperatur = Temperatur;
  this->newTemp=true;
}

double ArduinoIO::GetExtruderTemperatur()
{
	double bWert = 4267;
	double widerstand1 = 100000.0;
	double widerstandNTC = 0;
	double kelvintemp = 273.15;
	double Tn = kelvintemp + 25;
	double TKelvin = 0;
	double T = 0;
	double* tempfeld = new double[10];
	double tempsumme=0;
	/*for (int i = 0; i < 10; i++)
	{
		tempfeld[i] = analogRead(ExtruderTempPin);
		delay(10);
		tempsumme += tempfeld[i];
	}
	tempsumme = tempsumme / 10.0;*/
	double bitwertNTC = (double)lowpassFilterExtruder.output();
	widerstandNTC = widerstand1 * (bitwertNTC / 1024) / (1 - bitwertNTC / 1024);

	// berechne den Widerstandswert vom NTC
	TKelvin = 1 / ((1 / Tn) + (1.0 / bWert) * log(widerstandNTC / widerstand1));
  double v = bitwertNTC/1024*5;
	// ermittle die Temperatur in Kelvin
	T = TKelvin - kelvintemp;                    // ermittle die Temperatur in �C
  T= 2.4295*pow(v,3)+0.9599*pow(v,2)+228*v-257.99;
  return T;
}
