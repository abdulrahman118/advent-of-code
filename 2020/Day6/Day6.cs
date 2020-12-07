using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyConsole.AOC2020
{
    public class Day6
    {
        public static void Customs()
        {
            string[] input = File.ReadAllLines(@"D:\Input.txt");

            // Part1 - 6565.
            //CalculateAnswerCount1(input);

            // Part2 - 3137
            CalculateAnswerCount2(input);
        }

        private static void CalculateAnswerCount1(string[] input)
        {
            var answeredQuestions = new List<char>();
            int totalAnswerCount = 0;

            foreach (string line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    totalAnswerCount += answeredQuestions.Distinct().Count();
                    answeredQuestions = new List<char>();
                }
                else
                {
                    answeredQuestions.AddRange(line.Distinct());
                }
            }

            // Last group
            totalAnswerCount += answeredQuestions.Distinct().Count();
        }

        private static void CalculateAnswerCount2(string[] input)
        {
            var answeredQuestions = new Dictionary<char, int>();
            int numberOfPersons = 0;
            int totalAnswerCount = 0;

            foreach (string line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    totalAnswerCount += answeredQuestions.Where(i => i.Value == numberOfPersons).Count();
                    answeredQuestions = new Dictionary<char, int>();
                    numberOfPersons = 0;
                }
                else
                {
                    foreach (char answer in line)
                    {
                        if (answeredQuestions.ContainsKey(answer))
                        {
                            int count =  answeredQuestions.Where(i => i.Key == answer).First().Value;
                            answeredQuestions[answer] = ++count;
                        }
                        else
                        {
                            answeredQuestions.Add(answer, 1);
                        }
                    }

                    numberOfPersons++;
                }
            }

            // Last group
            totalAnswerCount += answeredQuestions.Where(i => i.Value == numberOfPersons).Count();
        }
    }
}
