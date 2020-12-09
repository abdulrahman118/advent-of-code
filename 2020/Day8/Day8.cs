using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyConsole.AOC2020
{
    public class Day8
    {
        public static void ProcessInstructions()
        {
            string[] input = File.ReadAllLines(@"D:\Input.txt");

            // Part 1 - 1217.
            RunInstructions(input);

            // Part 2 - 501.
            RunInstructions2(input);
        }

        private static int RunInstructions(string[] input)
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

            Console.WriteLine($"accumulator: {accumulator}");

            return step;
        }

        private static void RunInstructions2(string[] input)
        {
            int step = 0;            

            int jumpCount = input.Where(i => i.StartsWith("jmp")).Count();
            int noOpCount = input.Where(i => i.StartsWith("nop")).Count();

            int jumpReplaceCount = 0;
            int noOpReplaceCount = 0;

            do
            {
                input = File.ReadAllLines(@"D:\Input.txt");

                if (jumpReplaceCount < jumpCount)
                {
                    int count = 0;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i].StartsWith("jmp"))
                        {
                            if (count == jumpReplaceCount)
                            {
                                input[i] = input[i].Replace("jmp", "nop");
                                jumpReplaceCount++;
                                break;
                            }

                            count++;
                        }
                    }

                }
                else if (noOpReplaceCount < noOpCount)
                {
                    int count = 0;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i].StartsWith("nop"))
                        {
                            if (count == noOpReplaceCount)
                            {
                                input[i] = input[i].Replace("nop", "jmp");
                                noOpReplaceCount++;
                                break;
                            }

                            count++;
                        }
                    }
                }

                step = RunInstructions(input);

                Console.WriteLine($"Step: {step}");

                if (jumpReplaceCount == jumpCount && noOpReplaceCount == noOpCount)
                {
                    break;
                }

            } while (step < (input.Length - 1));

            Console.WriteLine($"step: {step}, instructions count {input.Length}");
        }
    }
}
