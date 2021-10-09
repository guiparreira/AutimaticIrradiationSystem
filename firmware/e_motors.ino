//Controle dos motores de passo

boolean dirX = false, dirY = false, dirZ = false, dirA = false; //Direção - Sentido positivo - true ; Sentido negativo - false

ulVector sPath; //Vetor de frequencia de passos

ulVector stepCounter; //Contabiliza passos para controle dos motores (por eixo)

ulVector auxStepCounter; //Contador de passo auxiliar - usado para contabilizar percursos interrompidos

bool isMoving = false; //True = Há um movimento em andamento

unsigned long stepCount = 0; //Contabiliza ciclo de passos total
unsigned long stageStepCount = 0; //Contabiliza ciclos de passo do estagio
int movStage = 0; //0 - aceleração; 1-  vel. cte.; 2 - desaceleração

unsigned long maxSteps = 0; // Quantidade de passos do eixo principal (PASSOS)
double maxLen = 0; //Tamanho da maior componente (mm) (USADO PARA CALCULO DAS VELOCIDADES MÁXIMAS, SEM RELAÇÃO COM O EIXO PRINCIPAL)

unsigned long lastTimeStep = 0; //Tempo do ultimo ciclo de passos

unsigned long movStartTime = 0; //Tempo de início do movimento
unsigned long stageMovStartTime = 0; //Tempo de início do estágio do movimento

double princSpmm = 0; //Passos por mm referente ao eixo principal

unsigned long lastTimeMotorEnabled = 0; //Tempo referente a ultima vez que motores se moveram

//Suporte de amostra (EIXO A)

unsigned long lastTimeStepA = 0; //Tempo do ultimo passo (Eixo A)

unsigned long stepDelayA = 0; //Delay entre passos, eixo A

unsigned long stepsToDoA = 0; //Passos restantes

bool constRotA = false;
float constRotVel = 0;


//Liga/Desliga motor A
void enableMotorA(bool en)
{
  digitalWrite(enablePinA, !en);
  isMotorEnabledA = en;
  
  if(en) lastTimeMotorEnabled = millis();
}

//Liga/Desliga motores XYZ
void enableMotorXYZ(bool en)
{
  digitalWrite(enablePinXYZ, !en);
  isMotorEnabledXYZ = en;

  if(en) lastTimeMotorEnabled = millis();
}


//Funções de passo - retornam false se fim de curso for acionado para aquela direção
bool stepX()
{
  if(readLimSwitchX(dirX)) return false;
  
  digitalWrite(pinStepX, 1);
  delayMicroseconds(stepPulseDur);
  digitalWrite(pinStepX, 0);

  auxStepCounter.x++;
  return true;
}

bool stepY()
{
  if(readLimSwitchY(dirY)) return false;
  
  digitalWrite(pinStepY, 1);
  delayMicroseconds(stepPulseDur);
  digitalWrite(pinStepY, 0);

  auxStepCounter.y++;
  return true;
}

bool stepZ()
{
  if(readLimSwitchZ(dirZ)) return false;
  
  digitalWrite(pinStepZ, 1);
  delayMicroseconds(stepPulseDur);
  digitalWrite(pinStepZ, 0);

  auxStepCounter.z++;
  return true;
}

void stepA()
{
  digitalWrite(pinStepA, 1);
  delayMicroseconds(stepPulseDur);
  digitalWrite(pinStepA, 0);
}

// ====================================================================================================================

double maxVel; //Velocidade máxima - PRECISA SER ATUALIZADO A TODA CHAMADA DA FUNC GoToPos()

unsigned long na, nc, nd; //Passos em aceleração, vel. cte., e desaceleração


void goToPos(struct Vector targetPos)
{
  Vector path = targetPos.copy(); //Vetor path (percurso) representa caminho a ser percorrido (em mm)
  path.sub(pos);
  
  //Obtém direção dos motores de acordo com o sinal do vetor path
  dirX = (path.x > 0);
  dirY = (path.y > 0);
  dirZ = (path.z > 0);

  //Verifica se o fim de curso está acionado para a direção do movimento
  if(path.x != 0 && readLimSwitchX(dirX)) {sendOK(false); return;}
  if(path.y != 0 && readLimSwitchY(dirY)) {sendOK(false); return;}
  if(path.z != 0 && readLimSwitchZ(dirZ)) {sendOK(false); return;}

  path.x = abs(path.x);
  path.y = abs(path.y);
  path.z = abs(path.z);

  //Vetor percurso (em passos)
  sPath.x = round(path.x * spmmXY);
  sPath.y = round(path.y * spmmXY);
  sPath.z = round(path.z * spmmZ);

  maxSteps = sPath.maxVal();

  double maxComp = path.maxVal();

  //Cálculo da velocidade máxima para o movimento
  if(path.x == maxComp) maxVel = maxVelX;
  if(path.y == maxComp) maxVel = maxVelY;
  if(path.z == maxComp) maxVel = maxVelZ;
  

  Vector velVec = Vector(path.x, path.y, path.z); //Vetor velocidade máxima
  velVec.norm();
  velVec.mult(1/velVec.maxVal());
  velVec.mult(maxVel);
  
  if(velVec.x > maxVelX) velVec.mult(maxVelX / velVec.x);
  if(velVec.y > maxVelY) velVec.mult(maxVelY / velVec.y);
  if(velVec.z > maxVelZ) velVec.mult(maxVelZ / velVec.z);


   //Cálculo do step/mm do eixo principal / maxVe,
  if(sPath.x == maxSteps) { princSpmm = spmmXY; maxVel = velVec.x;}
  if(sPath.y == maxSteps) { princSpmm = spmmXY; maxVel = velVec.y;}
  if(sPath.z == maxSteps) { princSpmm = spmmZ; maxVel = velVec.z;}

  

  stepCounter = ulVector(0,0,0);

  na = round((maxVel*maxVel*princSpmm)/(2*maxAcc)); // (n = v² * s / 2a)
  nd = round((maxVel*maxVel*princSpmm)/(2*maxDec)); // (n = v² * s / 2a)

  //Perfil 1 - Atinge vel. max
  if(maxSteps > na + nd)
  {
    nc = maxSteps - na - nd;
  }
  else //Perfil 2 - Não atige vel. max
  {
    nc = 0;

    na = round(maxSteps/(1+maxAcc/maxDec));
    nd = maxSteps - na;
  }
  
  stepCount = 0;
  stageStepCount = 0;
  movStage = 0;
  auxStepCounter.zero();

  lastTimeStep = 0;
  isMoving = true;
  movStartTime = micros();
  stageMovStartTime = micros();
  lastTimeStep = 0;

  lastPos = pos.copy();
  pos = targetPos.copy();

  //Configura pinos de direção
  digitalWrite(pinDirX, dirX^invertDirX);
  digitalWrite(pinDirY, dirY^invertDirY);
  digitalWrite(pinDirZ, dirZ^invertDirZ);

  enableMotorXYZ(true);
}


/*
 * A função motorLoop() é responsável por executar os ciclos de passos.
 * Em todo movimento linear, o eixo com maior distancia a ser percorrida (Eixo principal) anda um passo a cada ciclo
 * Os demais eixos dão passos a cada n numeros de ciclos.
 * O vetor stepCounter armazena a quantidade de passos do eixo principal
 */

double nextStepTimeSqr; //Tempo para próximo passo (stageStepCount+1 ou n+1)
double lastStepDelaySqr = 0;
bool needUpdateNextStepTime = true;

double mTimeSec; //Calcula tempo atual em segundos (referente ao início do estágio do movimento)
double mTimeSecSqr; //Este tempo ao quadrado

bool limSwitchDetected = false;


void motorLoop()
{
  if(isMoving)
  {
    mTimeSec = (micros() - stageMovStartTime) / 1.0E6; //Calcula tempo atual em segundos (referente ao início do estágio do movimento)
    mTimeSecSqr = mTimeSec*mTimeSec;
    
    limSwitchDetected = false;
    
    if(needUpdateNextStepTime)
    {
      if(movStage == 0)
      { 
        if(stageStepCount == na)
        {
          if(nc != 0) movStage = 1;
          else
          {
            movStage = 2;
            maxVel = sqrt((2 * na * maxAcc)/princSpmm); //   v² = (2.a.n) / s
          }
          stageStepCount = 0;
          stageMovStartTime = micros();
          
          return;
        }
        
        nextStepTimeSqr = (2 * (stageStepCount+1))/(maxAcc*princSpmm); //  at²/2 = n/s (t isolado)
      }
      else if(movStage == 1)
      {
        if(stageStepCount == nc)
        {
          movStage = 2;
          stageStepCount = 0;
          stageMovStartTime = micros();
          
          return;
        }
        
        nextStepTimeSqr = pow((stageStepCount+1)/(princSpmm*maxVel), 2);
      }
      else if(movStage == 2)
      {
        double delta = maxVel*maxVel - 2.0*maxDec*((stageStepCount+1.0)/princSpmm); //-at²/2 + vt = n/s (t isolado) 
        nextStepTimeSqr = (maxVel - sqrt(max(delta, 0.0)))/maxDec;
        
        nextStepTimeSqr = pow(nextStepTimeSqr, 2);

        if(stepCount == maxSteps)
        {
          isMoving = false;

          sendOK(true);
          return;
        }
      }

      needUpdateNextStepTime = false;
      lastStepDelaySqr = nextStepTimeSqr - mTimeSecSqr;
    }


    //Aguarda tempo para o próximo passo
    if((mTimeSecSqr) >= nextStepTimeSqr)
    {
      needUpdateNextStepTime = true;
      stepCounter.add(sPath);

      if(stepCounter.x >= maxSteps)
      {
        stepCounter.x -= maxSteps;
        if(!stepX()) limSwitchDetected = true;
      }

      if(stepCounter.y >= maxSteps)
      {
        stepCounter.y -= maxSteps;
        if(!stepY()) limSwitchDetected = true;
      }

      if(stepCounter.z >= maxSteps)
      {
        stepCounter.z -= maxSteps;
        if(!stepZ()) limSwitchDetected = true;
      }

      //Fim de curso detectado - Aborta o movimento
      if(limSwitchDetected)
      {
        isMoving = false;

        Vector deltaPos = Vector(auxStepCounter.x / spmmXY, auxStepCounter.y / spmmXY, auxStepCounter.z / spmmZ); //Trecho percorrido até o momento
        
        if(!dirX) deltaPos.x *= -1;
        if(!dirY) deltaPos.y *= -1;
        if(!dirZ) deltaPos.z *= -1;
        
        pos = lastPos.copy();
        pos.add(deltaPos);
        
        sendOK(false);
        return;
      }

      stepCount++;
      stageStepCount++;
      
      lastTimeStep = micros();
    }
  }

  //Eixo A
  if(stepsToDoA > 0 || constRotA)
  {
    if(micros() - lastTimeStepA >= stepDelayA)
    {
      stepA();
      lastTimeStepA = micros();

      if(!constRotA)
      {
        stepsToDoA--;
        if(stepsToDoA == 0) sendOK(true);
      }
    }
  }

  //Desabilitar motor caso fique muito tempo parado, para evitar aquecimento
  if(lastTimeMotorEnabled != 0 && millis() - lastTimeMotorEnabled >= (idleTimeMotorDisable*1000))
  {
    lastTimeMotorEnabled = 0;

    enableMotorXYZ(false);
    enableMotorA(false);
    sendInfo();
  }
  
}


  //Eixo A

  //Definir ângulo
  void setSampleAng(float targetAng)
  {
    float angDif = targetAng - sampleSupportAng;
    dirA = (angDif > 0); if(invertDirA) dirA = !dirA;

    stepsToDoA = abs(angDif * spDegA);
    
    stepDelayA = round((double) 1E6/(spDegA*maxAngVelA));

    sampleSupportAng = targetAng;

    lastTimeStepA = 0;

    digitalWrite(pinDirA, dirA^invertDirA);

    enableMotorA(true);
  }

  //Definir velocidade angular - Suporte de amostra
  void setSampleAngVel(float angVel)
  {
    if(angVel == 0.0)
    {
      constRotA = false;
      return;
    }
    
    dirA = (angVel > 0); if(invertDirA) dirA = !dirA;

    stepDelayA = round((double) 1E6 / (spDegA*angVel));

    lastTimeStepA = 0;

    constRotA = true;

    digitalWrite(pinDirA, dirA);

    enableMotorA(true);

    sendOK(true);
  }
