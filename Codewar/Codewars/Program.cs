using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Codewars
{
    public static class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> b = new List<int>() { 2, 4, 6, 7, 8, 11, 43 };
            foreach (var n in CollectionsTasks.Task2(a,b))
            {
                Console.WriteLine(n+" ");
            }
            Console.ReadKey();
        }

        // Kats start
        public static char GetChar(int charcode)
        {
            return (char)charcode;
        }

        public static int TotalPoints(string[] games)
        {
            int result = 0;
            foreach (string n in games)
            {
                string[] temp = n.Split(new char[] { ':' });

                if (int.Parse(temp[0]) > int.Parse(temp[1]))
                    result += 3;
                else if (int.Parse(temp[0]) < int.Parse(temp[1]))
                    result += 0;
                else if (int.Parse(temp[0]) == int.Parse(temp[1]))
                    result += 1;
            }
            return result;
        }

        public static int PositiveSum(int[] arr)
        {
            return arr.Select(x => { var value = x > 0 ? x : 0; return value; }).Sum(x => x);
        }
        public static bool IsOpposite(string s1, string s2)
        {
            if (!s1.Equals(s2, StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(s1))
                return false;
            string s2t = "";
            foreach (char n in s2)
            {
                if (char.IsLower(n))
                    s2t += char.ToUpper(n);
                else if (char.IsUpper(n))
                    s2t += char.ToLower(n);
            }
            return Equals(s1, s2t);
        }
        public static int Opposite(int number)
        {
            return number * (-1);
        }

        public static int summation(int num)
        {
            int res = 0;
            for (int i = num; i >= 1; i--)
            {
                res += i;
            }
            return res;
        }
        public static string AreYouPlayingBanjo(string name)
        {
            return name.First().ToString().Equals("r", StringComparison.OrdinalIgnoreCase) ? Convert.ToString(name + " plays banjo") : Convert.ToString(name + " does not play banjo");
        }

        public static string NoSpace(string input)
        {
            return string.Concat(input.Split(new char[] { ' ' }));
        }

        public static List<int> ReverseList(List<int> list)
        {

            List<int> rev = new List<int>(Enumerable.Reverse(list).ToList());
            return rev;
        }

        public static int[] CountPositivesSumNegatives(int[] input)
        {
            if (input == null || input.Length == 0)
                return Array.Empty<int>();
            return new int[] { input.Where(x => x > 0).Count(), input.Where(x => x < 0).Sum() };
        }

        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }

        public static int CountSheeps(bool[] sheeps)
        {
            return sheeps.Where(x => x is true).Count();
        }

        public static string Remove_char(string s)
        {
            return s.Substring(1, s.Length - 2).ToString();
        }
        public static string EvenOrOdd(int number)
        {

            return number % 2 == 0 ? "Even" : "Odd";
        }

        public static int RentalCarCost(int d)
        {
            return d * 40 - (d >= 3 && d < 7 ? 20 : 0) - (d >= 7 ? 50 : 0);
        }
        public static int MakeNegative(int number)
        {
            return number > 0 ? -number : number == 0 ? 0 : number;
        }
        public static string boolToWord(bool word)
        {
            return word is true ? "Yes" : "No";
        }
        public static double basicOp(char operation, double value1, double value2)
        {
            switch (operation)
            {
                case '+':
                    return value1 + value2;
                    break;
                case '-':
                    return value1 - value2;
                    break;
                case '*':
                    return value1 * value2;
                    break;
                case '/':
                    return value1 / value2;
                    break;
            }
            return 0;
        }
        //public int GetSum(int a, int b)
        //{
        //    //if (a == b)
        //    //    return a;
        //    //if(a > b)
        //    //    Enumerable.Range(b,)
        //    //    return 
        //    //return 0;
        //}
        public static int FindShort(string s)
        {
            string[] a = s.Split(new char[] { ' ' });
            return a.Select(x => { return x.Length; }).Min(x => x);
        }
        public static string seriesSum(int n)
        {
            decimal sum = 0.00m;
            decimal z = 1.00m;
            for (int i = 1; i <= n; i++)
            {
                sum += 1 / z;
                z += 3;
            }
            return Convert.ToString(Math.Round(sum, 3));
        }
        public static String Accum(string s)
        {
            char[] a = s.ToUpper().ToCharArray();
            string res = a[0].ToString();
            for (int i = 1; i < a.Length; i++)
            {
                res += "-" + a[i].ToString();
                for (int j = 1; j <= i; j++)
                {
                    res += a[i].ToString().ToLower();
                }
            }
            return res;
        }
        public static int Mxdiflg(string[] a1, string[] a2)
        {
            if (a1 == null || a2 == null || a1.Length == 0 || a2.Length == 0)
                return -1;
            return Math.Max(Math.Abs(a1.Min(x => x.Length) - a2.Max(x => x.Length)), Math.Abs(a1.Max(x => x.Length) - a2.Min(x => x.Length)));
        }
        public static string[][] Partlist(string[] arr)
        {
            string[][] res = new string[arr.Length - 1][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new string[2];
                for (int j = 0; j <= i; j++)
                {
                    if (j > 0 && j <= i)
                        res[i][0] += " ";
                    res[i][0] += arr[j];
                }
                for (int d = i + 1; d < arr.Length; d++)
                {
                    if (d > i + 1 && d < arr.Length)
                        res[i][1] += " ";
                    res[i][1] += arr[d];
                }
            }
            return res;
        }
        public static bool IsSquare(int n)
        {
            int a = (int)Math.Sqrt(n);
            return a * a == n ? true : false;
        }
        public static int SequenceSum(int start, int end, int step)
        {
            int sum = 0;
            if (start > end) return 0;
            else
            {
                for (int i = start; i <= end; i += step)
                {
                    sum += i;
                }
                return sum;
            }
        }
        public static string CamelCase(this string str)
        {
            if (str.Length == 0 || str == null)
                return String.Empty;

            return string.Concat(str.Split(new char[] { ' ' }).Select(x => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x)));
        }
        public static long MaxRot(long n)
        {
            char[] a = n.ToString().ToCharArray();

            for (int i = 2; i < a.Length; i++)
            {

            }
            return 0;
        }  // Not done
        public static int NbDig(int n, int d)
        {
            int res = 0;
            List<double> a = Enumerable.Range(0, n).Select(x => Math.Pow(x, 2)).Where(x => x.ToString().Contains(d.ToString())).ToList();
            for (int i = 0; i < a.Count; i++)
            {
                char[] b = a[i].ToString().ToCharArray();
                foreach (var q in b)
                {
                    if (q.ToString() == d.ToString())
                        res++;
                }

            }
            return res;

        }
        public static string Longest(string s1, string s2)
        {

            return String.Concat((s1 + s2).Distinct().OrderBy(x => x));
        }
        public static string PrinterError(String s)
        {
            return string.Concat(s.Where(x => (int)x > 109).Count().ToString(), '/', s.Length);
        }
        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n == 0)
                return Array.Empty<double>();
            double[] fib = new double[n];
            for (int i = 0; i < n && i < 3; i++)
            {
                fib[i] = signature[i];
            }

            for (int i = 3; i < n; i++)
            {
                fib[i] = fib[i - 3] + fib[i - 2] + fib[i - 1];
            }
            return fib;
        }
        public static long findNb(long m)
        {
            long res = 0;
            for (int i = 1; res <= m; i++)
            {
                res += (long)Math.Pow(i, 3);
                if (res == m)
                    return i;
            }
            return -1;
        }
        public static int GetSum(int a, int b)
        {
            return Enumerable.Range(Math.Min(a, b), Math.Abs(b - a) + 1).Sum();
        }
        public static string HighAndLow(string numbers)
        {
            return string.Join(" ", numbers.Split(' ').Select(x => int.Parse(x)).Max().ToString(), numbers.Split(' ').Select(x => int.Parse(x)).Min().ToString());
        }
        public static long digPow(int n, int p) // Not done
        {
            int res = 0, res2 = 0;
            char[] gg = n.ToString().ToArray();
            for (int i = 0; i < gg.Length; i++)
            {
                res += (int)gg[i] * p + i;
            }
            for (int d = 1; res2 * n < res; d++)
            {
                res2 = res * d;
                if (res2 * n == d)
                    return d;
            }
            return res == n * res2 ? res2 : -1;
        }
        //public static bool is_valid_IP(string ipAddres)
        //{
        //    string[] s = ipAddres.Split(new char[] { '.' });
        //    if (s.Length != 4 &&
        //        return false;
        //    return
        //} // not ddone 
        public static int TrailingZeros(int n)
        {
            int[] r = new int[n];
            r[0] = 1;
            int res = 0;
            for (int i = 1; i < n; i++)
            {
                r[i] *= i + 1;
            }
            for (int i = 10; i < r[n]; i *= 10)
            {
                if (r[n - 1] % i == 0)
                    res++;
            }
            return res;
        }  // not done 
        public static int GetVowelCount(string str)
        {

            return str.ToCharArray().Where(x => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u').Count();
        }
        public static bool comp(int[] a, int[] b)
        {
            return Array.Equals(a.Select(x => Math.Pow(x, 2)), b);
        }
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            double per = percent;
            if (per >= 1.00d)
            {
                if (per % 1 != 0)
                {
                    per = per / 10;
                }
                else
                {
                    per = per / 100;
                }

            }
            Console.WriteLine(per);

            double res = p0 + p0 * per + aug;
            int ii = 1;
            for (int i = 0; res <= p; i++)
            {
                res = res + res * per + aug;
                ii++;
            }
            return ii;
            Console.ReadKey();
        }
    }


    public class Opstrings
    {
        public static string VertMirror(string strng)
        {
            return string.Concat(string.Join("\n", strng.Split(new char[] { '\n' }).Select(x => { char[] a = Enumerable.Reverse(x.ToCharArray()).ToArray(); return new string(a); })));
        }
        public static string HorMirror(string strng)
        {
            return string.Concat(string.Join("\n", strng.Split(new char[] { '\n' }).Reverse()));
        }
        public delegate string a(string s);
        public static string Oper(a fct, string s)
        {
            return fct(s);
        }
    }
    // Kats end
}
