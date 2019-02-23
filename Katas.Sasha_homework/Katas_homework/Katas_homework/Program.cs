using System;

namespace Katas_homework
{
    class Program
    {

        public static char GetChar(int charcode)   //get character from ASCII Value
        {
            return (char)charcode;
        }

        public static int TotalPoints(string[] games)   //Total amount of points
        {
            int points = 0;
            foreach (string result in games)
            {
                int x = System.Convert.ToInt32(result.Split(':')[0]);
                int y = System.Convert.ToInt32(result.Split(':')[1]);
                if (x > y) points += 3;
                else if (x < y) points += 0;
                else points += 1;
            }
            return points;
        }

        public static int PositiveSum(int[] arr)   //Sum of positive
        {
            int sum = 0;
            foreach (int a in arr)
            {
                if (a > 0) sum += a;
            }
            return sum;
        }

    }
}
