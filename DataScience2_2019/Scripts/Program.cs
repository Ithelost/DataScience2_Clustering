
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

            List<DataPoint> Datapoints = reader.getDataPoints();

            KMeans kmeans = new KMeans(3, 100, Datapoints);
            kmeans.Cluster();

            List<Cluster> clusters = kmeans.GetClusters();

            Console.WriteLine($"\n Lowest SSE : {kmeans.LowestSSE} \n");

            foreach (Cluster cluster in clusters)
            {
                Console.WriteLine($"Printing a cluster");
                for (int i = 0; i < cluster.DataPoints.Count; i++)
                {
                    Console.WriteLine($"Klantnr: {cluster.DataPoints[i].Id} cluster id {cluster.Id}");
                }
                Console.Write("\n");
            }

            TopDeals topdeals = new TopDeals(clusters);
            topdeals.PrintTopDeals();
            Console.ReadLine();
        }

    }
}
