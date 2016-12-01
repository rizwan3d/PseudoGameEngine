using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGameEngine
{
    public static class Random
    {
        public static int Get(int min, int max)
        {
            System.Random r = new System.Random();
            return r.Next(min, max);
        }
        public static double Get(double min, double max)
        {
            System.Random r = new System.Random();
            double rDouble = r.NextDouble() * (max - min) + min;
            return rDouble;
        }
        public static float Get(float min, float max)
        {           
            return (float)Random.Get((double)min, (double)max);
        }

    }
}
