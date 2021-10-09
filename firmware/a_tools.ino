//  =========  Ferramentas - Classes e funções úteis ==========

void sendOK(bool state);
void sendInfo(void);
void sendTemp(void);

//Vetor 3D (double)
struct Vector
{
  double x, y, z;

  Vector(double _x = 0, double _y = 0, double _z = 0)
  {
    x = _x;
    y = _y;
    z = _z;
  }

  //Retorna modulo do vetor
  double mag()
  {
    return (sqrt(x*x + y*y + z*z));
  }

  //Normaliza o vetor
  void norm()
  {
    double m = mag();
    
    x = x/m;
    y = y/m;
    z = z/m;
  }

  //Soma vetor com outro vetor v
  void add(Vector v)
  {
    x += v.x;
    y += v.y;
    z += v.z;
  }

  //Subtrai vetor v do vetor
  void sub(Vector v)
  {
    x -= v.x;
    y -= v.y;
    z -= v.z;
  }

  //Multiplica por escalar
  void mult(float a)
  {
    x *= a;
    y *= a;
    z *= a;
  }

  //Divide por escalar
  void div(float a)
  {
    x /= a;
    y /= a;
    z /= a;
  }

  Vector copy()
  {
    return Vector(x, y, z);
  }

  double maxVal()
  {
    double val = x;
    //if(x > val) val = x;
    if(y > val) val = y;
    if(z > val) val = z;

    return val;
  }

  //debug
  void print()
  {
    Serial.print("x");
    Serial.print(x);
    Serial.print(" y");
    Serial.print(y);
    Serial.print(" z");
    Serial.println(z);
  }

  
};

//Vetor  - unsigned long
struct ulVector
{
  unsigned long x = 0;
  unsigned long y = 0;
  unsigned long z = 0;
  
  ulVector(unsigned long _x, unsigned long _y, unsigned long _z)
  {
    x = _x;
    y = _y;
    z = _z;
  }

  ulVector()
  {

  }
  
  void add(ulVector v)
  {
    x += v.x;
    y += v.y;
    z += v.z;
  }

  //Zera o vetor
  void zero()
  {
    x = 0;
    y = 0;
    z = 0;
  }

  //Retorna valor do maior componente
  unsigned long maxVal()
  {
    unsigned long val = 0;
    if(x > val) val = x;
    if(y > val) val = y;
    if(z > val) val = z;

    return val;
  }

  ulVector copy()
  {
    return ulVector(x, y, z);
  }

  void print()
  {
    Serial.print("x");
    Serial.print(x);
    Serial.print(" y");
    Serial.print(y);
    Serial.print(" z");
    Serial.println(z);
  }
};

//Retorna maior valor - tipo unsig long
unsigned long ulMax(unsigned long a, unsigned long b)
{
  if(a > b) return a;
  else return b;
}
