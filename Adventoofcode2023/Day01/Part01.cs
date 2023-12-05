using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day01
{
    public class Part01
    {
        private string[] ReadInput()
        {
            string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day01/sample-day01.txt");
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day01/input-day01.txt");

            return input;
        }
        public int Sum()
        {
            string[] input = ReadInput();
            string ns = "0123456789";
            int sum = 0;

            foreach (string line in input)
            {
                string temp = "";

                foreach (char c in line)
                {
                    foreach (char n in ns)
                    {
                        if (c == n)
                        {
                            temp += c;
                        }
                    }
                }

                temp = Convert.ToString(temp[0]) + Convert.ToString(temp[temp.Length - 1]);
                sum += Convert.ToInt32(temp);
            }

            return sum;
        }
    }
}
