using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day1
    {
        public static int CalculateCaliberationPart1()
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

        public static int CalculateCaliberationPart2()
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}input.txt";
            string[] lines = File.ReadAllLines(path);
            var stringToNumber = new Dictionary<string, int>();
            var numberString = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            FillNumbers(stringToNumber);

            int sum = 0;

            foreach (string line in lines)
            {
                var indexList = new List<IndexValue>();

                for (int i = 0; i < line.Length; i++)
                {
                    if (int.TryParse(line[i].ToString(), out int result))
                    {
                        indexList.Add(new IndexValue { Index = i, Value = result });
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(line[i].ToString(), out int result))
                    {
                        indexList.Add(new IndexValue { Index = i, Value = result });
                        break;
                    }
                }

                foreach (string number in numberString)
                {
                    if (line.Contains(number))
                    {
                        indexList.Add(new IndexValue { Index = line.IndexOf(number), Value = stringToNumber[number] });
                        indexList.Add(new IndexValue { Index = line.LastIndexOf(number), Value = stringToNumber[number] });
                    }
                }

                indexList = indexList.OrderBy(i => i.Index).ToList();

                sum += int.Parse($"{indexList.First().Value}{indexList.Last().Value}");
            }

            // 53866.
            return sum;
        }

        private static void FillNumbers(Dictionary<string, int> numberStrings)
        {
            numberStrings.Add("one", 1);
            numberStrings.Add("two", 2);
            numberStrings.Add("three", 3);
            numberStrings.Add("four", 4);
            numberStrings.Add("five", 5);
            numberStrings.Add("six", 6);
            numberStrings.Add("seven", 7);
            numberStrings.Add("eight", 8);
            numberStrings.Add("nine", 9);
        }
    }

    internal class IndexValue
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }
}
