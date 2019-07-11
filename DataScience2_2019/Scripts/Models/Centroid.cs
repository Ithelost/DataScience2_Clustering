using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class Centroid
    {
        Random random;

        public Centroid(int _id, int _dim, Random _random)
        {
            Id = _id;
            Dimension = _dim;
            random = _random;
            Position = CreatePosition(); ;
        }

        private double[] CreatePosition()
        {
            List<double> positions = new List<double>();

            for (int i = 0; i < Dimension; i++)
            {
                int pos = random.Next(0, 2);
                positions.Add(pos);
            }
            return positions.ToArray();
        }

        public double Dimension { get; set; }
        public double Id { get; set; }
        public double[] Position { get; set; }
    }
}
