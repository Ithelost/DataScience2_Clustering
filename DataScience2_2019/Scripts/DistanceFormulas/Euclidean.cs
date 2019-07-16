using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class Euclidean : IDistance
    {
        public double Calculate(double[] p, double[] q)
        {
            double val = 0;

            for (int i = 0; i < p.Length; i++)
            {
                val += (p[i] - q[i]) * (p[i] - q[i]);
            }

            double dis = Math.Sqrt(val);
            return dis;
        }
    }
}
