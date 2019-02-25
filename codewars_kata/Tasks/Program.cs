using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static char GetChar(int charcode)
        {
            return (char)charcode;
        }
        public static int TotalPoints(string[] games)
        {
            int total = 0;
            foreach (string game in games)
            {
                if (game[0] > game[2])
                    total += 3;
                else if (game[0] == game[2])
                    total += 1;
            }
            return total;
        }
        public static int PositiveSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0) sum += arr[i];
            }
            return sum;
        }
        public static int Opposite(int number)
        {
            return number * (-1);
        }
        public static int summation(int num)
        {
            int sum = 0;

            for (int i = 0; i <= num; i++)
            {
                sum += i;
            }
            return sum;
        }
        public static string AreYouPlayingBanjo(string name)
        {
            if (name[0] == 'R' || name[0] == 'r')
            {
                return name + " plays banjo";
            }
            else
            {
                return name + " does not play banjo";
            }
        }

        public static string NoSpace(string input)
        {
            input = input.Replace(" ", string.Empty);
            return input;
        }

        public static List<int> ReverseList(List<int> list)
        {
            return Enumerable.Reverse(list).ToList();
        }

        public static int[] CountPositivesSumNegatives(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return new int[] { };
            }
            if (input != null)
            {
                int j = 0;
                int sum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] > 0)
                    {
                        j++;
                    }
                    if (input[i] < 0)
                    {
                        sum += input[i];
                    }

                }
                int[] output = { j, sum };
                return output;
            }
            return null;
        }

        public static int FindSmallestInt(int[] args)
        {
            int smallest = args[0];
            for (int i = 0; i < args.Length; i++)
            {

                if (args[i] < smallest)
                {
                    smallest = args[i];
                }
            }
            return smallest;
        }

        public static int CountSheeps(bool[] sheeps)
        {
            int j = 0;
            for (int i = 0; i < sheeps.Length; i++)
            {
                if (sheeps[i] == true)
                {
                    j++;
                }
            }
            return j;
        }

        public static string Remove_char(string s)
        {

            s = s.Substring(1, s.Length - 2);

            return s;
        }

        public class SolutionClass
        {
            public static string EvenOrOdd(int number)
            {
                if (number % 2 == 0)
                {
                    return "Even";
                }
                else
                {
                    return "Odd";
                }
            }
        }
        public static int RentalCarCost(int d)
        {
            int sum = 0;
            if (d >= 7)
            {
                sum = d * 40 - 50;
            }
            if (d >= 3 && d < 7)
            {
                sum = d * 40 - 20;
            }
            if (d < 3)
            {
                sum = d * 40;
            }
            return sum;
        }

        public static int MakeNegative(int number)
        {
            if (number < 0)
            {
                return number;
            }
            else
            {
                return number * (-1);
            }
            return 0;
        }

        public static string boolToWord(bool word)
        {
            switch (word)
            {
                case true:
                    return "Yes";
                case false:
                    return "No";
            }
            return "";
        }

        public static double basicOp(char operation, double value1, double value2)
        {
            switch (operation)
            {
                case '+':
                    return value1 + value2;
                case '-':
                    return value1 - value2;
                case '*':
                    return value1 * value2;
                case '/':
                    return value1 / value2;

            }
            return -1;
        }

        public int GetSum(int a, int b)
        {
            int f = 0; int sum = 0;
            int s = 0;
            if (a < b)
            {
                f = a;
                s = b;
            }
            else
            {
                f = b;
                s = a;
            }
            for (int i = f; i <= s; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static string seriesSum(int n)
        {
            double sum = 0;
            for (int i = 0, divider = 1; i < n; i++, divider += 3)
            {
                sum += 1.0 / divider;
            }
            return $"{sum:f2}";
        }

        public static bool IsSquare(int n)
        {
            double b = Convert.ToDouble(n);
            b = Math.Sqrt(n);
            if (b % 1 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string HighAndLow(string numbers)
        {
            var listnums = numbers.Split(' ').Select(int.Parse);

            return string.Format("{0} {1}", listnums.Max(), listnums.Min());
        }

        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;
            foreach (char ch in str)
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    vowelCount++;
                }
            }

            return vowelCount;
        }

        public static int FindShort(string s)
        {
            int minInd = 0;
            string[] dd = s.Split(' ');
            int min = dd[0].Length;

            for (int i = 0; i < dd.Length; i++)
                if (min > dd[i].Length) { min = dd[i].Length; minInd = i; }
            return min;
        }



    }
}

