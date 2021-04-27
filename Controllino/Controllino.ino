#include <Controllino.h>
void setup() {
  // put your setup code here, to run once:
  pinMode(CONTROLLINO_AI12,INPUT);
  pinMode(CONTROLLINO_R5,OUTPUT);
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
}
