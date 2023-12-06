using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day03
{
    public class Part01
    {
        private string[] ReadFile()
        {
            //string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/sample-day03.txt");
            string[] input = File.ReadAllLines("C:/Dev/Adventoofcode2023/Adventoofcode2023/Day03/input-day03.txt");

            return input;
        }

        public int SumParts()
        {
            string[] input = ReadFile();
            string numbers = "0123456789";
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string n = "";

                for (int ii = 0; ii < input[i].Length; ii++)
                {
                    char c = input[i][ii];

                    if (numbers.IndexOf(c) >= 0)
                    {
                        n += Convert.ToString(c);

                        int next = 1;
                        if (ii == input[i].Length - 1)
                        {
                            next = 0;
                        }

                        if (input[i].IndexOf('.', ii + next, 1) >= 0
                            || next == 0
                            || numbers.IndexOf(input[i][ii + next]) < 0)
                        {
                            //verificar adjacentes na linha anterior
                            if (i > 0)
                            {
                                int t = ii;
                                if (ii < n.Length)
                                {
                                    t = n.Length;
                                }
                                for (int j = t - n.Length; j <= t + next; j++)
                                {
                                    if (input[i - 1][j] != '.'
                                        && numbers.IndexOf(input[i - 1][j]) < 0)
                                    {
                                        sum += Convert.ToInt32(n);
                                        break;
                                    }
                                }
                            }

                            //verificar posicao inicial e final na mesma linha do numero.
                            if (input[i][ii + next] != '.' && input[i].Length - 1 != ii)
                            {
                                sum += Convert.ToInt32(n);
                            }
                            if (ii - n.Length > 0)
                            {
                                if (input[i][ii - n.Length] != '.')
                                {
                                    sum += Convert.ToInt32(n);
                                }
                            }

                            //verificar adjacentes na linha seguinte
                            if (i != input.Length - 1)
                            {
                                if (ii < n.Length)
                                {
                                    ii = n.Length;
                                }
                                for (int j = ii - n.Length; j <= ii + next; j++)
                                {
                                    if (input[i + 1][j] != '.'
                                        && numbers.IndexOf(input[i + 1][j]) < 0)
                                    {
                                        sum += Convert.ToInt32(n);
                                        break;
                                    }
                                }
                            }
                            n = "";
                        }
                    }
                }
            }
            return sum;
        }
    }
}
