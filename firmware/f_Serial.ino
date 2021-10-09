//Comunicação Serial / Comandos


void serialSetup()
{
  Serial.begin(SERIAL_BAUD);
}

unsigned long waitTimeStart;
void waitForData(int timeOut)
{
  waitTimeStart = millis();
  while(!Serial.available())
  {
    if(millis() - waitTimeStart >= timeOut) break;
  }
}


double s_x, s_y, s_z, s_a; //Recebe valores transmitidos por serial

char enAxis;
bool enSignal;

void serialLoop()
{
  if(Serial.available())
  {
    //Todos os comandos começam com uma letra, e terminam com quebra de linha. Ex: S1.0 0.0 0.0/n -> Move eixo X em 1mm
    char c = Serial.read();
    
    
    switch(c)
    {
      //S - Passo incremental - Recebe passo em X, Y e Z.
      case 'S':
        s_x = Serial.parseFloat();
        s_y = Serial.parseFloat();
        s_z = Serial.parseFloat();

        incStepCmd();
      break;

      //P - Posição Absoluta - Recebe pos em X, Y e Z.
      case 'P':
        s_x = Serial.parseFloat();
        s_y = Serial.parseFloat();
        s_z = Serial.parseFloat();

        absStepCmd();
      break;

      //Angulo do suporte de amostra
      case 'A':
        s_a = Serial.parseFloat();
        setSSAngCmd();
      break;


      case 'E':
        waitForData(10);
        enAxis = Serial.read();
        enSignal = Serial.parseInt();

        toggleMotors();
      break;

      //Rotação cte. suporte de amostra.
      case 'R':
        s_a = Serial.parseFloat();
        setSSAngVelCmd();
      break;

      //Emergência - Para todos os movimentos da máquina
      case '!':
        emergencyStop();
      break;

      //Solicita dados atuais / status
      case '?':
          requestData();
      break;

      setSSAngCmd();
    }
  }
}

//S - Passo incremental
void incStepCmd()
{
  Vector newPos = Vector(0,0,0);


  newPos.x = pos.x + s_x;
  newPos.y = pos.y + s_y;
  newPos.z = pos.z + s_z;

  goToPos(Vector(newPos.x, newPos.y, newPos.z));
}

//P - Posição absoluta
void absStepCmd()
{
  goToPos(Vector(s_x, s_y, s_z));
}

//A - Angulo do suporte
void setSSAngCmd()
{
  if(isMoving) return;
  setSampleAng(s_a);
}

//R - Vel. angular do suporte
void setSSAngVelCmd()
{
  setSampleAngVel(s_a);
}

void toggleMotors()
{
  if(enAxis == 'a') enableMotorA(enSignal);

  if(enAxis == 'p') {enableMotorXYZ(enSignal); Serial.println(enSignal);}

  enAxis = ' ';
  sendOK(true);
}

//Envia sinal de OK ao final de uma ação - state representa se a ação foi executada com sucesso
void sendOK(bool state)
{
  if(state) Serial.println('#');
  else Serial.println('*');
  sendInfo();
}


//Envia dados da máquina
void sendInfo()
{
  Serial.print('x'); Serial.println(pos.x);
  Serial.print('y'); Serial.println(pos.y);
  Serial.print('z'); Serial.println(pos.z);
  Serial.print('a'); Serial.println(sampleSupportAng);

  Serial.print("Ep"); Serial.println(isMotorEnabledXYZ);
  Serial.print("Ea"); Serial.println(isMotorEnabledA);

  if(readLimSwitchX(true)) Serial.println("LMX+");
  if(readLimSwitchX(false)) Serial.println("LMX-");

  if(readLimSwitchY(true)) Serial.println("LMY+");
  if(readLimSwitchY(false)) Serial.println("LMY-");

  if(readLimSwitchZ(true)) Serial.println("LMZ+");
  if(readLimSwitchZ(false)) Serial.println("LMZ-");

  sendTemp();
}

void sendTemp()
{
  Serial.print('t'); Serial.println(ambTemp);
}


void emergencyStop()
{
  isMoving = false;
  stepsToDoA = 0;
  constRotA = false;

  enableMotorA(false);
  enableMotorXYZ(false);


  sendOK(true);
}

void requestData()
{
  sendInfo();
}
