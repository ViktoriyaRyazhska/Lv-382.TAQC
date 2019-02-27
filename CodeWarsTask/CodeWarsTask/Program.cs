using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "nigga";
            string b = a;
            Console.WriteLine(a.Equals(b));
        }

        public static char GetChar(int charcode)
        {
            return (char)charcode;
        }

        public static int TotalPoints(string[] games)
        {
            int totalPoints = 0;
            foreach (string matchRes in games)
            {
                string[] temp = matchRes.Split(':');
                int x = int.Parse(temp[0]);
                int y = int.Parse(temp[1]);
                if (x == y)
                {
                    totalPoints++;
                }
                else if (x > y)
                {
                    totalPoints += 3;
                }
            }
            return totalPoints;
        }

        public static int PositiveSum(int[] arr)
        {
            int sum = 0;
            foreach (int item in arr)
            {
                if (item > 0)
                {
                    sum += item;
                }
            }
            return sum;
        }

        public static bool IsOpposite(string s1, string s2)
        {
            if (s1.ToLower() == s2.ToLower() && s1 != string.Empty && s2 != string.Empty)
            {
                char[] firstChars = s1.ToCharArray();
                char[] secondChars = s2.ToCharArray();
                for (int i = 0; i < s1.Length; i++)
                {
                    if ((char.IsUpper(firstChars[i]) && char.IsUpper(secondChars[i])) || (char.IsLower(firstChars[i]) && char.IsLower(secondChars[i])))
                    {
                        return false;
                    }
                }
                return true;
            }
            else { return false; }
        }

        public static int Opposite(int number)
        {
            return number * -1;
        }

        public static int summation(int num)
        {
            int sum = 0;
            for (int i = 1; i <= num; i++)
            {
                sum += i;
            }

            return sum;
        }

        public static string AreYouPlayingBanjo(string name)
        {
            return name.StartsWith("R") || name.StartsWith("r") ? name + " plays banjo" : name + " does not play banjo";
        }

        public static string NoSpace(string input)
        {
            return input.Replace(" ", "");
        }

        public static int[] CountPositivesSumNegatives(int[] input)
        {
            if (input != null && input.Length > 0)
            {
                int[] result = { 0, 0 };
                foreach (int num in input)
                {
                    if (num > 0) { result[0]++; }
                    else { result[1] += num; }
                }
                return result;
            }
            else return Array.Empty<int>();
        }

        public static List<int> ReverseList(List<int> list)
        {
            List<int> res = new List<int>();
            foreach (int item in list)
            {
                res.Insert(0, item);
            }
            return res;
        }

        public static int FindSmallestInt(int[] args)
        {
            int min = int.MaxValue;
            foreach (int item in args)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static int CountSheeps(bool[] sheeps)
        {
            int count = 0;
            foreach (bool item in sheeps)
            {
                if (item == true)
                {
                    count++;
                }
            }
            return count;
        }

        public static string Remove_char(string s)
        {
            return s.Remove(0, 1).Remove(s.Length - 2, 1);
        }

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

        public static int RentalCarCost(int d)
        {
            int res = 0;
            if (d >= 7)
            {
                res = d * 40 - 50;
            }
            else if (d >= 3)
            {
                res = d * 40 - 20;
            }

            else
            {
                res = d * 40;
            }
            return res;
        }

        public static int MakeNegative(int number)
        {
            return Math.Abs(number) * -1;
        }

        public static string boolToWord(bool word)
        {
            return word == true ? "Yes" : "No";
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
                default:
                    return value1;
            }
        }

        public int GetSum(int a, int b)
        {
            int sum = 0;
            if (a < b)
            {
                for (int i = a; i <= b; i++)
                {
                    sum += i;
                }
            }
            else if (a > b)
            {
                for (int i = b; i <= a; i++)
                {
                    sum += i;
                }
            }
            else
            {
                return a;
            }
            return sum;
        }

        public static string seriesSum(int n)
        {
            double den = 1;
            double sum = 0;
            if (n != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    sum += 1 / den;
                    den += 3;
                }
            }
            return String.Format("{0:0.00}", sum);
        }

        public static bool IsSquare(int n)
        {
            return Math.Sqrt(n) % 1 == 0;
        }

        public static string HighAndLow(string numbers)
        {
            string[] sep = numbers.Split(' ');
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < sep.Length; i++)
            {
                int temp = int.Parse(sep[i]);
                if (temp > max)
                    max = temp;
                if (temp < min)
                    min = temp;
            }
            return max + " " + min;
        }

        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int currentPopulation = p0;
            int counter = 0;
            while (currentPopulation < p)
            {
                currentPopulation += (int)(currentPopulation * percent / 100) + aug;
                counter++;
            }
            return counter;
        }

        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;
            vowelCount = str.Count(c => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
            return vowelCount;
        }

        public static int FindShort(string s)
        {
            int min = int.MaxValue;
            foreach (string str in s.Split(' '))
            {
                if (str.Length < min)
                {
                    min = str.Length;
                }
            }
            return min;
        }

        public static String Accum(string s)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                builder.Append(s.ToUpper()[i]);
                for (int j = 1; j < i + 1; j++)
                {
                    builder.Append(s.ToLower()[i]);
                }
                if (i != s.Length - 1)
                {
                    builder.Append('-');
                }
            }
            return builder.ToString();
        }

        public static int Mxdiflg(string[] a1, string[] a2)
        {
            if (a1.Length == 0 || a2.Length == 0)
            {
                return -1;
            }
            else
            {
                int a1max = int.MinValue;
                int a1min = int.MaxValue;
                for (int i = 0; i < a1.Length; i++)
                {
                    if (a1[i].Length > a1max)
                    {
                        a1max = a1[i].Length;
                    }
                    if (a1[i].Length < a1min)
                    {
                        a1min = a1[i].Length;
                    }
                }
                int a2max = int.MinValue;
                int a2min = int.MaxValue;
                for (int i = 0; i < a2.Length; i++)
                {
                    if (a2[i].Length > a2max)
                    {
                        a2max = a2[i].Length;
                    }
                    if (a2[i].Length < a2min)
                    {
                        a2min = a2[i].Length;
                    }
                }
                return Math.Max(a1max-a2min,a2max-a1min);
            }

        }

        public static string[][] Partlist(string[] arr)
        {
            string[][] res=new string[arr.Length-1][];
            for (int i = 0; i < arr.Length-1; i++)
            {
                res[i] = new string[2];
                for (int j = 0; j < i + 1; j++)
                {
                    res[i][0] += arr[j];
                    if (j != i)
                    {
                        res[i][0] += " ";
                    }
                }
                res[i][0]=res[i][0].Trim();
                for (int j = i + 1; j < arr.Length; j++)
                {
                    res[i][1] += arr[j];
                    if (j != arr.Length - 1)
                    {
                        res[i][1] += " ";
                    }
                }
                res[i][1]=res[i][1].Trim();
            }
            return res;
        }

        public static string VertMirror(string strng)
        {
            string[] arr = strng.Split('\n');
            StringBuilder builder = new StringBuilder();
            foreach (string str in arr)
            {
                char[] temp=str.ToCharArray();
                Array.Reverse(temp);
                builder.Append(new string(temp));
                builder.Append("\n");
            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
        public static string HorMirror(string strng)
        {
            string[] arr = strng.Split('\n');
            StringBuilder builder = new StringBuilder();
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                builder.Append(arr[i]);
                builder.Append("\n");
            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
        public static string Oper(Func<string,string> fct, string s)
        {
           return fct.Invoke(s);
        }

        public static long MaxRot(long n)
        {
            string str = n.ToString();
            char[] rot = str.ToCharArray();
            List<string> stringResults = new List<string>();
            stringResults.Add(new string(rot));
            for (int i = 0; i < rot.Length; i++)
            {
                char temp = rot[i];
                for (int j = i+1; j < rot.Length; j++)
                {
                    rot[j - 1] = rot[j];
                }
                rot[rot.Length - 1] = temp;
                stringResults.Add(new string(rot));
            }
            long max = long.MinValue;
            foreach (string stri in stringResults)
            {
                if (long.Parse(stri) > max)
                {
                    max = long.Parse(stri);
                }
            }
            return max;
        }

        public static int NbDig(int n, int d)
        {
            int counter = 0;
            int num = d + 48;
            Console.WriteLine(num);
            for (int i = 0; i < n+1; i++)
            {
                char[] temp = (i * i).ToString().ToCharArray();
                foreach (char c in temp)
                {
                    if(c==num)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public static string Longest(string s1, string s2)
        {
            StringBuilder builder = new StringBuilder();
            for (char i = 'a'; i < '{'; i++)
            {
                if (s1.Contains(i) || s2.Contains(i))
                {
                    builder.Append(i);
                }
            }
            return builder.ToString();
        }

        public static string PrinterError(String s)
        {
            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > 109)
                {
                    counter++;
                }
            }
            return String.Format("{0}/{1}",counter,s.Length);
        }

        public static int SequenceSum(int start, int end, int step)
        {
            int sum = 0;
            for (int i = start; i < end + 1; i += step)
            {
                sum += i;
            }
            return sum;
        }


    }
}
