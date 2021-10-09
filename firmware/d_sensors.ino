//Sensores fim de curso - São conectados em posição NC (Normalmente Fechado), com sinal conectado em +5V. (Apesar do microcontrolador trabalhar com 3.3V, as portas escolhidas são tolerantes a +5V)

bool readLimSwitchX(bool dir)
{
  if(disableLimitSwitch) return false;
  
  if(dir) return !digitalRead(limitSwitchMaxX); //Sentido Positivo
  else    return !digitalRead(limitSwitchMinX); //Sentido Negativo
}

bool readLimSwitchY(bool dir)
{
  if(disableLimitSwitch) return false;
  
  if(dir) return !digitalRead(limitSwitchMaxY); //Sentido Positivo
  else    return !digitalRead(limitSwitchMinY); //Sentido Negativo
}

bool readLimSwitchZ(bool dir)
{
  if(disableLimitSwitch) return false;
  
  if(dir) return !digitalRead(limitSwitchMaxZ); //Sentido Positivo
  else    return !digitalRead(limitSwitchMinZ); //Sentido Negativo

}


/*
 * 
 * Sensor de temperatura BMP180
 * 
 * Biblioteca utilizada: BMP180_BREAKOUT
 * Autor: Sparkfun
 * 
 * A biblioteca será implementada e modificada diretamente neste arquivo.
 * 
 * As modificações são adaptações para o microcontrolador STM32 / I2C
 * 
 * 
  */

class SFE_BMP180
{
  public:
    SFE_BMP180(); // base type

    bool begin();
    char startTemperature(void);
    char getTemperature(double &T);
    char getError(void);

  private:
  
    char readInt(char address, int16_t &value);
    char readUInt(char address, uint16_t &value);
    char readBytes(unsigned char *values, char length);    
    char writeBytes(unsigned char *values, char length);
      
    int16_t AC1,AC2,AC3,VB1,VB2,MB,MC,MD;
    uint16_t AC4,AC5,AC6; 
    double c5,c6,mc,md,x0,x1,x2,y0,y1,y2,p0,p1,p2;
    char _error;
};

#define BMP180_ADDR 0x77 // 7-bit address

#define BMP180_REG_CONTROL 0xF4
#define BMP180_REG_RESULT 0xF6

#define BMP180_COMMAND_TEMPERATURE 0x2E
#define BMP180_COMMAND_PRESSURE0 0x34
#define BMP180_COMMAND_PRESSURE1 0x74
#define BMP180_COMMAND_PRESSURE2 0xB4
#define BMP180_COMMAND_PRESSURE3 0xF4


SFE_BMP180::SFE_BMP180()
{
}

bool SFE_BMP180::begin()
{
  double c3,c4,b1;

     
  Wire.begin();
  
  if (readInt(0xAA,AC1) &&
    readInt(0xAC,AC2) &&
    readInt(0xAE,AC3) &&
    readUInt(0xB0,AC4) &&
    readUInt(0xB2,AC5) &&
    readUInt(0xB4,AC6) &&
    readInt(0xB6,VB1) &&
    readInt(0xB8,VB2) &&
    readInt(0xBA,MB) &&
    readInt(0xBC,MC) &&
    readInt(0xBE,MD))
  {


    c3 = 160.0 * pow(2,-15) * AC3;
    c4 = pow(10,-3) * pow(2,-15) * AC4;
    b1 = pow(160,2) * pow(2,-30) * VB1;
    c5 = (pow(2,-15) / 160) * AC5;
    c6 = AC6;
    mc = (pow(2,11) / pow(160,2)) * MC;
    md = MD / 160.0;
    x0 = AC1;
    x1 = 160.0 * pow(2,-13) * AC2;
    x2 = pow(160,2) * pow(2,-25) * VB2;
    y0 = c4 * pow(2,15);
    y1 = c4 * c3;
    y2 = c4 * b1;
    p0 = (3791.0 - 8.0) / 1600.0;
    p1 = 1.0 - 7357.0 * pow(2,-20);
    p2 = 3038.0 * 100.0 * pow(2,-36);
    return true;
  }
  else
  {
    return false;
  }
}


char SFE_BMP180::readInt(char address, int16_t &value)
{
  unsigned char data[2];

  data[0] = address;
  if (readBytes(data,2))
  {
    value = (int16_t)((data[0]<<8)|data[1]);
    return(1);
  }
  value = 0;
  return(0);
}

char SFE_BMP180::readUInt(char address, uint16_t &value)
{
  unsigned char data[2];

  data[0] = address;
  if (readBytes(data,2))
  {
    value = (((uint16_t)data[0]<<8)|(uint16_t)data[1]);
    return(1);
  }
  value = 0;
  return(0);
}


char SFE_BMP180::readBytes(unsigned char *values, char length)
{
  char x;

  Wire.beginTransmission(BMP180_ADDR);
  Wire.write(values[0]);
  _error = Wire.endTransmission();
  if (_error == 0)
  {
    Wire.requestFrom(BMP180_ADDR,length);
    while(Wire.available() != length) ; // wait until bytes are ready
    for(x=0;x<length;x++)
    {
      values[x] = Wire.read();
    }
    return(1);
  }
  return(0);
}


char SFE_BMP180::writeBytes(unsigned char *values, char length)
{
  char x;
  
  Wire.beginTransmission(BMP180_ADDR);
  Wire.write(values,length);
  _error = Wire.endTransmission();
  if (_error == 0)
    return(1);
  else
    return(0);
}


char SFE_BMP180::startTemperature(void)
{
  unsigned char data[2], result;
  
  data[0] = BMP180_REG_CONTROL;
  data[1] = BMP180_COMMAND_TEMPERATURE;
  result = writeBytes(data, 2);
  if (result)
    return(5);
  else
    return(0);
}

char SFE_BMP180::getTemperature(double &T)
{
  unsigned char data[2];
  char result;
  double tu, a;
  
  data[0] = BMP180_REG_RESULT;

  result = readBytes(data, 2);
  if (result) // good read, calculate temperature
  {
    tu = (data[0] * 256.0) + data[1];
    
    a = c5 * (tu - c6);
    T = a + (mc / (a + md));
  }
  return(result);
}


char SFE_BMP180::getError(void)
{
  return(_error);
}

//=========================================== FIM BIBLIOTECA ================================================

//Sensor temperatura (BMP180)

SFE_BMP180 BMP180;
bool tempStarted = false; //Indica se o sensor foi iniciado corretamente

unsigned long lastTimeTempRead = 0;

//Lê a temperatura
double readTemp()
{
  if(!tempStarted) return 999;
  int status = BMP180.startTemperature();
  if (status != 0)
  {
    delay(status);
    double T;
    status = BMP180.getTemperature(T);

    return T;
  }
  else
  {
    return 998;
  }
}

void temperatureSetup()
{
  tempStarted = BMP180.begin();
}

void temperatureLoop()
{
  if(micros() - lastTimeTempRead >= readTempTime*1E6)
  {
   // BMP180.begin();
    ambTemp = readTemp();
    sendTemp();
    lastTimeTempRead = micros();
  }
}
