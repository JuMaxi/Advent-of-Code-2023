using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day05
{
    public class Part02
    {
        private string[] ReadFile()
        {
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day05/sample-day05.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day05/input-day05.txt");

        }
        private long SplitFile()
        {
            string[] input = ReadFile();
            input = input.Where(item => item != "").ToArray();

            string[] s = input[0].Split(":");
            string[] seeds = s[1].Split(" ");
            seeds = seeds.Where(item => item != "").ToArray();

            long location = CheckIfLineIsDigit(input, seeds);

            return location;
        }

        private long CheckIfLineIsDigit(string[] input, string[] seeds)
        {
            long location = long.MaxValue;
            List<List<long>> rangesLong = GetNumbersFromInput(input);

            for (long i = 0; i < seeds.Length - 1; i += 2)
            {
                long seedLong = 0;
                long seedInitial = Convert.ToInt64(seeds[i]);
                long seedFinal = seedInitial + Convert.ToInt64(seeds[i + 1]);

                for (long ii = seedInitial; ii < seedFinal; ii++)
                {
                    seedLong = ii;

                    for (int line = 2; line < input.Length; line++)
                    {
                        if (char.IsDigit(input[line][0]))
                        {
                            if (seedLong >= rangesLong[line][1]
                                && seedLong < rangesLong[line][1] + rangesLong[line][2])
                            {
                                seedLong = GetUpdatedNumberSeed(rangesLong, seedLong, line);

                                bool skipSuccessful = false;
                                for (int k = line + 1; k < input.Length; k++)
                                {
                                    if (char.IsLetter(input[i][0]))
                                    {
                                        line = k;
                                        skipSuccessful = true;
                                        break;
                                    }
                                }
                                if (!skipSuccessful)
                                    line = input.Length - 1;
                            }
                        }
                    }
                    location = Math.Min(location, seedLong);
                }
            }
            return location;
        }

        private static List<List<long>> GetNumbersFromInput(string[] input)
        {
            List<List<long>> rangesLong = new(input.Length);
            for (int line = 0; line < input.Length; line++)
            {
                if (!string.IsNullOrWhiteSpace(input[line]) && char.IsDigit(input[line][0]))
                {
                    List<long> ranger = input[line].Split(" ").Select(str => Convert.ToInt64(str)).ToList();
                    rangesLong.Add(ranger);

                }
                else
                {
                    rangesLong.Add(new());
                }
            }

            return rangesLong;
        }

        private static long GetUpdatedNumberSeed(List<List<long>> rangesLong, long seedLong, int line)
        {
            long n = 0;

            if (rangesLong[line][1] >= rangesLong[line][0])
            {
                n = rangesLong[line][1] - rangesLong[line][0];
                seedLong -= n;
            }
            else
            {
                n = rangesLong[line][0] - rangesLong[line][1];
                seedLong += n;
            }

            return seedLong;
        }

        public long GetLowestLocation()
        {
            return SplitFile();
        }
    }
}

