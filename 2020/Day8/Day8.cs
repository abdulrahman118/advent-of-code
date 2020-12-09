using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole.AOC2020
{
    public class Day8
    {
        public static void ProcessInstructions()
        {
            string[] input = File.ReadAllLines(@"D:\Input.txt");

            // Part 1 - 1217.
            RunInstructions(input);

            // Part 2 - to do.
            RunInstructions2(input);
        }

        private static void RunInstructions(string[] input)
        {
            int step = 0;
            int accumulator = 0;
            var executedSteps = new List<int>();

            do
            {
                if (!executedSteps.Contains(step))
                {
                    executedSteps.Add(step);
                    string instruction = input[step];

                    string operation = instruction.Split(' ')[0];
                    int value = int.Parse(instruction.Split(' ')[1]);

                    switch (operation)
                    {
                        case "acc":
                            accumulator += value;
                            step++;
                            break;
                        case "jmp":
                            step += value;
                            break;
                        case "nop":
                            step++;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    break;
                }
            } while (step < input.Length);
        }

        private static void RunInstructions2(string[] input)
        {
            int step = 0;
            int accumulator = 0;
            var executedSteps = new List<int>();

            int jumpCount = input.Where(i => i.StartsWith("jmp")).Count();
            int noOpCount = input.Where(i => i.StartsWith("nop")).Count();

            int jumpReplaceCount = jumpCount;
            int noOpReplaceCount = noOpCount;
            //input = File.ReadAllLines(@"D:\Input.txt");
            do
            {
                //input.Where(i => i.StartsWith("jmp")).

            } while (jumpReplaceCount > jumpCount || noOpReplaceCount > noOpCount);

            Console.WriteLine($"step: {step}, instructions count {input.Length}");
        }
    }
}
