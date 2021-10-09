using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoDif
{



    //Classe Vetor 3D
    public class Vector3D
    {
        public double x, y, z;

        public Vector3D(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3D copy()
        {
            return new Vector3D(x, y, z);
        }

        public void add(Vector3D v)
        {
            x += v.x;
            y += v.y;
            z += v.z;
        }
        public void sub(Vector3D v)
        {
            x -= v.x;
            y -= v.y;
            z -= v.z;
        }

        public void mult(double d)
        {
            x *= d;
            y *= d;
            z *= d;
        }

        double mag()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
    }
}
