using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day07
{
    public class Part01
    {
        private string[] ReadFile()
        {
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day07/sample-day07.txt");
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day07/input-day07.txt");

        }
        private Dictionary<string, long> SplitFile()
        {
            string[] input = ReadFile();

            Dictionary<string, long> hands = new();
            foreach(string line in input)
            {
                string[] hand = line.Split(' ');

                hands.Add(hand[0], Convert.ToInt64(hand[1]));
            }
            return hands;
        }

        private void PutHandsInOrdemStrength()
        {
            string strengths = "AKQJT98765432";

            Dictionary<string, long> hands = SplitFile();

            for(int hand = 0; hand < hands.Count; hand++)
            {
                var item = hands.ElementAt(hand);

                for(long charHand = hand + 1; charHand < item.Value; charHand++)
                {

                }
            }
        }

        public int Sum()
        {
            PutHandsInOrdemStrength();
            return 0;
        }
    }
}
