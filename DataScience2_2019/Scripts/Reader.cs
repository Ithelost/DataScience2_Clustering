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
        public List<List<double>> Read()
        {

            StreamReader reader = new StreamReader("C:/Users/jacob/source/repos/DataScience2_2019/DataScience2_2019/resources/WineData.csv");

            List<List<double>> wineData = new List<List<double>>();

            for (int i = 0; i < 100; i++)
            {
                wineData.Add(new List<double>());
            }

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                for (int i = 0; i < 100; i++)
                {
                    wineData[i].Add(double.Parse(values[i]));
                }
            }
            reader.Close();

            return wineData;
        }
    }
}
