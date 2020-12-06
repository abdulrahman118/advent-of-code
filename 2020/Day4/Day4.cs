using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyConsole.AOC2020
{
    public class Day4
    {
        #region "passport"

        internal static void ValidatePassports()
        {
            string[] input = File.ReadAllLines(@"C:\Users\IBS006\Documents\Input.txt");
            int validPassportCount = 0;

            // Part 1. 216
            validPassportCount = GetValidPassportCount1(input);

            // Part 2. 150
            validPassportCount = GetValidPassportCount2(input);

        }

        private static int GetValidPassportCount1(string[] input)
        {
            int validPassportCount = 0;
            var attributes = new Dictionary<string, string>();

            foreach (string line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (attributes.Count == 8 || (attributes.Count == 7 && !attributes.ContainsKey("cid")))
                    {
                        validPassportCount++;
                    }

                    attributes = new Dictionary<string, string>();
                }
                else
                {
                    string[] data = line.Split(' ');

                    foreach (string item in data)
                    {
                        if (!attributes.ContainsKey(item.Split(':')[0]))
                        {
                            attributes.Add(item.Split(':')[0], item.Split(':')[1]);
                        }
                    }
                }
            }

            if (attributes.Count == 8 || (attributes.Count == 7 && !attributes.ContainsKey("cid")))
            {
                validPassportCount++;
            }

            return validPassportCount;
        }

        private static int GetValidPassportCount2(string[] input)
        {
            int validPassportCount = 0;
            var attributes = new Dictionary<string, bool>();

            foreach (string line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (attributes.Where(i => i.Value == true).Count() == 8 || (attributes.Where(i => i.Value == true).Count() == 7 && !attributes.ContainsKey("cid")))
                    {
                        validPassportCount++;
                    }

                    attributes = new Dictionary<string, bool>();
                }
                else
                {
                    string[] infos = line.Split(' ');

                    foreach (string item in infos)
                    {
                        bool isValid = false;
                        string data = item.Split(':')[1];

                        switch (item.Split(':')[0])
                        {
                            case "byr":
                                if (IsNumber(data, 4) && int.Parse(data) >= 1920 && int.Parse(data) <= 2002)
                                {
                                    isValid = true;
                                }
                                break;
                            case "iyr":
                                if (IsNumber(data, 4) && int.Parse(data) >= 2010 && int.Parse(data) <= 2020)
                                {
                                    isValid = true;
                                }
                                break;
                            case "eyr":
                                if (IsNumber(data, 4) && int.Parse(data) >= 2020 && int.Parse(data) <= 2030)
                                {
                                    isValid = true;
                                }
                                break;
                            case "hgt":
                                if (ValidHeight(data))
                                {
                                    isValid = true;
                                }
                                break;
                            case "hcl":
                                if (ValidHairColor(data))
                                {
                                    isValid = true;
                                }
                                break;
                            case "ecl":
                                var validColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                isValid = validColors.Contains(data);
                                break;
                            case "pid":
                                isValid = IsNumber(data, 9);
                                break;
                            case "cid":
                                isValid = true;
                                break;
                            default:
                                break;
                        }

                        if (!attributes.ContainsKey(item.Split(':')[0]))
                        {
                            attributes.Add(item.Split(':')[0], isValid);
                        }
                    }
                }
            }

            if (attributes.Count == 8 || (attributes.Count == 7 && !attributes.ContainsKey("cid")))
            {
                validPassportCount++;
            }

            return validPassportCount;
        }

        private static bool ValidHairColor(string input)
        {
            string pattern = @"^#[a-f0-9]{6,6}$";
            return Regex.IsMatch(input, pattern);
        }

        private static bool ValidHeight(string input)
        {
            string pattern = string.Empty;

            if (input.EndsWith("cm"))
            {
                pattern = @"^\d{3,3}cm$";

                return Regex.IsMatch(input, pattern) && int.Parse(input.Substring(0, input.Length - 2)) >= 150 && int.Parse(input.Substring(0, input.Length - 2)) <= 193;
            }
            else if (input.EndsWith("in"))
            {
                pattern = @"^\d{2,2}in$";
                return Regex.IsMatch(input, pattern) && int.Parse(input.Substring(0, input.Length - 2)) >= 59 && int.Parse(input.Substring(0, input.Length - 2)) <= 76;
            }

            return false;
        }

        private static bool IsNumber(string input, int? digits)
        {
            string pattern = string.Empty;

            if (digits.HasValue)
            {
                pattern = @"^\d{1,1}$";
                pattern = pattern.Replace("1", digits.ToString());
            }
            else
            {
                pattern = @"^\d*$";
            }

            return Regex.IsMatch(input, pattern);
        }

        #endregion
    }
}
