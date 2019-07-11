using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    interface IDistance
    {
        double Calculate(double[] p, double[] q);
    }
}
