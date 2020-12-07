using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyConsole.AOC2020
{
    public class Day5
    {
        public static void BinaryBoarding()
        {
            string[] input = File.ReadAllLines(@"D:\Input.txt");

            //Part 1 - 874. Part2 - 594.
            CalculateSeatId(input);
        }

        private static void CalculateSeatId(string[] input)
        {
            // For part 1 answer.   
            int highestSeatId = 0;
            // For part 2 answer.
            var seatIdList = new List<int>();

            foreach (string seatIdentifier in input)
            {
                int rowNumber = GetSeatNumber(seatIdentifier: seatIdentifier, isRow: true);
                int columnNumber = GetSeatNumber(seatIdentifier: seatIdentifier, isRow: false);

                int seatId = rowNumber * 8 + columnNumber;
                seatIdList.Add(seatId);

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }

            #region "Part 2"

            seatIdList = seatIdList.OrderBy(i => i).ToList();

            for (int i = 1; i < seatIdList.Count; i++)
            {
                if (seatIdList[i] - seatIdList[i - 1] > 1)
                {
                    Console.WriteLine($"seat Id: {seatIdList[i] - 1}");
                }
            }

            #endregion

            //Console.WriteLine(highestSeatId);
        }

        private static int GetSeatNumber(string seatIdentifier, bool isRow)
        {
            int lowLimit = 0;
            int highLimit = isRow ? 127 : 7;

            for (int i = isRow ? 0 : 7; i < (isRow ? 7 : 10); i++)
            {
                if (seatIdentifier[i] == 'F' || seatIdentifier[i] == 'L')
                {
                    highLimit -= ((highLimit - lowLimit) / 2) + 1;
                }
                else if (seatIdentifier[i] == 'B' || seatIdentifier[i] == 'R')
                {
                    lowLimit += ((highLimit - lowLimit) / 2) + 1;
                }
            }
          
            // Both low and high limit will be same. We can return any.
            return lowLimit;
        }
    }
}
