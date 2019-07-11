using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DataScience2_2019.Scripts
{
    class Cluster
    {
        private List<DataPoint> dataPoints;

        public Cluster(int _id, Centroid _centroid)
        {
            Id = _id;
            Centroid = _centroid;
            dataPoints = new List<DataPoint>();
        }

        public Centroid Centroid { get; set; }
        public int Id { get; set; }
        public List<DataPoint> DataPoints { get => dataPoints; set => dataPoints = value; }
        public double SSE { get; set; }
    }
}