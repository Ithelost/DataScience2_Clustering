using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class TopDeals
    {
        List<Cluster> clusters;

        public TopDeals(List<Cluster> _clusters)
        {
            clusters = _clusters;
        }

        public void PrintTopDeals()
        {
            for (int i = 0; i < clusters.Count; i++)
            {
                //create empty list with the same amount of items
                List<double> countProducts = new List<double>();
                for (int items = 0; items < 33; items++)
                {
                    countProducts.Add(0);
                }

                for (int j = 0; j < clusters[i].DataPoints.Count; j++)
                {
                    for (int k = 0; k < clusters[i].DataPoints[j].Position.Length; k++)
                    {
                        if (clusters[i].DataPoints[j].Position[k].Equals(1))
                        {
                            countProducts[k] = countProducts[k] + 1;
                        }
                    }
                }

                // sort list
                countProducts.Sort((x, y) => y.CompareTo(x));


                Console.WriteLine($"cluster: {i + 1}");
                for (int product = 0; product < countProducts.Count; product++)
                {
                    Console.WriteLine($"Offer {product} bought: {countProducts[product]}  times");
                }
            }
        }
    }
}
