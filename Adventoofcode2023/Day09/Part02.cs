﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day09
{
    public class Part02
    {
        private static string[] ReadFile()
        {
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day09/sample-day09.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day09/input-day09.txt");

        }

        private static List<List<long>> SplitFile()
        {
            string[] input = ReadFile();
            List<List<long>> histories = new();

            foreach (string line in input)
            {
                string[] actualLine = line.Split(" ");
                List<long> h = new();

                foreach (string l in actualLine)
                {
                    h.Add(Convert.ToInt64(l));
                }
                histories.Add(h);
            }
            return histories;
        }

        private long ProcessHistory()
        {
            List<List<long>> histories = SplitFile();

            long resultFinal = 0;

            foreach (List<long> list in histories)
            {
                List<long> newLongs = new();
                List<List<long>> newHistories = new();
                newHistories.Add(list);

                int indexList = 0;
                int line = 0;

                while (newHistories[newHistories.Count - 1].Any(item => item != 0))
                {
                    newLongs.Add(newHistories[line][indexList + 1] - newHistories[line][indexList]);

                    indexList++;

                    if (newLongs.Count == newHistories[line].Count - 1)
                    {
                        indexList = 0;

                        newHistories.Add(newLongs);

                        line++;

                        newLongs = new();
                    }
                }

                resultFinal += FillPlaceHolders(newHistories);
            }

            return resultFinal;
        }

        private long FillPlaceHolders(List<List<long>> newHistories)
        {
            long result = 0;

            for (int line = newHistories.Count - 1; line >= 0; line--)
            {
                newHistories[line].Insert(0, result);

                if (line > 0)
                {
                    result = newHistories[line-1][0] - newHistories[line][0];
                }
            }

            return result;
        }
        public long SumExtrapolatedValues()
        {
            long result = ProcessHistory();

            return result;
        }
    }
}
