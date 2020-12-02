using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
 // Compiler version 4.0, .NET Framework 4.5


 namespace Dcoder
 {
   public class Program
   {
     public static void Main(string[] args)
     {
        string[] input = File.ReadAllLines(@"D:\Input.txt");
        int validPasswordsCount = 0;

        // Part 1.
        //validPasswordsCount = GetValidPasswordCount1(input);

        // Part 2.
        validPasswordsCount = GetValidPasswordCount2(input);
        Console.WriteLine(validPasswordsCount);
     }
     
     private static int GetValidPasswordCount1(string[] input)
     {
        int validPasswordsCount = 0;

        foreach (var line in input)
        {
           string[] policy = line.Split(' ');

           int minCount = int.Parse(policy[0].Split('-')[0]);
           int maxCount = int.Parse(policy[0].Split('-')[1]);

           char search = policy[1].Substring(0, 1).ToCharArray()[0];

           // The search character count must be in the range of minCount and maxCount.
           bool isValid = policy[2].Contains(search) && policy[2].Where(i => i == search).Count() >= minCount && policy[2].Where(i => i == search).Count() <= maxCount;

           if (isValid)
           {
               validPasswordsCount++;
           }

        }

        return validPasswordsCount;
      }
      

      private static int GetValidPasswordCount2(string[] input)
      {
        int validPasswordsCount = 0;

        foreach (var line in input)
        {
           bool isValid = false;

           string[] policy = line.Split(' ');

           // positions of the character (not index based).
           int[] positions = policy[0].Split('-').Select(i => Convert.ToInt32(i)).ToArray();

           string search = policy[1].Substring(0, 1);

           if (policy[2].Contains(search))
           {
               if (policy[2].Substring((positions[0] - 1), 1) == search)
               {
                   if (policy[2].Substring((positions[1] - 1), 1) != search)
                   {
                       isValid = true;
                   }
               }
               else if (policy[2].Substring((positions[1] - 1), 1) == search)
               {
                        isValid = true;
               }
           }

           if (isValid)
           {
               validPasswordsCount++;
           }

        }

            return validPasswordsCount;
       }
   }
 }
