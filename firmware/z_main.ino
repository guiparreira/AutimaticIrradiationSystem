//Arquivo principal

void setup()
{
  pinSetup(); //Configura pinos

  enableMotorA(false);
  enableMotorXYZ(false);
  
  serialSetup();//Configura porta serial

  temperatureSetup(); //Configura sensor temperatura
  
  sendOK(true);
}


void loop()
{
  serialLoop();
  motorLoop();

  if(!isMoving) temperatureLoop();
}
