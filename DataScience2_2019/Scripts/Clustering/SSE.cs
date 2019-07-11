using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class SSE
    {
        public double Calculate(List<Cluster> _cluster)
        {
            IDistance distance = new Euclidean();

            double sse = 0;

            for(int i = 0; i < _cluster.Count; i++)
            {
                for(int j = 0; j < _cluster[i].DataPoints.Count; j++)
                {
                    sse += distance.Calculate(_cluster[i].Centroid.Position, _cluster[i].DataPoints[j].Position);
                }
            }

            return sse;
        }

    }
}
