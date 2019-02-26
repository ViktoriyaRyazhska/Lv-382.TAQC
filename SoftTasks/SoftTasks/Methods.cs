﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks
{
    static class Methods
    {
        static public List<String> MethodsList = new List<string>() {
            "1.Fibbonachi",
            "2.Mod_Fibbonachi",
            "3.WayToCoverIn3Steps",
            "4.FriendPairs",
            "5.Ways to sum array elements with repetition",
            "6.Longest subsequence with difference one",
            "7.Ways to write n as sum of two or more positive integers" ,
            "8.Paths without crossing",
            "9.Interesting rows",
            "10.Work to be with High-effort or with Low-effort",
            "0.Exit"
            };    // Add method name before "0.Exit"

        static public int Mod_Fibbonachi(int n)                  //2
        {

            if (n <= 3)
            {
                return 1;
            }
            return Mod_Fibbonachi(n - 1) + Mod_Fibbonachi(n - 3);
        }


        static public int Fibbonachi(int n)                   // 1
        {
            int f1 = 1;
            int f2 = 2;
            int fsum = 0;
            if (n == 1) fsum = f1;
            else if (n == 2) fsum = f2;
            for (int i = 2; i < n; i++)
            {
                fsum = f1 + f2;
                f1 = f2;
                f2 = fsum;
            }
            return fsum;
        }

        /// <summary>
        /// Khrystyna Fedun
        /// </summary>
        public static int CountWays(int N)      //5
        {
            int invalidInputResult = -1;
            string invalidInputmessage = "invalid input, please try again, example: 1,4,3,7";
            if (N < 1)
            {
                Console.WriteLine("N can not be les then zero");
                return invalidInputResult;
            }
            Console.WriteLine("Input array, e.g(1,4,3,7):");

            string numsInput = Console.ReadLine();
            if (numsInput == null || numsInput.Length == 0)
            {
                Console.WriteLine(invalidInputmessage);
                return invalidInputResult;
            }
            string[] values = numsInput.Split(',');
            if (values.Length == 0)
            {
                Console.WriteLine(invalidInputmessage);
                return invalidInputResult;
            }

            int[] arr = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                foreach (var ch in values[i])
                {
                    if (ch < '0' || ch > '9')
                    {
                        Console.WriteLine(invalidInputmessage);
                        return invalidInputResult;
                    }
                }
                arr[i] = int.Parse(values[i]);
            }
            int[] count = new int[N + 1];
            count[0] = 1;


            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {

                    if (i >= arr[j])
                    {
                        count[i] += count[i - arr[j]];
                    }
                }
            }

            return count[N];
        }

        static public int WayToCoverIn3Steps(int n)           // 3
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            return WayToCoverIn3Steps(n - 1) + WayToCoverIn3Steps(n - 2) + WayToCoverIn3Steps(n - 3);
        }


        static public int FriendPairs(int n)                  //4
        {
            int[] arr = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                if (i <= 2)
                    arr[i] = i;
                else
                    arr[i] = arr[i - 1] + (i - 1)
                                         * arr[i - 2];
            }
            return arr[n];
        }


        static public int myPairs(int n)
        {
            int[] myArr = new int[n + 1];
            myArr[0] = myArr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                myArr[i] = 0;
                for (int j = 0; j < i; j++)
                    myArr[i] += myArr[j] * myArr[i - j - 1];
            }
            return myArr[n];
        }
        static public int countAllWays(int n)
        {
            if (n <= 1)
            {
                Console.WriteLine("Invalid");
                return 0;
            }
            return myPairs(n / 2);
        }

        // Oleh Hnachuk
        public static int LongestSequenceWithDiff1(int[] input)      //6
        {
            int l = input.Length;
            int i = 0, maxlen = 0;
            while (i < l)
            {
                int j = i;
                while (i + 1 < l
                       && (Math.Abs(input[i] - input[i + 1]) == 1
                           || Math.Abs(input[i] - input[i + 1]) == 0))
                {
                    i++;
                }
                int currLen = i - j + 1;

                if (maxlen < currLen)
                    maxlen = currLen;

                if (j == i)
                    i++;
            }

            maxlen = (maxlen == 1) ? 0 : maxlen;

            return maxlen;
        }

        static public int WaysToWriteNAsSum(int n)     // 7
        {

            int[] table = new int[n + 1];

            for (int i = 0; i < table.Length; i++)
                table[i] = 0;

            table[0] = 1;

            for (int i = 1; i < n; i++)
                for (int j = i; j <= n; j++)
                {
                    table[j] += table[j - i];
                }

            return table[n];
        }

        static public int Interesting_Rows(int n)           // 9
        {
            if ((n == 1) || (n == 2))
            {
                return 1;
            }
            if (n > 2)
            {
                if ((n % 2) == 0)
                {
                    return Interesting_Rows(n - 1) + (2 * Interesting_Rows(n - 2));
                }
                if ((n % 2) != 0)
                {
                    return (2 * Interesting_Rows(n - 1)) + 1;
                }
            }
            return 0;
        }

        static public int maxTasks(int[] high,
                        int[] low, int n)
        {

            // If n is less than equal to 0, 
            // then no solution exists 
            if (n <= 0)
                return 0;

            /* Determines which task to choose on day n, 
                then returns the maximum till that day */
            return Math.Max(high[n - 1] +
                maxTasks(high, low, (n - 2)), low[n - 1] +
                maxTasks(high, low, (n - 1)));
        }
    }
}
