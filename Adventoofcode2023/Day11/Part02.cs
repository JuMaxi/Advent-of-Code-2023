using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day11
{
    public class Part02
    {
        private string[] ReadFile()
        {
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day11/sample-day11.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day11/input-day11.txt");

        }

        private List<(long, long)> IdentifyPositionGalaxies()
        {
            string[] input = ReadFile();

            List<(long line, long column)> positions = new();

            int newColumn = 0;
            int expandedLine = 0;

            //int expansion = 2;
            //int expansion = 10;
            //int expansion = 100;
            int expansion = 1000_000;

            List<int> emptyColumns = LocalizeEmptyColumns(input);

            for (int line = 0; line < input.Length; line++)
            {
                if (input[line].Substring(newColumn).Contains('#'))
                {
                    (long l, long c) p;

                    p.l = line + (expandedLine * expansion) - expandedLine;
                    p.c = input[line].Substring(newColumn).IndexOf('#') + newColumn;

                    int expandedColumn = SumEmptyColumnsBeforeActualColumn(p.c, emptyColumns);

                    if(newColumn < input[line].Length)
                    {
                        newColumn = Convert.ToInt32(p.c + 1);
                    }

                    p.c += (expandedColumn * expansion) - expandedColumn;

                    if (input[line].Substring(newColumn).Contains('#'))
                    {
                        line--;
                    }
                    else
                    {
                        newColumn = 0;
                    }

                    positions.Add(p);
                }
                else
                {
                    if (!input[line].Contains('#'))
                    {
                        expandedLine++;
                    }
                }
            }

            return positions;
        }

        private int SumEmptyColumnsBeforeActualColumn(long column, List<int> emptyColumns)
        {
            int expandedColumn = 0;

            foreach (int c in emptyColumns)
            {
                if (column > c)
                {
                    expandedColumn++;
                }
            }
            return expandedColumn;
        }

        private List<int> LocalizeEmptyColumns(string[] input)
        {
            int column = 0;

            List<int> columns = new();

            while (column < input[0].Length)
            {
                bool galaxy = false;

                for (int line = 0; line < input.Length; line++)
                {
                    if (input[line][column] == '#')
                    {
                        galaxy = true;
                        break;
                    }
                }

                if (galaxy == false)
                {
                    columns.Add(column);
                }

                column++;
            }
            return columns;
        }

        public long SumShortestPathBetweenGalaxies()
        {
            List<(long, long)> positions = IdentifyPositionGalaxies();

            long sum = 0;

            for (int line = 0; line < positions.Count; line++)
            {
                for (int peer = line + 1; peer < positions.Count; peer++)
                {
                    long differenceLine = positions[peer].Item1 - positions[line].Item1;
                    long differenceColumn = positions[peer].Item2 - positions[line].Item2;

                    if (differenceColumn < 0)
                    {
                        differenceColumn = positions[line].Item2 - positions[peer].Item2;
                    }

                    sum += differenceLine + differenceColumn;
                }
            }

            return sum;
            //final result is: 644248339497
        }
    }
}
