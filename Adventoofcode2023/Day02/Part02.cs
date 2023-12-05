using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day02
{
    public class Part02
    {
        private string[] ReadFile()
        {
            string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day02/sample-day02.txt");
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day02/input-day02.txt");

            return input;
        }

        public int SumPowerSetsCubs()
        {
            string[] input = ReadFile();

            foreach (string l in input)
            {
                string[] s = l.Split(':');
                string[] ss = s[1].Split(";");

                for (int i = 0; i < ss.Length; i++)
                {
                    ss[i] = ss[i].Replace(',', ' ');
                }

                Dictionary<string, int> cubs = new()
                {
                    {"blue", 0 },
                    {"red", 0 },
                    {"green", 0 }
                };

                foreach (string ll in ss)
                {
                    string[] sss = ll.Split(" ");

                    for (int j = 2; j < sss.Length; j = j + 3)
                    {
                        for (int i = 0; i < cubs.Count; i++)
                        {
                            var item = cubs.ElementAt(i);

                            if (sss[j] == item.Key)
                            {
                                int n = Convert.ToInt32(sss[j - 1]);

                                if (n > item.Value)
                                {
                                    cubs[item.Key] = n;
                                }
                                break;
                            }
                        }
                    }
                }

                for(int i = 0; i < cubs.Count; i++)
                {
                    var item = cubs.ElementAt(i);

                    //cubs[item.Key] = (item.Value * 2);
                }

            }
            return 0;
        }
    }
}
