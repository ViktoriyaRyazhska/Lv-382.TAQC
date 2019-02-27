using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            public static char GetChar(int charcode)
            {
                return (char)charcode;
            }
            //1

            public static int TotalPoints(string[] games)
            {
                int points = 0;

                foreach (string a in games)
                {
                    int x = System.Convert.ToInt32(a.Split(':')[0]);
                    int y = System.Convert.ToInt32(a.Split(':')[1]);
                    if (x > y) points += 3;
                    else if (x < y) points += 0;
                    else points += 1;
                }
                return points;
            }
            //2

            public static int PositiveSum(int[] arr)
            {
                int z = 0;
                int l = arr.Length;
                for (int i = 0; i < l; i++)
                {
                    if (arr[i] > 0)
                    {
                        z += arr[i];
                    }

                }
                return z;
            }
            //3

            public static bool IsOpposite(string s1, string s2)
            {
                if (s1.Length != s2.Length || s2.Length <= 0) return false;
                else if (s1 != s2)
                {
                    int c = 0;
                    for (int i = 0; i < s2.Length; i++)
                    {
                        if (!s1.Substring(i, 1).Equals(s2.Substring(i, 1))) { c += 0; }
                        else { c += 1; }
                    }
                    if (c == 0) return true;
                    else return false;
                }
                else return true;
            }
            //4

            public static int Opposite(int number)
            {
                return -number;
            }
            //5

            public static int summation(int num)
            {
                int sum = 0;
                for (int i = 1; i <= num; i++)
                    sum += i;
                return sum;
            }
            //6

        }
    }
}
