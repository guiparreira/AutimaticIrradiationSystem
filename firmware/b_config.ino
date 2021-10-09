//  ======= Principais configurações =======


//Pinos
/*

PB12  LimitSwitchX+
PB13  LimitSwitchX-
PB14  LimitSwitchY+
PB15  LimitSwitchY- 
PA8   LimitSwitchZ+
PA9   SERIAL(TX) - FTDI(RX)
PA10  SERIAL(RX) - FTDI(TX)
PA11  LimitSwitchZ-
PA12  
PA15  
PB3   
PB4   
PB5   
PB6   
PB7   
PB8  //SCL (I2C)
PB9  //SDA (I2C)
PB11  
PB10  
PB1   DirX
PB0   StepX
PA7   DirY
PA6   StepY
PA5   DirZ
PA4   StepZ
PA3   DirA
PA2   StepA
PA1   EnableXYZ
PA0   EnableA
*/

#define pinDirX PB1
#define pinStepX PB0

#define pinDirY PA7
#define pinStepY PA6

#define pinDirZ PA5
#define pinStepZ PA4

#define pinDirA PA3
#define pinStepA PA2

#define enablePinXYZ PA1
#define enablePinA PA0

#define limitSwitchMaxX PB12
#define limitSwitchMinX PB13

#define limitSwitchMaxY PB14
#define limitSwitchMinY PB15

#define limitSwitchMaxZ PA8
#define limitSwitchMinZ PA11

#define pinSDA PB9
#define pinSCL PB8


#define disableLimitSwitch false

//Configura todos os pinos
void pinSetup()
{
  pinMode(pinDirX, OUTPUT);
  pinMode(pinDirY, OUTPUT);
  pinMode(pinDirZ, OUTPUT);
  pinMode(pinDirA, OUTPUT);

  pinMode(pinStepX, OUTPUT);
  pinMode(pinStepY, OUTPUT);
  pinMode(pinStepZ, OUTPUT);
  pinMode(pinStepA, OUTPUT);

  pinMode(enablePinXYZ, OUTPUT);
  pinMode(enablePinA, OUTPUT);
  
  pinMode(limitSwitchMinX, INPUT_PULLDOWN);
  pinMode(limitSwitchMaxX, INPUT_PULLDOWN);

  pinMode(limitSwitchMinY, INPUT_PULLDOWN);
  pinMode(limitSwitchMaxY, INPUT_PULLDOWN);

  pinMode(limitSwitchMinZ, INPUT_PULLDOWN);
  pinMode(limitSwitchMaxZ, INPUT_PULLDOWN);

  //Configura pinos I2C
  Wire.setSCL(pinSCL);
  Wire.setSDA(pinSDA);

}

//======================================================

#define SERIAL_BAUD 115200

#define stepPulseDur 1 //Microssegundos


//Config de microstepping - (1, 2, 4, 8, 16 e 32)
#define uStepXY 32
#define uStepZ 16
#define uStepA 32

#define leadScrewStep 8 //Avanço do fuso (EIXO Z

//Passos por milímetro dos motores de passo
const double spmmXY = 5*uStepXY;
const double spmmZ = 360/((1.8/uStepZ) * leadScrewStep);

const double spDegA = (1/1.8)*uStepA; //Passo por grau

//Máxima velocidade - mm/s
#define maxVelX 30
#define maxVelY 30
#define maxVelZ 30

#define maxAcc 100 //Máx. aceleração (mm/s²)
#define maxDec 100 //Máx. desaceleração (mm/s²)

//Eixo A
#define maxAngVelA 15 //Máx. velocidade angular do suporte de amostra (º/s)

//Inverter direção motor
#define invertDirX true
#define invertDirY true
#define invertDirZ false
#define invertDirA false

//Tempo de inatividade para desabilitar motores XYZ (segundos)
#define idleTimeMotorDisable 20

//Intervalo de medição de temp. (s)
#define readTempTime 5
