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
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day10/sample1-day10.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day10/sample2-day10.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day10/input-day10.txt");

        }


        private long ProcessFile()
        {
            string[] input = ReadFile();

            long number = 0;

            for (int line = 0; line < input.Length; line++)
            {
                int column = input[line].IndexOf('S');
                if (column >= 0)
                {
                    number = GetSumSorroundingS(input, (line, column));
                    break;
                }
            }

            return number / 2;
        }

        private string[] ChangeMySToCorrectDigitForLoop(string[] input, int line)
        {
            //char myS = 'F';
            char myS = 'J';


            input[line] = input[line].Replace('S', myS);

            return input;
        }

        private long GetSumSorroundingS(string[] input, (int line, int column) start)
        {
            input = ChangeMySToCorrectDigitForLoop(input, start.line);

            (int line, int column) next = start;
            (int line, int column) last = (0, 0);

            long number = 0;

            while (true)
            {
                char token = input[next.line][next.column];
                var nextPossiblePositions = GetPositionsForChar(token, next);

                if (nextPossiblePositions[0] == last)
                {
                    last = next;
                    next = nextPossiblePositions[1];
                }
                else
                {
                    last = next;
                    next = nextPossiblePositions[0];
                }
                number++;

                if (next == start)
                    break;
            }


            return number;
        }

        private List<(int line, int column)> GetPositionsForChar(char digit, (int line, int column) position)
        {
            if (digit == '7')
            {
                return new List<(int line, int column)>()
                    {
                        (position.line + 1, position.column),
                        (position.line, position.column - 1)
                    };
            }
            if(digit == '|')
            {
                return new List<(int line, int column)>()
                {
                    (position.line + 1, position.column),
                    (position.line - 1, position.column)
                };
            }
            if(digit == '-')
            {
                return new List<(int line, int column)>()
                {
                    (position.line, position.column + 1),
                    (position.line, position.column - 1)
                };
            }
            if(digit == 'L')
            {
                return new List<(int line, int column)>()
                {
                    (position.line - 1, position.column),
                    (position.line, position.column + 1)
                };
            }
            if(digit == 'J')
            {
                return new List<(int line, int column)>()
                {
                    (position.line - 1, position.column),
                    (position.line, position.column - 1)
                };
            }
            if(digit == 'F')
            {
                return new List<(int line, int column)>()
                {
                    (position.line + 1, position.column),
                    (position.line, position.column + 1)
                };
            }
            throw new Exception();
        }

        public long Sum()
        {
            return ProcessFile();
        }
    }



}
