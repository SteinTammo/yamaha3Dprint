#include "ArduinoIO.h"


ArduinoIO::ArduinoIO()
{
	this->pulsePin = 2;		// Pin fuer stepper
	this->dirPin = 3;		// Richtungspin
	this->enblPin = 4;		// Anschalten des Drivers
	this->ExtruderHeizPin = 5;
  this->DruckbettHeizPin =6;
	this->ExtruderTempPin = A0;
	this->aktuelleExtruderTemperatur = 0;
  this->aktuelleDruckbettTemperatur = 0;
	this->DruckbettTempPin = 1;
	this->zielExtruderTemperatur = 20;
  this->zielDruckbettTemperatur = 20;
	this->newPostion = false;
	this->setDruckbett = false;
	this->setExtruderheizen = false;
	this->previousMillis = 0;
	this->filterFrequency = 3;
	this->turn = false;
  this->newBTemp=false;
  this->newETemp=false;
	mystepper = AccelStepper(1, pulsePin, dirPin);
	mystepper.setPinsInverted(true, false, false);
	analog1 = ResponsiveAnalogRead(ExtruderTempPin, true);
  analog2 = ResponsiveAnalogRead(DruckbettTempPin, true);
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

void ArduinoIO::DruckbettTemperaturRegelung()
{
  this->aktuelleDruckbettTemperatur = GetDruckbettTemperatur();
  if (zielDruckbettTemperatur >= aktuelleDruckbettTemperatur-2)
  {
    digitalWrite(DruckbettHeizPin, HIGH);
  }
  if (zielDruckbettTemperatur <= aktuelleDruckbettTemperatur+2)
  {
    digitalWrite(DruckbettHeizPin, LOW);
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
  //DruckbettTemperaturRegelung();
  if(this->newETemp==true)
  {
    if((this->zielExtruderTemperatur <= this->aktuelleExtruderTemperatur+4 && this->zielExtruderTemperatur >= this->aktuelleExtruderTemperatur-4))
    {      
      SetOk();
      newETemp=false;
    }
  }
  if(this->newBTemp==true)
  {
    if((this->zielDruckbettTemperatur <= this->aktuelleDruckbettTemperatur+4 && this->zielDruckbettTemperatur >= this->aktuelleDruckbettTemperatur-4))
    {      
      SetOk();
      newBTemp=false;
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
    Serial.println(choise+data);
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
		Serial.println(GetDruckbettTemperatur());
	}
  else if(choise == "M190")
  {
    SetDruckbettTemperatur(data.toFloat());
    Serial.println(choise+data);
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
  this->newETemp=true;
}
void ArduinoIO::SetDruckbettTemperatur(float Temperatur)
{
 this->zielDruckbettTemperatur = Temperatur;
  this->newBTemp=true;
}

double ArduinoIO::GetExtruderTemperatur()
{
	double T = 0;	
	double bitwertNTC = (double)lowpassFilterExtruder.output();
  double v = bitwertNTC/1024*5;
  T= 2.4295*pow(v,3)+0.9599*pow(v,2)+228*v-257.99;
  return T;
}
double ArduinoIO::GetDruckbettTemperatur()
{
  double T = 0;  
  double bitwertNTC = (double)lowpassFilterDruckbett.output();
  double v = bitwertNTC/1024*5;
  T= 2.4295*pow(v,3)+0.9599*pow(v,2)+228*v-257.99;
  T=85.0;
  return T;
}
