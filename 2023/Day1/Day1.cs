using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day1
    {
        public static int CalculateCaliberation()
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}input.txt";
            string[] lines = File.ReadAllLines(path);

            int sum = 0;

            foreach (string line in lines)
            {
                int firstNumber = 0, lastNumber = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (int.TryParse(line[i].ToString(), out int result))
                    {
                        firstNumber = result;
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(line[i].ToString(), out int result))
                    {
                        lastNumber = result;
                        break;
                    }
                }

                sum += int.Parse($"{firstNumber}{lastNumber}");
            }

            // 54159.
            return sum;
        }


    }
}
