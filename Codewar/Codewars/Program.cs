using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Codewars
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            Console.WriteLine(WhoIsNext(names, 7230702951));
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
            return arr.Select(x => { var value = x > 0 ? x : 0; return value; }).Sum();
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
        }
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
        public static long digPow(int n, int p)
        {
            int k = p;
            long temp = (long)n.ToString().ToCharArray().Select(x => Math.Pow(int.Parse(x.ToString()), k++)).Sum();
            if (temp % n == 0)
            {
                return temp / n;
            }
            else
            {
                return -1;
            }

        }

        public static int TrailingZeros(int n)
        {
            var count = 0;

            for (int i = 5; n / i >= 1; i *= 5)
            {
                count += (int)(n / i);
            }

            return count;
        }
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
        public static string stockSummary(String[] lstOfArt, String[] lstOf1stLetter)
        {
            if (lstOfArt.Length == 0)
            {
                return "";
            }
            string result = "";
            foreach (string m in lstOf1stLetter)
            {
                int tot = 0;
                foreach (string l in lstOfArt)
                {
                    if (l[0] == m[0])
                    {
                        tot += int.Parse(l.Split(' ')[1]);
                    }
                }
                if (!String.IsNullOrEmpty(result))
                {
                    result += " - ";
                }
                result += "(" + m + " : " + tot + ")";
            }
            return result;

        }
        public static bool is_valid_IP(string ipAddres)
        {
            IPAddress ip;
            bool validIp = IPAddress.TryParse(ipAddres, out ip);
            return validIp && ip.ToString() == ipAddres;
        }
        public static double[] gett(string t, string s)
        {
            return s.Split('\n').First(x => x.Contains(t)).Split(',').Select(x => double.Parse(x.Split()[1])).ToArray();
        }
        public static double Mean(string t, string s)
        {
            return s.Contains(t + ":") ? gett(t, s).Average() : -1;
        }

        public static double Variance(string t, string s)
        {
            var p = Mean(t, s);
            return s.Contains(t + ":") ? gett(t, s).Select(x => (x - p) * (x - p)).Average() : -1;
        }
        public static string RevRot(string strng, int sz)
        {
            if (sz <= 0 || sz > strng.Length) return "";
            string[] arr = Enumerable.Range(0, (int)(strng.Length / sz))
                .Select(i => strng.Substring(i * sz, sz)).ToArray();
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i].ToCharArray().Select(x => Math.Pow(Char.GetNumericValue(x), 3)).Sum() % 2 == 0)
                    arr[i] = new string(arr[i].Reverse().ToArray());
                else arr[i] = arr[i].Substring(1, sz - 1) + arr[i].Substring(0, 1);
            }
            return String.Concat(arr);
        }
        public static bool comp1(int[] a, int[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                bool temp = false;
                for (int j = 0; j < b.Length; j++)
                {
                    Console.Write(a[i] * a[i] + " : " + b[j] + "|");
                    if (a[i] * a[i] == b[j])
                    {
                        temp = true;
                        a[i] = 0;
                        b[j] = 0;
                        break;
                    }
                }
                if (temp != true)
                    return false;
            }
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
            return true;
        }
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            int max = 0;
            if (k == 1)
            {
                for (int i = 0; i < ls.Count; i++)
                    if (ls[i] > max && ls[i] <= t) max = ls[i];
            }
            else
                for (int i = 0; i < ls.Count; i++)
                {
                    var val = chooseBestSum(t - ls[i], k - 1, ls.Skip(i + 1).ToList());
                    if (val.HasValue && val.Value + ls[i] > max && val.Value + ls[i] <= t)
                        max = val.Value + ls[i];
                }
            return max > 0 ? max : new int?();
        }
        public static string WhoIsNext(string[] names, long n)
        {
            string temp = "";
            Queue<string> queue = new Queue<string>(names.ToList());
            for (long i = 1; i <= n; i++)
            {
                temp = queue.Dequeue();
                if (i == n)
                {
                    break;
                }
                queue.Enqueue(temp);
                queue.Enqueue(temp);
            }
            return temp;
        }
        public static string[] dirReduc(String[] arr)  // Rebuild
        {
            string s = new string(arr.Select(x => x[0]).ToArray());
            while (Regex.Match(s, "NS|EW|SN|WE").Success) s = Regex.Replace(s, "NS|EW|SN|WE", "");
            return s.Select(x => x == 'N' ? "NORTH" : x == 'S' ? "SOUTH" : x == 'E' ? "EAST" : "WEST").ToArray();
        }
        public static string orderWeight(string strng)
        {
            return String.Join(" ", strng.Split(' ').OrderBy(x=>x).OrderBy(x => x.ToCharArray().Select(y => int.Parse(y.ToString())).Sum()).ToArray());
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
}

// Kats end

