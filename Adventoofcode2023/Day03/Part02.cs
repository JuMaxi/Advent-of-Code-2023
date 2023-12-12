using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/sample-day03.txt");
            string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/input-day03.txt");

            return input;
        }

        private int FindCharStarIntoInput(string[] input, int line)
        {
            int number = 0;
            for (int column = 0; column < input[line].Length; column++)
            {
                char c = input[line][column];

                if (c == '*')
                {
                    List<int> numbersAround = GetNumberSurroundingStar(input, line, column);
                    number += MultiplyNumbers(numbersAround);
                }
            }

            return number;
        }

        private int MultiplyNumbers(List<int> numbersAround)
        {
            int number = 0;

            if (numbersAround.Count == 2)
            {
                number = numbersAround[0] * numbersAround[1];
            }

            return number;
        }


        private List<int> GetNumberSurroundingStar(string[] input, int line, int column)
        {
            List<int> result = new();

            int t = 1;

            if (column == 0
                || column == input[line].Length - 1)
            { t = 0; }

            if (line > 0)
            {
                result.Add(GetNumberAtPosition(input, line - 1, column - t));
                result.Add(GetNumberAtPosition(input, line - 1, column));
                result.Add(GetNumberAtPosition(input, line - 1, column + t));
            }

            if (line < input.Length)
            {
                result.Add(GetNumberAtPosition(input, line + 1, column - t));
                result.Add(GetNumberAtPosition(input, line + 1, column));
                result.Add(GetNumberAtPosition(input, line + 1, column + t));
            }

            result.Add(GetNumberAtPosition(input, line, column - t));
            result.Add(GetNumberAtPosition(input, line, column + t));

            result = result.Where(item => item > 0).ToList();
            result = result.Distinct().ToList();

            return result;
        }

        private int GetNumberAtPosition(string[] input, int line, int column)
        {
            if (!char.IsDigit(input[line][column]))
                return 0;

            string number = "";

            while (column > 0 && char.IsDigit(input[line][column - 1]))
                column--;

            while (column < input[line].Length && char.IsDigit(input[line][column]))
            {
                number = number + input[line][column].ToString();
                column++;
            }

            return Convert.ToInt32(number);
        }

        public int SumParts()
        {
            string[] input = ReadFile();
            int sum = 0;

            for (int line = 0; line < input.Length; line++)
            {
                int number = FindCharStarIntoInput(input, line);
                sum += number;
            }

            return sum;
        }
    }
}
