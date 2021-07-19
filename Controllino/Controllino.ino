#include <Controllino.h>
void setup() {
  // put your setup code here, to run once:
  pinMode(CONTROLLINO_AI12,INPUT);
  pinMode(CONTROLLINO_R5,OUTPUT);
  pinMode(CONTROLLINO_AI13,INPUT);
  pinMode(CONTROLLINO_R4,OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(analogRead(CONTROLLINO_AI12)>500)
  {    
    digitalWrite(CONTROLLINO_R5,HIGH);
  }
  else
  {
    digitalWrite(CONTROLLINO_R5,LOW);
  }  
  if(analogRead(CONTROLLINO_AI13)>500)
  {
    digitalWrite(CONTROLLINO_R4,HIGH);
  }
  else
  {
    digitalWrite(CONTROLLINO_R4,LOW);
  }
}
