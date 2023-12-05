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

                        int count = 1;
                        if (ii + 1 == input[i].Length)
                        {
                            count = 0;
                        }

                        if (input[i].IndexOf('.', ii + 1, count) >= 0)
                        {
                            //verificar adjacentes na linha anterior
                            if (i > 0)
                            {
                                for (int j = ii + 1 - n.Length; j <= ii + 1; j++)
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
                            if (input[i][ii + 1] != '.')
                            {
                                sum += Convert.ToInt32(n);
                                break;
                            }
                            if (ii - n.Length > 0)
                            {
                                if (input[i][ii - n.Length] != '.')
                                {
                                    sum += Convert.ToInt32(n);
                                    break;
                                }
                            }

                            //verificar adjacentes na linha seguinte
                            if (i != input.Length - 1)
                            {
                                if (ii < n.Length)
                                {
                                    ii++;
                                }
                                for (int j = ii - n.Length; j <= ii + 1; j++)
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
                        else
                        {
                            int cc = ii + 1;

                            if (ii + 1 == input[i].Length)
                            {
                                cc = ii;
                            }
                            if (numbers.IndexOf(input[i][cc]) < 0)
                            {
                                sum += Convert.ToInt32(n);
                                break;
                            }
                        }
                    }
                }
            }
            return sum;
        }
    }
}
