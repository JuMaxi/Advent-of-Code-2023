using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day01
{
    internal class Part02
    {
        private string[] ReadInput()
        {
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day01/sample-day01-part02.txt");
            string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day01/input-day01.txt");

            return input;
        }

        public int Sum()
        {
            string[] input = ReadInput();

            int sum = 0;

            Dictionary<string, string> numbers = new()
            {
                {"1", "one" },
                {"2", "two"},
                {"3", "three"},
                {"4", "four"},
                {"5", "five"},
                {"6", "six"},
                {"7", "seven"},
                {"8", "eight"},
                {"9", "nine"}
            };

            foreach (string line in input)
            {
                string temp = "";
                int start = 0;

                while (start <= line.Length)
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        var item = numbers.ElementAt(i);

                        if (start + item.Value.Length <=  line.Length)
                        {
                            if (line.Substring(start, item.Value.Length) == item.Value)
                            {
                                temp += Convert.ToString(i + 1);
                                break;
                            }
                        }
                        if(start + 1 <= line.Length)
                        {
                            if(line.Substring(start, 1) == item.Key)
                            {
                                temp += Convert.ToString(i + 1);
                                break;
                            }
                        }
                    }
                    start++;
                }
                temp = Convert.ToString(temp[0]) + Convert.ToString(temp[temp.Length - 1]);
                sum += Convert.ToInt32(temp);
            }

            return sum;
        }
    }
}
