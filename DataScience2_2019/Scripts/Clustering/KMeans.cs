using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class KMeans
    {
        private int numClusters;
        private int iterations;

        List<DataPoint> dataPoints = new List<DataPoint>();
        List<Centroid> centroids = new List<Centroid>();
        List<Cluster> clusters = new List<Cluster>();

        List<Cluster> lowestSSEClusters = new List<Cluster>();
        private double lowestSSE = Double.MaxValue;

        public KMeans(int _numClusters, int _iterations, List<DataPoint> _points)
        {
            numClusters = _numClusters;
            iterations = _iterations;
            dataPoints = _points;
        }

        public double LowestSSE { get => lowestSSE; set => lowestSSE = value; }

        public void Cluster()
        {
            SetupClusters();
            for (int i = 0; i < iterations; i++)
            {
                FindNearestCluster();
                SaveClusters(i);
                UpdateCentroids();
            }
        }
        private void SetupClusters()
        {
            centroids = SetCentroids();

            for (int i = 0; i < centroids.Count; i++)
            {
                clusters.Add(new Cluster(i, centroids[i]));
            }
        }

        public List<Centroid> SetCentroids()
        {
            List<Centroid> centroids = new List<Centroid>();
            Random random = new Random();

            int dimension = dataPoints[1].Position.Length;

            for (int i = 0; i < numClusters; i++)
            {
                centroids.Add(new Centroid(i, dimension, random));
            }
            return centroids;
        }

        public void FindNearestCluster()
        {
            EmptyClusterPoints();
            IDistance distance = new Euclidean();

            for (int i = 0; i < dataPoints.Count; i++)
            {
                List<double> distances = new List<double>();

                for (int j = 0; j < clusters.Count; j++)
                {
                    distances.Add(distance.Calculate(dataPoints[i].Position, clusters[j].Centroid.Position));
                }
                int clusterIndex = distances.IndexOf(distances.Min());
                clusters[clusterIndex].DataPoints.Add(dataPoints[i]);
            }
        }

        private void UpdateCentroids()
        {
            SSE sse = new SSE();
            for (int i = 0; i < clusters.Count; i++)
            {
                //Console.WriteLine("cluster size" + clusters[i].DataPoints.Count + "");

                double[] pos = new double[dataPoints[0].Position.Length];
                for (int j = 0; j < clusters[i].DataPoints.Count; j++)
                {
                    for (int k = 0; k < clusters[i].DataPoints[j].Position.Length; k++)
                    {
                        pos[k] += clusters[i].DataPoints[j].Position[k];
                    }
                }
                clusters[i].Centroid.Position = CalcAvgEachIndex(pos);
            }
        }

        private double[] CalcAvgEachIndex(double[] _newCentroidPoints)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < _newCentroidPoints.Length; i++)
            {
                result.Add(_newCentroidPoints[i] / _newCentroidPoints.Length);
            }
            return result.ToArray();
        }

        private void EmptyClusterPoints()
        {
            for (int i = 0; i < clusters.Count; i++)
            {
                clusters[i].DataPoints.Clear();
            }
        }

        private void SaveClusters(int i)
        {
            double sse = new SSE().Calculate(clusters);
            Console.WriteLine("Save cluster: " + $"{i} SSE : {sse}");
            if (sse < lowestSSE)
            {
                lowestSSE = sse;
                lowestSSEClusters = clusters;
            }
        }
       
        public List<Cluster> GetClusters()
        {
            return clusters;
        }
    }
}
