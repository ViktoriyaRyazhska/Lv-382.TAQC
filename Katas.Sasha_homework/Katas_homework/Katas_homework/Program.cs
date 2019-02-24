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


        public static bool IsOpposite(string s1, string s2)    //Are they opposite?
        {
            string stemp = "";

            foreach (char ch in s1)
            {
                if (System.Char.IsLower(ch))
                {
                    stemp += System.Char.ToUpper(ch);
                }
                else stemp += System.Char.ToLower(ch);
            }

            if (string.IsNullOrEmpty(stemp) && string.IsNullOrEmpty(s2))
                return false;
            else return string.Equals(stemp, s2);
        }


        public static int Opposite(int number)    //Opposite number
        {
            return number * -1;
        }


        public static int summation(int num)    //Grasshopper - Summation
        {
            int sum = 0;
            for (int i = 1; i <= num; i++)
            {
                sum += i;
            }
            return sum;
        }


        public static string AreYouPlayingBanjo(string name)    //Are You Playing Banjo?
        {
            if (name[0].Equals('R') || name[0].Equals('r'))
                return name + " plays banjo";
            else return name + " does not play banjo";
        }


        public static string NoSpace(string input)    //Remove String Spaces
        {
            return input.Replace(" ", "");
        }






        static void Main(string[] args)
        {
            string s1 = "ab", s2 = "AB";
            System.Console.WriteLine(IsOpposite(s1, s2));
        }
    }
}
