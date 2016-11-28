using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGameEngine.math
{
    public static class Math
    {
        public static float DegreeToRadian(float angle)
        {
            return (float)System.Math.PI * angle / 180.0f;
        }
        public static float RadianToDegree(float angle)
        {
            return angle * (180.0f / (float)System.Math.PI );
        }

        public static float PI { get { return (float)System.Math.PI; } }
    }
}
