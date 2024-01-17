using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Adventoofcode2023.Day11
{
    public class Part01
    {
        private string[] ReadFile()
        {
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day11/sample-day11.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day11/input-day11.txt");

        }

        private List<string> CosmicExpansion()
        {
            string[] input = ReadFile();

            List<string> expandedUniverse = DoubleEmptyLines(input);

            expandedUniverse = DoubleEmptyColumns(input, expandedUniverse);

            return expandedUniverse;
        }

        private List<string> DoubleEmptyColumns(string[] input, List<string> expandedUniverse)
        {
            List<int> columns = LocalizeEmptyColumns(input);

            for (int column = 0; column < columns.Count; column++)
            {
                for (int line = 0; line < expandedUniverse.Count; line++)
                {
                    string newLine = expandedUniverse[line].Substring(columns[column] + column);

                    expandedUniverse[line] = expandedUniverse[line].Substring(0, columns[column] + column) + '.' + newLine;
                }
            }

            return expandedUniverse;
        }
        private List<string> DoubleEmptyLines(string[] input)
        {
            List<int> lines = LocalizeEmptyLines(input);

            List<string> expandedUniverse = new();

            for (int line = 0; line < input.Length; line++)
            {
                expandedUniverse.Add(input[line]);

                if (lines.Contains(line))
                {
                    expandedUniverse.Add(input[line]);
                }
            }
            return expandedUniverse;
        }
        private List<int> LocalizeEmptyLines(string[] input)
        {
            List<int> lines = new();

            for (int line = 0; line < input.Length; line++)
            {
                if (!input[line].Contains('#'))
                {
                    lines.Add(line);
                }
            }
            return lines;
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

        private List<(int, int)> IdentifyPositionGalaxies()
        {
            List<(int line, int column)> positions = new();
            
            List<string> expandedUniverse = CosmicExpansion();

            int newColumn = 0;

            for (int line = 0; line < expandedUniverse.Count; line++)
            {
                if (expandedUniverse[line].Substring(newColumn).Contains('#'))
                {
                    (int l, int c) p;
                    p.l = line;
                    p.c = expandedUniverse[line].Substring(newColumn).IndexOf('#');

                    if(positions.Count > 0 && positions[positions.Count-1].line == line)
                    {
                        p.c = p.c + positions[positions.Count-1].column + 1;
                    }

                    newColumn = p.c + 1;
                    line--;

                    positions.Add(p);
                }
                else
                {
                    newColumn = 0;
                }
            }

            return positions;
        }
        public int SumShortestPathBetweenGalaxies()
        {   
            List<(int, int)> positions = IdentifyPositionGalaxies();

            int sum = 0;

            for(int line = 0; line < positions.Count; line++)
            {
                for(int peer = line + 1; peer < positions.Count; peer++)
                {
                    int differenceLine = positions[peer].Item1 - positions[line].Item1;
                    int differenceColumn = positions[peer].Item2- positions[line].Item2;

                    if(differenceColumn < 0)
                    {
                        differenceColumn = positions[line].Item2 - positions[peer].Item2;
                    }

                    sum += differenceLine + differenceColumn;
                }
            }

            return sum;
        }

    }
}
