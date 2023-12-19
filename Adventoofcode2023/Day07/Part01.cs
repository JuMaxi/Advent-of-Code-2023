using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day07
{
    public enum PossibleHands
    {
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        FullHouse = 5,
        FourOfAKind = 6,
        FiveOfAKind = 7,
    }
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
            foreach (string line in input)
            {
                string[] hand = line.Split(' ');

                hands.Add(hand[0], Convert.ToInt64(hand[1]));
            }
            return hands;
        }

        private Dictionary<string, long> SortKeyDictionary()
        {
            Dictionary<string, long> handsNoSorted = SplitFile();

            Dictionary<string, long> handsSorted = new();

            for (int key = 0; key < handsNoSorted.Count; key++)
            {
                var item = handsNoSorted.ElementAt(key);

                string handSorted = new string(item.Key.OrderBy(x => x).ToArray());

                handsSorted.Add(handSorted, item.Value);
            }

            return handsSorted;
        }

        private Dictionary<string, Dictionary<char, long>> FindPairsOfDigits()
        {

            Dictionary<string, long> hands = SortKeyDictionary();

            Dictionary<string, Dictionary<char, long>> pairs = new();


            for (int hand = 0; hand < hands.Count; hand++)
            {
                var item = hands.ElementAt(hand);
                Dictionary<char, long> pair = new();

                for (int charHand = 0; charHand < item.Key.Length - 1; charHand++)
                {
                    if (item.Key[charHand] == item.Key[charHand + 1])
                    {
                        if (!pair.ContainsKey(item.Key[charHand]))
                        {
                            pair.Add(item.Key[charHand], 2);

                        }
                        else
                        {
                            pair[item.Key[charHand]] = pair[item.Key[charHand]] + 1;
                        }
                    }
                }
                pairs.Add(item.Key, pair);
            }
            return pairs;
        }

        private Dictionary<string, List<long>> ReturnHandsToOriginalPositionAndAddPairsPerHand()
        {
            Dictionary<string, long> originalHandsFile = SplitFile();
            Dictionary<string, Dictionary<char, long>> pairs = FindPairsOfDigits();

            Dictionary<string, List<long>> pairsUpdated = new();

            for (int line = 0; line < originalHandsFile.Count; line++)
            {
                var itemOriginal = originalHandsFile.ElementAt(line);
                var itemPairsHand = pairs.ElementAt(line);

                List<long> pair = new();

                var longs = itemPairsHand.Value;

                foreach (long l in longs.Values)
                {
                    pair.Add(l);
                }

                pairsUpdated.Add(itemOriginal.Key, pair);
            }
            return pairsUpdated;
        }

        private PossibleHands GetHandScore(List<long> matches)
        {
            if (matches.Count == 1)
            {
                if (matches[0] == 2) return PossibleHands.OnePair;
                if (matches[0] == 3) return PossibleHands.ThreeOfAKind;
                if (matches[0] == 4) return PossibleHands.FourOfAKind;
                if (matches[0] == 5) return PossibleHands.FiveOfAKind;
            }
            else
            {
                if(matches.Count == 2)
                {
                    long biggest = matches.Max();
                    if (biggest == 2) return PossibleHands.TwoPair;
                    if (biggest == 3) return PossibleHands.FullHouse;
                }
            }
            return PossibleHands.HighCard;
        }


        private Dictionary<string, long> GetRankPerHand()
        {
            string strengths = "AKQJT98765432";

            Dictionary<string, List<long>> pairsPerHand = ReturnHandsToOriginalPositionAndAddPairsPerHand();

            Dictionary<string, long> pairsRanked = new();


            for (int line = 0; line < pairsPerHand.Count; line++)
            {
                long rank = pairsPerHand.Count;

                var item = pairsPerHand.ElementAt(line);

                for (int nextLine = 0; nextLine < pairsPerHand.Count; nextLine++)
                {
                    var nextItem = pairsPerHand.ElementAt(nextLine);
                    if (nextItem.Key == item.Key)
                        continue;

                    if (GetHandScore(item.Value) < GetHandScore(nextItem.Value))
                    {
                        rank--;
                    }
                    else
                    {
                        if (GetHandScore(item.Value) == GetHandScore(nextItem.Value))
                        {
                            // Verificar qual das maos tem carta maior

                            for (int charitem = 0; charitem < item.Key.Length; charitem++)
                            {
                                if (strengths.IndexOf(item.Key[charitem]) > strengths.IndexOf(nextItem.Key[charitem]))
                                {
                                    rank--;
                                    break;
                                }
                                else
                                {
                                    if (strengths.IndexOf(item.Key[charitem]) < strengths.IndexOf(nextItem.Key[charitem]))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                    }
                }

                pairsRanked.Add(item.Key, rank);
            }
            return pairsRanked;
        }

        public long Sum()
        {
            Dictionary<string, long> pairsRanked = GetRankPerHand();

            Dictionary<string, long> originalFile = SplitFile();

            long sum = 0;

            for (int i = 0; i < pairsRanked.Count; i++)
            {
                var itemPairsRanked = pairsRanked.ElementAt(i);

                long temp = itemPairsRanked.Value * originalFile[itemPairsRanked.Key];

                sum += temp;
            }
            return sum;
        }

    }



}






