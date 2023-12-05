using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day02
{
    public class Part01
    {
        private string[] ReadFile()
        {
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day02/sample-day02.txt");
            string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day02/input-day02.txt");

            return input;
        }



        public int SumPossibleIds()
        {
            int sum = 0;

            Dictionary<int, string> cubs = new()
            {
                {12, "red" },
                {13, "green" },
                {14, "blue" }
            };

            string[] input = ReadFile();

            foreach (string line in input)
            {
                string[] g = line.Split(':');
                string[] s = g[1].Split(";");

                bool possible = true;

                for (int i = 0; i < s.Length; i++)
                {
                    string[] ss = s[i].Split(" ");

                    for(int iii = 2; iii < ss.Length; iii = iii + 2)
                    {
                        for (int ii = 0; ii < cubs.Count; ii++)
                        {
                            var item = cubs.ElementAt(ii);

                            if (item.Value.Contains(ss[iii].Substring(0, ss[iii].Length-2)))
                            {
                                int n = Convert.ToInt32(ss[iii-1]);

                                if (n > item.Key)
                                {
                                    possible = false;
                                }
                                break;
                            }
                        }
                        
                    }
                    if (!possible)
                    {
                        break;
                    }
                }
                if (possible)
                {
                    sum += Convert.ToInt32(g[0].Substring(5));
                }
            }
            return sum;
        }
    }
}
