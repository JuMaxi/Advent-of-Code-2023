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
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day05/sample-day05.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day05/input-day05.txt");

        }
        private List<long> SplitFile()
        {
            string[] input = ReadFile();
            input = input.Where(item => item != "").ToArray();

            string[] s = input[0].Split(":");
            string[] seeds = s[1].Split(" ");
            seeds = seeds.Where(item => item != "").ToArray();

            List<long> locations = CheckIfLineIsDigit(input, seeds);

            return locations;
        }

        private List<long> CheckIfLineIsDigit(string[] input, string[] seeds)
        {
            List<long> locations = new();

            for (long i = 0; i < seeds.Length - 1; i += 2)
            {
                long seedLong = 0;

                for (long ii = 0; ii < Convert.ToInt64(seeds[i + 1]); ii++)
                {
                    seedLong = Convert.ToInt64(seeds[i]) + ii;

                    for (int line = 2; line < input.Length; line++)
                    {
                        if (char.IsDigit(input[line][0]))
                        {
                            string[] ranges = input[line].Split(" ");
                            long[] rangesLong = new long[ranges.Length];

                            for (int j = 0; j < ranges.Length; j++)
                            {
                                rangesLong[j] = Convert.ToInt64(ranges[j]);
                            }

                            if (seedLong >= rangesLong[1]
                                && seedLong < rangesLong[1] + rangesLong[2])
                            {
                                long n = 0;

                                if (rangesLong[1] >= rangesLong[0])
                                {
                                    n = rangesLong[1] - rangesLong[0];
                                    seedLong -= n;
                                }
                                else
                                {
                                    n = rangesLong[0] - rangesLong[1];
                                    seedLong += n;
                                }

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
                    locations.Add(seedLong);
                }

            }
            return locations;
        }

        public long GetLowestLocation()
        {
            List<long> locations = SplitFile();

            long lowerLocation = locations[0];
            for (int i = 1; i < locations.Count; i++)
            {
                if (lowerLocation > locations[i])
                {
                    lowerLocation = locations[i];
                }
            }
            return lowerLocation;
        }
    }
}

