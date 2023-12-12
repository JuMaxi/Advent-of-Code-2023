using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day04
{
    public class Part01
    {
        private string[] ReadFile()
        {
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day04/sample-day04.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day04/input-day04.txt");

        }

        private int SplitCards()
        {
            string[] input = ReadFile();

            int sum = 0;

            foreach(string line in input)
            {
                string[] a = line.Split("|");
                string[] winningNumbers = a[0].Split(" ");
                string[] myNumbers = a[1].Split(" ");

                winningNumbers = winningNumbers.Where(item =>  item != "").ToArray();
                myNumbers = myNumbers.Where(item => item != "").ToArray();

                int number = GetWorthNumbers(winningNumbers, myNumbers);
                sum += number;
            }
            return sum;
        }

        private int GetWorthNumbers(string[] winningNumbers, string[] myNumbers)
        {
            int number = 1;
            int t = 0;
            for(int i = 2; i < winningNumbers.Length; i++)
            {
                for(int ii = 0; ii < myNumbers.Length; ii++)
                {
                    if (winningNumbers[i] == myNumbers[ii])
                    {
                        t++;

                        if(t > 1)
                        {
                            number = number * 2;
                        }
                    }
                }
            }
            if(t == 0) { number = 0; }

            return number;
        }
        
        public int SumCards()
        {
            int sum = SplitCards();

            return sum;
        }
    }
}
