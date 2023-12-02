using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day2
    {
        public static int CubeGamesPart1()
        {
            int sum = 0;
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}input.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                bool validGame = true;

                string[] game = line.Split(':');

                string[] rounds = game[1].Trim().Split(';');

                foreach (string round in rounds)
                {
                    string[] cubes = round.Trim().Split(",");

                    foreach (string cube in cubes)
                    {
                        string[] cubeValue = cube.Trim().Split(' ');

                        if (cubeValue[1] == "green" && int.Parse(cubeValue[0]) > 13)
                        {
                            validGame = false;
                            break;
                        }

                        if (cubeValue[1] == "red" && int.Parse(cubeValue[0]) > 12)
                        {
                            validGame = false;
                            break;
                        }

                        if (cubeValue[1] == "blue" && int.Parse(cubeValue[0]) > 14)
                        {
                            validGame = false;
                            break;
                        }
                    }

                    if (!validGame)
                    {
                        break;
                    }
                }

                if (validGame)
                {
                    sum += int.Parse(game[0].Trim().Split(' ')[1]);
                }
            }

            // 2239.
            return sum;
        }

        public static int CubeGamesPart2()
        {
            int sum = 0;
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}input.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                int localSum = 1;
                var colourValues = new Dictionary<string, int>();

                string[] game = line.Split(':');

                string[] rounds = game[1].Trim().Split(';');

                foreach (string round in rounds)
                {
                    string[] cubes = round.Trim().Split(",");

                    foreach (string cube in cubes)
                    {
                        string[] cubeValue = cube.Trim().Split(' ');

                        if (colourValues.ContainsKey(cubeValue[1]))
                        {
                            if (colourValues[cubeValue[1]] < int.Parse(cubeValue[0]))
                            {
                                colourValues[cubeValue[1]] = int.Parse(cubeValue[0]);
                            }
                        }
                        else
                        {
                            colourValues.Add(cubeValue[1], int.Parse(cubeValue[0]));
                        }
                    }                    
                }

                foreach (var item in colourValues.Values)
                {
                    localSum *= item; 
                }

                sum += localSum;
            }

            // 83435.
            return sum;
        }
    }
}
