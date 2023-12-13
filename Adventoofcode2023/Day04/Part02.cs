using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day04
{
    public class Part02
    {
        private string[] ReadFile()
        {
            //return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day04/sample-day04.txt");
            return File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day04/input-day04.txt");

        }

        private List<int> SplitCards()
        {
            string[] input = ReadFile();

            List<int> cards = SaveListEmpty(input);

            for (int line = 0; line < input.Length-1; line++)
            {
                string[] a = input[line].Split("|");
                string[] b = a[0].Split(":");
                string[] winningNumbers = b[1].Split(" ");
                string[] myNumbers = a[1].Split(" ");

                winningNumbers = winningNumbers.Where(item => item != "").ToArray();
                myNumbers = myNumbers.Where(item => item != "").ToArray();

                int number = GetWorthNumbers(winningNumbers, myNumbers);

                cards = ChangeCards(cards, line, number);
            }
            return cards;
        }

        private List<int> SaveListEmpty(string[] input)
        {
            List<int> cards = new();
            foreach(string line in input)
            {
                cards.Add(1);
            }
            return cards;
        }
        private int GetWorthNumbers(string[] winningNumbers, string[] myNumbers)
        {
            int t = 0;

            for (int i = 0; i < winningNumbers.Length; i++)
            {
                for (int ii = 0; ii < myNumbers.Length; ii++)
                {
                    if (winningNumbers[i] == myNumbers[ii])
                    {
                        t++;
                        break;
                    }
                }

               
            }
            return t;
        }

        private List<int> ChangeCards(List<int> cards, int line, int t)
        {

            for (int ii = line + 1; ii <= line + t; ii++)
            {
                cards[ii] = cards[ii] + cards[line];
            }

            return cards;
        }
        public int SumCards()
        {
            List<int> cards = SplitCards();

            int sum = 0;

            for(int i = 0; i < cards.Count; i++)
            {
                sum += cards[i];
            }

            return sum;
        }

    }
}
