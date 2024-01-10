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

        public int SumShortestPathBetweenGalaxies()
        {
            List<string> expandedUniverse = CosmicExpansion();


            return 0;
        }

    }
}
