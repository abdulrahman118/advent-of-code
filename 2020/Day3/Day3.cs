using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
 // Compiler version 4.0, .NET Framework 4.5


 namespace Dcoder
 {
   public class Program
   {
     public static void Main(string[] args)
     {
        string[] input = File.ReadAllLines(@"C:\Input.txt");

        // Part 1. 167
        //int numberOfTress = GetNumberOfTrees(input, 3, 1);

        // Part 2.
        int right1down1 = GetNumberOfTrees(input, moveRight: 1, moveDown: 1);
        int right3down1 = GetNumberOfTrees(input, moveRight: 3, moveDown: 1);
        int right5down1 = GetNumberOfTrees(input, moveRight: 5, moveDown: 1);
        int right7down1 = GetNumberOfTrees(input, moveRight: 7, moveDown: 1);
        int right1down2 = GetNumberOfTrees(input, moveRight: 1, moveDown: 2);

        // 736527114
        int finalNumberOfTrees = right1down1 * right3down1 * right5down1 * right7down1 * right1down2;

     }
     
     
     private static int GetNumberOfTrees(string[] input, int moveRight, int moveDown)
     {
         int numberOfTrees = 0;
         var map = new List<string>();

         int requiredHorizontalLength = input.Length * moveRight - 2;

         foreach (string line in input)
         {
             var sb = new StringBuilder();

             sb.Append(line);

             while (sb.ToString().Length < requiredHorizontalLength)
             {
                 sb.Append(line);
             }
             
             map.Add(sb.ToString());
         }

         int startIdnex = moveRight;

         for (int i = moveDown; i < input.Length; i += moveDown)
         {
             if (map[i][startIdnex] == '#')
             {
                 numberOfTrees++;
             }

             startIdnex += moveRight;
         }

         return numberOfTrees;
     }
   }
 }
