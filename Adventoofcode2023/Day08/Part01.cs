using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day08
{
    public class Part01
    {
        private string[] ReadFile()
        {
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day08/sample-day08.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day08/sample2-day08.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day08/input-day08.txt");

        }

        private Dictionary<string, List<string>> SplitFile()
        {
            string[] input = ReadFile();

            Dictionary<string, List<string>> nodes = new();

            for (int line = 2; line < input.Length; line++)
            {
                string[] path = input[line].Split('=');
                path[0] = path[0].Trim();
                string[] nn = path[1].Split(",");

                List<string> node = new()
                {
                    nn[0].Replace('(', ' ').Trim(),
                    nn[1].Replace(')', ' ').Trim()
                };

                nodes.Add(path[0], node);
            }
            return nodes;
        }

        public long SumSteps()
        {
            string[] OriginalInput = ReadFile();
            string directions = OriginalInput[0];

            Dictionary<string, List<string>> nodes = SplitFile();
            long sum = 0;

            var key = "AAA";

            for (int charDirections = 0; charDirections < directions.Length; charDirections++)
            {
                int whereToGo = 0;
                if (directions[charDirections] == 'R') { whereToGo = 1; }

                var nextNode = nodes[key][whereToGo];
                key = nextNode;
                sum++;

                if(key == "ZZZ")
                {
                    break;
                }
                else
                {
                    if(charDirections == directions.Length - 1)
                    {
                        charDirections = -1;
                    }
                }
            }
            return sum;
        }
    }
}
