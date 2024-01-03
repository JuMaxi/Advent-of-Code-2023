using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day10
{
    public class Part01
    {
        private string[] ReadFile()
        {
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day10/sample1-day10.txt");
        }

        
        private long ProcessFile()
        {
            string[] input = ReadFile();

            List<long> numbers = new();

            for (int line = 0; line < input.Length; line++)
            {
                int column = input[line].IndexOf('S');
                if (column >= 0)
                {
                    int newLine = line;
                    int newColumn = column;

                    numbers = GetSumSorroundingS(input, column, newColumn - 1, line, newLine, numbers);
                    numbers = GetSumSorroundingS(input, column, newColumn + 1, line, newLine, numbers);
                    numbers = GetSumSorroundingS(input, column, newColumn, line, newLine + 1, numbers);
                    numbers = GetSumSorroundingS(input, column, newColumn, line, newLine - 1, numbers);
                }
            }

            return numbers.Max();
        }

        private List<long> GetSumSorroundingS(string[] input, int column, int newColumn, int line, int newLine, List<long> sums)
        {
            long number = 0;

            while(input[newLine][newColumn] != '.')
            {
                if (column > newColumn && input[newLine][newColumn] == 'L'
                    || column > newColumn && input[newLine][newColumn] == 'J'
                    || newLine < line && input[newLine][newColumn] == '|')
                {
                    newLine--;
                }
                else
                {
                    if(column < newColumn && input[newLine][newColumn] == '7'
                        || column < newColumn && input[newLine][newColumn] == 'F'
                        || newLine > line && input[newLine][newColumn] == '|')
                    {
                        newLine++;
                    }
                    else
                    {
                        if(input[newLine][newColumn] == 'J'
                            || input[newLine][newColumn] == '7'
                            || column > newColumn && input[newLine][newColumn] == '-')
                        {
                            newColumn--;
                        }
                        else
                        {
                            if(input[newLine][newColumn] == 'L'
                                || input[newLine][newColumn] == 'F'
                                || column < newColumn && input[newLine][newColumn] == '-')
                            {
                                newColumn++;
                            }
                        }
                    }
                }
                number++;
            }
            sums.Add(number);

            return sums;
        }

        public long Sum()
        {
            ProcessFile();
            return 0;
        }
    }
}
