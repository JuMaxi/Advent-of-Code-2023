using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Adventoofcode2023.Day03
{
    public class Part02
    {
        private string[] ReadFile()
        {
            string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/sample-day03.txt");
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/input-day03.txt");

            return input;
        }

        private int ReceiveInput()
        {
            string[] input = ReadFile();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum = TakeCharInput(input, i, 0);
            }

            return sum;
        }

        private int TakeCharInput(string[] input, int i, int index)
        {
            string numbers = "0123456789";
            int sum = 0;
            string n = "";

            for (int ii = index; ii < input[i].Length; ii++)
            {
                char c = input[i][ii];

                if (c == '*')
                {
                    int p = FindNumberPreviousLine(i, ii, input, numbers);
                }
            }
            return sum;
        }



        private int CheckPreviousLineIndexAdjacentsSpecialCharacters(int i, int ii, string[] input, string numbers)
        {
            if (i > 0)
            {
                if (numbers.IndexOf(input[i - 1][ii-1]) >= 0)
                {
                    return -1;
                }
                else
                {
                    if (numbers.IndexOf(input[i - 1][ii + 1]) >= 0)
                    {
                        return 1;
                    }
                    else
                    {
                        if(numbers.IndexOf(input[i - 1][ii]) >= 0)
                        {
                            return 0;
                        }
                    }
                }
            }
            return -2;
        }
        private int FindNumberPreviousLine(int i, int ii, string[] input, string numbers)
        {
            int previousNumber = 0;
            int p = CheckPreviousLineIndexAdjacentsSpecialCharacters(i, ii, input, numbers);

            if(p == 0 )
            {
                return input[i - 1][ii];
            }
            else
            {
                if(p != -2)
                {
                    p = p + ii;
                    string number = "";

                    if (numbers.IndexOf(input[i - 1][ii]) >= 0)
                    {
                        number = Convert.ToString(input[i - 1][ii]);
                    }

                    while (p >= 0 && p < input[i - 1].Length
                        && numbers.IndexOf(input[i - 1][p]) >= 0)
                    {

                        if (p < ii) 
                        {
                            string last = Convert.ToString(numbers.IndexOf(input[i - 1][p]));
                            number = last + number;
                        }
                        else
                        {
                            number += Convert.ToString(numbers.IndexOf(input[i - 1][p]));
                        }
                        
                        p = p < ii ? p - 1 : p + 1;
                    }
                    previousNumber = Convert.ToInt32(number);
                }
                
            }

            return previousNumber;
        }
        


        public int SumParts()
        {
            int sum = ReceiveInput();

           


            return sum;
        }
    }
}
