using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day06
{
    public class Part02
    {
        private string[] ReadFile()
        {
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day06/sample-day06.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day06/input-day06.txt");

        }

        private long[] SplitFile()
        {
            string[] input = ReadFile();

            string[] a = input[0].Split(':');
            string[] b = input[1].Split(":");

            long[] timeAndDistance = new long[2]
            {
                Convert.ToInt64(a[1].Replace(" ", "")),
                Convert.ToInt64(b[1].Replace(" ", ""))
            };

            return timeAndDistance;
        }

        public long SumPossibilitiesWin()
        {
            long[] timeAndDistance = SplitFile();

            long possibilities = 0;

            for (long i = 14; i <= 71516; i++)
            {
                long millimeters = (timeAndDistance[0] - i) * i;

                if (millimeters > timeAndDistance[1])
                {
                    possibilities++;
                }
            }

            return possibilities;
        }
    }
}
