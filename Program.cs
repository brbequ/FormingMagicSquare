using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    //      These are the eight possibilities
    //      Two sets of mirror images
    //      2 9 4  |  4 9 2
    //   -->7 5 3  |  3 5 7
    //   D  6 1 8  |  8 1 6
    // F i  ----------------
    // l a  6 1 8  |  8 1 6
    // i g  7 5 3  |  3 5 7
    // p o  2 9 4  |  4 9 2
    // p n  
    // e a  2 7 6  |  6 7 2
    // d l->9 5 1  |  1 5 9
    //      4 3 8  |  8 3 4
    //      ----------------
    //      4 3 8  |  8 3 4
    //      9 5 1  |  1 5 9
    //      2 7 6  |  6 7 2
    //   
    static List<int[][]> boards = new List<int[][]>
    {
        new int[][]
        {
            new int[] { 2, 9, 4 },
            new int[] { 7, 5, 3 },
            new int[] { 6, 1, 8 }
        },
        new int[][]
        {
            new int[] { 4, 9, 2 },
            new int[] { 3, 5, 7 },
            new int[] { 8, 1, 6 }
        },
        new int[][]
        {
            new int[] { 6, 1, 8 },
            new int[] { 7, 5, 3 },
            new int[] { 2, 9, 4 }
        },
        new int[][]
        {
            new int[] { 8, 1, 6 },
            new int[] { 3, 5, 7 },
            new int[] { 4, 9, 2 }
        },
        new int[][]
        {
            new int[] { 2, 7, 6 },
            new int[] { 9, 5, 1 },
            new int[] { 4, 3, 8 }
        },
        new int[][]
        {
            new int[] { 6, 7, 2 },
            new int[] { 1, 5, 9 },
            new int[] { 8, 3, 4 }
        },
        new int[][]
        {
            new int[] { 4, 3, 8 },
            new int[] { 9, 5, 1 },
            new int[] { 2, 7, 6 }
        },
        new int[][]
        {
            new int[] { 8, 3, 4 },
            new int[] { 1, 5, 9 },
            new int[] { 6, 7, 2 }
        },
    };

    // Complete the formingMagicSquare function below.
    static int formingMagicSquare(int[][] s)
    {
        int lowest = -1;

        foreach (int[][] board in boards)
        {
            int cost = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    cost += Math.Abs(s[row][col] - board[row][col]);
                }
            }

            if (lowest < 0 || cost < lowest)
                lowest = cost;
        }

        return lowest;
    }

    static void Main(string[] args)
    {
        for (int t = 0; t < testcases.Count(); t++)
        {
            int result = formingMagicSquare(testcases[t]);

            int expected = testcases[t][3][0];

            Console.WriteLine(result.ToString() + (result == expected ? String.Empty : " - Expected " + expected.ToString() ));
        }
    }

    static List<int[][]> testcases = new List<int[][]>
        {
            new int[4][]
            {
                new int[] { 4, 9, 2 },
                new int[] { 3, 5, 7 },
                new int[] { 8, 1, 5 },
                new int[] { 1 } // Expected answer
            },

            new int[4][]
            {
                new int[] { 2, 9, 8 },
                new int[] { 4, 2, 7 },
                new int[] { 5, 6, 7 },
                new int[] { 21 } // Expected answer
            },

            new int[4][]
            {
                new int[] { 4, 8, 2 },
                new int[] { 4, 5, 7 },
                new int[] { 6, 1, 6 },
                new int[] { 4 } // Expected answer
            },
        };
}
