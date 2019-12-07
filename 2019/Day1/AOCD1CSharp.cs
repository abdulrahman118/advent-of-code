using System.IO;

namespace ConsoleApp1
{
    class AOCD1
    {
        string filePath = @"D:\Abdul\WorkSpace\ZTM\aoc\2019\Day1\input.txt";

        public int RunSoultion()
        {
            int sum = 0;

            using(StreamReader stream = new StreamReader(filePath))
            {
                while (stream.Peek() >= 0)
                {
                    int mass = int.Parse(stream.ReadLine());
                    int totalMass = 0;

                    while (mass > 0)
                    {
                        int result = mass / 3 - 2;

                        if (result > 0)
                        {
                            totalMass += result;
                        }

                        mass = result;
                    }

                    sum += totalMass;
                }
            }

            return sum;
        }
    }
}
