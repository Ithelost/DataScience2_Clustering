﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();

            List<DataPoint> Datapoints = reader.Read();

            KMeans kmeans = new KMeans(5, 100, Datapoints);
            kmeans.Cluster();

            List<Cluster> clusters = kmeans.GetClusters();

            Console.WriteLine($"\nLowest SSE : {kmeans.LowestSSE} \n");
            foreach (Cluster cluster in clusters)
            {
                for (int i = 0; i < cluster.DataPoints.Count; i++)
                {
                    Console.WriteLine($"Klantnr: {cluster.DataPoints[i].Id} cluster {cluster.Id}");
                }
                Console.Write("\n");
            }

            //TopDeals topdeals = new TopDeals(clusters);
            //topdeals.PrintTopDeals();
            Console.ReadLine();
        }

    }
}
