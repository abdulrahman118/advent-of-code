using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyConsole.AOC2020
{
    public class Day7
    {
        public static void LuggageProcessing()
        {
            string[] input = File.ReadAllLines(@"D:\Input.txt");

            // Part1 - 155.
            ShinyGoldBag(input);

            // Part2 - 54803.
            ShinyGoldBag2(input);
        }

        private static void ShinyGoldBag(string[] input)
        {
            var colors = new List<string>();

            colors.AddRange(GetBags(input, new string[] { "shiny gold" }));

            // Distinct colors count will give number of colors.
            Console.WriteLine(colors.Distinct().Count());
        }

        private static List<string> GetBags(string[] input, string[] colors)
        {
            var colorsWithShinyGolgBags = new List<string>();

            foreach (string color in colors)
            {
                List<string> bags = input.Where(line => line.Contains(color) && !line.StartsWith(color))
                                                               .Select(line => line.Split(' ')[0] + " " + line.Split(' ')[1])
                                                               .ToList();
                if (bags.Count != 0)
                {
                    colorsWithShinyGolgBags.AddRange(bags);
                    colorsWithShinyGolgBags.AddRange(GetBags(input, bags.ToArray()));
                }
            }

            return colorsWithShinyGolgBags;
        }

        private static void ShinyGoldBag2(string[] input)
        {
            var colors = new List<string>();

            int count = GetBags2(input, "shiny gold");

            Console.WriteLine(count);
        }

        private static int GetBags2(string[] input, string color)
        {
            int count = 1;

            if (color == "shiny gold")
            {
                // Don't count shiny gold bag. count number of bags inside.
                count = 0;
            }

            string bag = input.Where(line => line.StartsWith(color)).First();

            if (bag.EndsWith("no other bags."))
            {
                return 1;
            }
            else
            {
                string[] insideBags = bag.Substring(bag.IndexOf("contain") + 7).Split(',');

                foreach (string item in insideBags)
                {
                    int bagCount = int.Parse(item.Trim().Split(' ')[0]);

                    count += (bagCount * GetBags2(input, item.Trim().Split(' ')[1] + " " + item.Trim().Split(' ')[2]));
                }
            }

            return count;
        }
    }
}
