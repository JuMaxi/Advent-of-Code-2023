using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day03
{
    public class Part01
    {
        private string[] ReadFile()
        {
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/sample-day03.txt");
            string[] input2 = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/input-day03.txt");

            //return input;

            return input2;
        }

        private int ReceiveInput()
        {
            string[] input = ReadFile();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += TakeCharInput(input, i);
            }

            return sum;
        }

        private int TakeCharInput(string[] input, int i)
        {
            string numbers = "0123456789";
            int sum = 0;
            string n = "";

            for (int ii = 0; ii < input[i].Length; ii++)
            {
                char c = input[i][ii];

                if (numbers.IndexOf(c) >= 0)
                {
                    n += AnaliseIfCharInputIsNumber(c, numbers);

                    int next = 1;
                    next = CheckInputIndexLength(next, ii, input, i);

                    if (CheckNextIndexIsNotANumber(i, ii, input, numbers, next))
                    {
                        sum += AnaliseNextIndexCharInput(input, i, ii, numbers, n, next);
                        n = "";
                    }
                }
            }
            return sum;
        }

        private string AnaliseIfCharInputIsNumber(char c, string numbers)
        {
            string n = "";

            n += Convert.ToString(c);

            return n;
        }

        private int CheckInputIndexLength(int next, int ii, string[] input, int i)
        {
            if (ii == input[i].Length - 1)
            {
                next = 0;
            }
            return next;
        }

        private bool CheckNextIndexIsNotANumber(int i, int ii, string[] input, string numbers, int next)
        {

            if (input[i].IndexOf('.', ii + next, 1) >= 0
                            || next == 0
                            || numbers.IndexOf(input[i][ii + next]) < 0)
            {
                return true;
            }

            return false;
        }
        private int AnaliseNextIndexCharInput(string[] input, int i, int ii, string numbers, string n, int next)
        {
            int sum = 0;

            if (CheckPreviousLineIndexAdjacentsSpecialCharacters(i, ii, n, next, input, numbers))
            {
                sum = Convert.ToInt32(n);
            }
            else
            {
                if (CheckPreviousAndNextIndexSameLineAdjacentsSpecialCharacters(i, ii, n, next, input))
                {
                    sum = Convert.ToInt32(n);
                }
                else
                {
                    if (CheckNextLineIndexAdjacentsSpecialCharacters(i, ii, n, next, input, numbers))
                    {
                        sum = Convert.ToInt32(n);
                    }
                }
            }

            return sum;
        }

        private bool CheckPreviousLineIndexAdjacentsSpecialCharacters(int i, int ii, string n, int next, string[] input, string numbers)
        {
            if (i > 0)
            {
                int t = ii;
                if (ii < n.Length)
                {
                    t = n.Length;
                }
                for (int j = t - n.Length; j <= t + next; j++)
                {
                    if (input[i - 1][j] != '.'
                        && numbers.IndexOf(input[i - 1][j]) < 0)
                    {

                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckPreviousAndNextIndexSameLineAdjacentsSpecialCharacters(int i, int ii, string n, int next, string[] input)
        {
            if (input[i][ii + next] != '.' && input[i].Length - 1 != ii)
            {
                return true;
            }
            if (ii - n.Length > 0)
            {
                if (input[i][ii - n.Length] != '.')
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckNextLineIndexAdjacentsSpecialCharacters(int i, int ii, string n, int next, string[] input, string numbers)
        {
            if (i != input.Length - 1)
            {
                if (ii < n.Length)
                {
                    ii = n.Length;
                }
                for (int j = ii - n.Length; j <= ii + next; j++)
                {
                    if (input[i + 1][j] != '.'
                        && numbers.IndexOf(input[i + 1][j]) < 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int SumParts()
        {
            int sum = ReceiveInput();

            return sum;
        }
    }
}
