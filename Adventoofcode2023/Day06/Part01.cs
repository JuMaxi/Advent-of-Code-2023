using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day06
{
    public class Part01
    {
        private string[] ReadFile()
        {
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day06/sample-day06.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day06/input-day06.txt");

        }

        private int SplitFile()
        {
            string[] input = ReadFile();

            string[] a = input[0].Split(':');
            string[] time = a[1].Split(" ");
            time = time.Where(item => item != "").ToArray();

            int[] timeInt = ConvertDigits(time);

            string[] b = input[1].Split(":");
            string[] distance = b[1].Split(" ");
            distance = distance.Where(item => item != "").ToArray();

            int[] distanceInt = ConvertDigits(distance);

            int multiply = SumPossibilitiesWin(timeInt, distanceInt);

            return multiply;
        }

        private static int SumPossibilitiesWin(int[] timeInt, int[] distanceInt)
        {
            int multiply = 1;

            for (int i = 0; i < timeInt.Length; i++)
            {
                int possibilities = 0;

                for (int ii = 0; ii <= timeInt[i]; ii++)
                {
                    int millimeters = (timeInt[i] - ii) * ii;

                    if (millimeters > distanceInt[i])
                    {
                        possibilities++;
                    }
                }

                multiply *= possibilities;
            }
            return multiply;
        }

        public int[] ConvertDigits(string[] digits)
        {
            int[] ints= new int[digits.Length];

            for(int i = 0; i < digits.Length;i++)
            {
                ints[i] = Convert.ToInt32(digits[i]);
            }

            return ints;
        }


        public int MultiplyPossibilities()
        {
            int multiply = SplitFile();
            return multiply;
        }
    }
}
