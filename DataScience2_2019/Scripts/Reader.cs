using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience2_2019.Scripts
{
    class Reader
    {
        List<List<double>> wineData = new List<List<double>>();

        public List<DataPoint> getDataPoints()
        {
            List<DataPoint> datapoints = new List<DataPoint>();

            if (wineData.Count < 100) Read();
            foreach (List<double> customer in wineData)
            {
                List<double> pos = new List<double>();
                for (int i = 0; i < customer.Count; i++)
                {
                    pos.Add(customer[i]);
                }
                datapoints.Add(new DataPoint(wineData.IndexOf(customer), pos.ToArray()));
            }

            return datapoints;
        }

        public void Read()
        {
            StreamReader reader = new StreamReader("C:/Users/jacob/source/repos/DataScience2_2019/DataScience2_2019/resources/WineData.csv");

            for (int i = 0; i < 100; i++)
            {
                wineData.Add(new List<double>());
            }

            List<DataPoint> datapoints = new List<DataPoint>();
            int iteration = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                for (int i = 0; i < values.Length; i++)
                {
                    wineData[i].Add(double.Parse(values[i]));
                }
                iteration += 1;
            }
            reader.Close();
        }
    }
}
