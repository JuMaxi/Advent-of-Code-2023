using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventoofcode2023.Day08
{
    public class Part02
    {
        private string[] ReadFile()
        {
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day08/sample-day08-part02.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day08/input-day08.txt");

        }
        private Dictionary<string, List<string>> SplitFile(string[] input)
        {
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

        private List<string> FindNodesEndedWithA(Dictionary<string, List<string>> nodes)
        {
            List<string> nodesEndA = new();
            foreach(string key in nodes.Keys)
            {
                if (key.EndsWith('A'))
                {
                    nodesEndA.Add(key);
                }
            }
            return nodesEndA;
        }
        private List<long> SumStepsNodesEndedA()
        {
            string[] input = ReadFile();
            string directions = input[0];

            Dictionary<string, List<string>> nodes = SplitFile(input);

            List<string> nodesEndA = FindNodesEndedWithA(nodes);

            List<long> sumNodes = new();


            for (int indexNodesEndA = 0; indexNodesEndA < nodesEndA.Count; indexNodesEndA++)
            {
                long sum = 0;

                for (int charDirections = 0; charDirections < directions.Length; charDirections++)
                {
                    int whereToGo = 0;
                    if (directions[charDirections] == 'R') { whereToGo = 1; }

                    string key = nodesEndA[indexNodesEndA];

                    var nextNode = nodes[key][whereToGo];

                    nodesEndA[indexNodesEndA] = nextNode;

                    sum++;

                    if (nextNode.EndsWith('Z'))
                    {
                        break;
                    }
                    else
                    {
                        if (charDirections == directions.Length - 1)
                        {
                            charDirections = -1;
                        }
                    }
                }
                sumNodes.Add(sum);
            }
            
            return sumNodes;
        }

        private List<long> FindDivisibleNumbers()
        {
            List<long> sumNodes = SumStepsNodesEndedA();
            List<long> divisibleNumbers = new();

            for(int line = 0; line < sumNodes.Count; line++)
            {
                int i = 2;
                while (sumNodes[line] > 1)
                {
                    if (sumNodes[line] % i == 0)
                    {
                        if (!divisibleNumbers.Contains(i))
                        {
                            divisibleNumbers.Add(i);
                        }
                        sumNodes[line] = sumNodes[line] / i;
                    }
                    i++;
                }
                
            }
            return divisibleNumbers;    
        }

        public long SumMMCDivisibleNumbers()
        {
            List<long> divisibleNumbers = FindDivisibleNumbers();

            long mmc = 1;

            foreach(long number in divisibleNumbers)
            {
                mmc *= number;
            }
            
            return mmc;
        }
    }
}
