using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day05
{
    public class Part01
    {
        private string[] ReadFile()
        {
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day05/sample-day05.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day05/input-day05.txt");

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
            foreach (string seed in seeds)
            {
                long seedInt = Convert.ToInt64(seed);

                for (int line = 2; line < input.Length; line++)
                {
                    if (char.IsDigit(input[line][0]))
                    {
                        string[] ranges = input[line].Split(" ");
                        long[] rangesLong = new long[ranges.Length];

                        for (int i = 0; i < ranges.Length; i++)
                        {
                            rangesLong[i] = Convert.ToInt64(ranges[i]);
                        }

                        if (seedInt >= rangesLong[1]
                            && seedInt < rangesLong[1] + rangesLong[2])
                        {
                            long n = 0;

                            if (rangesLong[1] >= rangesLong[0])
                            {
                                n = rangesLong[1] - rangesLong[0];
                                seedInt -= n;
                            }
                            else
                            {
                                n = rangesLong[0] - rangesLong[1];
                                seedInt += n;
                            }

                            bool skipSuccessful = false;
                            for (int i = line + 1; i < input.Length; i++)
                            {
                                if (char.IsLetter(input[i][0]))
                                {
                                    line = i;
                                    skipSuccessful = true;
                                    break;
                                }
                            }
                            if(!skipSuccessful)
                                line = input.Length- 1;
                        }
                    }
                }
                locations.Add(seedInt);
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
