using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class AOCD2
    {
        int[] input = new int[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 10, 1, 19, 1, 19, 9, 23, 1, 23, 13, 27, 1, 10, 27, 31, 2, 31, 13, 35, 1, 10, 35, 39, 2, 9, 39, 43, 2, 43, 9, 47, 1, 6, 47, 51, 1, 10, 51, 55, 2, 55, 13, 59, 1, 59, 10, 63, 2, 63, 13, 67, 2, 67, 9, 71, 1, 6, 71, 75, 2, 75, 9, 79, 1, 79, 5, 83, 2, 83, 13, 87, 1, 9, 87, 91, 1, 13, 91, 95, 1, 2, 95, 99, 1, 99, 6, 0, 99, 2, 14, 0, 0 };        

        internal int RunSolution1()
        {
            input[1] = 12;
            input[2] = 2;

            for (int i = 0; i < input.Length; i += 4)
            {
                int opCode = input[i];

                if(opCode == 99)
                {
                    return input[0];
                }
                
                int input1 = input[input[i + 1]];
                int input2 = input[input[i + 2]];

                if(opCode == 1)
                {
                    input[input[i + 3]] = input1 + input2;
                }
                else if(opCode == 2)
                {
                    input[input[i + 3]] = input1 * input2;
                }
                else
                {
                    Console.WriteLine("Unknown Opcode");
                }                 
            }

            return 0;
        }

        internal void RunSolution2()
        {
            int requiredOutput = 0;

            var randomNumber = new Random(0);
            int noun = 0;
            int verb = 0;

            while (requiredOutput != 19690720)
            {
                noun = randomNumber.Next(0, 99);
                verb = randomNumber.Next(0, 99);
                ResetMemory();
                requiredOutput = CalculateOuput(noun, verb);
            }

            Console.WriteLine($"noun: {noun} verb: {verb}");
        }

        private void ResetMemory()
        {
            input = new int[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 10, 1, 19, 1, 19, 9, 23, 1, 23, 13, 27, 1, 10, 27, 31, 2, 31, 13, 35, 1, 10, 35, 39, 2, 9, 39, 43, 2, 43, 9, 47, 1, 6, 47, 51, 1, 10, 51, 55, 2, 55, 13, 59, 1, 59, 10, 63, 2, 63, 13, 67, 2, 67, 9, 71, 1, 6, 71, 75, 2, 75, 9, 79, 1, 79, 5, 83, 2, 83, 13, 87, 1, 9, 87, 91, 1, 13, 91, 95, 1, 2, 95, 99, 1, 99, 6, 0, 99, 2, 14, 0, 0 };
        }

        int CalculateOuput(int noun,int verb)
        {
            input[1] = noun;
            input[2] = verb;

            for (int i = 0; i < input.Length; i += 4)
            {
                int opCode = input[i];

                if (opCode == 99)
                {
                    return input[0];
                }
                
                int input1 = input[input[i + 1]];
                int input2 = input[input[i + 2]];

                if (opCode == 1)
                {
                    input[input[i + 3]] = input1 + input2;
                }
                else if (opCode == 2)
                {
                    input[input[i + 3]] = input1 * input2;
                }
                else
                {
                    Console.WriteLine("Unknown Opcode");
                }                
            }

            throw new NotSupportedException();
        }
    }
}
