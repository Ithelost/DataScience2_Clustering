using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class DataPoint
    {
        public DataPoint(double _Id, double[] _pos)
        {
            Id = _Id;
            Position = _pos;
        }

        public double Id { get; set; }
        public double[] Position { get; set; }
    }
}
