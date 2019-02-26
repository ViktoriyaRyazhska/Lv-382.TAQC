using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    static class Program
    {
        static void Main(string[] args)
        {
           
            Console.ReadKey();
        }
        public static char GetChar(int charcode)
        {
            return (char)charcode;
        }   //1
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
        }   //2
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
        }   //3
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
        }   //4
        public static int Opposite(int number)
        {
            return -number;
        }   //5
        public static int summation(int num)
        {
            int sum = 0;
            for (int i = 1; i <= num; i++)
                sum += i;
            return sum;
        }   //6
        public static string AreYouPlayingBanjo(string name)
        {
            if (name.Substring(0, 1) == "R" || name.Substring(0, 1) == "r") return name + " plays banjo";
            else return name + " does not play banjo";
        }  //7
        public static string NoSpace(string input)
        {
            return input.Replace(" ", "");
        }//8
        public static List<int> ReverseList(List<int> list)
        {
            list.Reverse();
            return list;
        }   //9
        public static int[] CountPositivesSumNegatives(int[] input)
        {
            int[] rez = { 0, 0 };
            int f = 0;
            int s = 0;
            foreach (int a in input)
            {
                if (a > 0) f++;
                else s += a;
            }
            rez[0] = f;
            rez[1] = s;
            return rez;
        }   //10
        public static int FindSmallestInt(int[] args)
        {
            int temp = args[0];
            foreach (int a in args)
            {
                if (temp > a) temp = a;
            }
            return temp;
        }   //11
        public static int CountSheeps(bool[] sheeps)
        {
            int temp = 0;
            foreach (bool a in sheeps)
            {
                if (a == true) temp++;
            }
            return temp;
        }   //12
        public static string Remove_char(string s)
        {
            int l = s.Length;
            string s2 = s.Substring(1, l - 2);
            return s2;
        }   //13
        public static string EvenOrOdd(int number)
        {
            if (number % 2 == 0) return "Even";
            else return "Odd";
        }   //14
        public static int RentalCarCost(int d)
        {
            if (d >= 7) return d * 40 - 50;
            else if (d >= 3) return d * 40 - 20;
            else return d * 40;
        }   //15
        public static int MakeNegative(int number)
        {
            if (number <= 0) return number;
            else return -1 * number;
        }   //16
        public static string boolToWord(bool word)
        {
            if (word) return "Yes";
            else return "No";
        }   //17
        public static double basicOp(char operation, double value1, double value2)
        {
            if (operation == '+') return value1 + value2;
            else if (operation == '-') return value1 - value2;
            else if (operation == '*') return value1 * value2;
            else return value1 / value2;
        }   //18
        public static int GetSum(int a, int b)
        {
            return a + b;
        }   //19
        public static string seriesSum(int n)
        {
            decimal z = 1;
            decimal sum = 0;
            if (n == 0)
            {
                sum = 0.000001m;
            }
            for (int i = 0; i < n; i++)
            {
                sum += (1 / z);
                z += 3;
            }
            return System.Convert.ToString(Math.Round(sum, 2));
        }   //20
        public static bool IsSquare(int n)
        {
            int k = (int)Math.Sqrt(n);
            if (k * k == n) return true;
            else return false;
        }   //21
        public static string HighAndLow(string numbers)
        {

            string[] tokens = numbers.Split(' ');

            int[] ints = Array.ConvertAll<string, int>(tokens, int.Parse);

            int t1 = ints[0];
            int t2 = ints[0];
            for (int i = 0; i < ints.Length; i++)
            {
                if (t1 < ints[i])
                {
                    t1 = ints[i];
                }
                if (t2 > ints[i])
                {
                    t2 = ints[i];
                }
            }
            int[] rez = new int[2];
            rez[0] = t1;
            rez[1] = t2;
            string result = string.Join(" ", rez);
            return result;
        }   //22
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int ii = 1;
            double rez = p0 + p0 * percent / 100 + aug;
            for (int i = 0; ; i++)
            {
                rez = rez + rez * percent / 100 + aug;
                ii++;
                if (rez > p) break;
            }
            return ii;
        }   //23
        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;
            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str.Substring(i, 1).Equals("a") || str.Substring(i, 1).Equals("e")
                || str.Substring(i, 1).Equals("i") || str.Substring(i, 1).Equals("o")
                || str.Substring(i, 1).Equals("u")) vowelCount++;
            }
            return vowelCount;
        }    //24
        public static int FindShort(string s)
        {
            string[] ss = s.Split(new char[] { ' ' });
            int c1 = s.Length;
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i].Length < c1) { c1 = ss[i].Length; }
            }
            return c1;
        }    //25
        public static String Accum(string s)
        {
            char[] a = s.ToUpper().ToCharArray();
            string rez = a[0].ToString();
            for (int i = 1; i < a.Length; i++)
            {
                rez += "-" + a[i];
                for (int j = 1; j <= i; j++)
                {
                    rez += a[i].ToString().ToLower();
                }
            }
            return rez;
        }     //26
        public static int Mxdiflg(string[] a1, string[] a2)
        {
            int maxL1 = a1[0].Length;
            int minL1 = a1[0].Length;
            for (int i = 0; i < a1.Length; i++)
            {
                if (maxL1 < a1[i].Length) { maxL1 = a1[i].Length; }
                if (minL1 > a1[i].Length) { minL1 = a1[i].Length; }
            }
            int maxL2 = a2[0].Length;
            int minL2 = a2[0].Length;
            for (int i = 0; i < a2.Length; i++)
            {
                if (maxL2 < a2[i].Length) { maxL2 = a2[i].Length; }
                if (minL2 > a2[i].Length) { minL2 = a2[i].Length; }
            }
            int[] dif = { Math.Abs(maxL1 - minL2), Math.Abs(maxL2 - minL1) };
            if (dif[0] > dif[1]) return dif[0];
            else return dif[1];
        }    //27
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
        }   //28
        public static string VertMirror(string strng)
        {
            return string.Concat(string.Join("\n", strng.Split(new char[] { '\n' }).Select(x => { char[] a = Enumerable.Reverse(x.ToCharArray()).ToArray(); return new string(a); })));
        }   //29
        public static string HorMirror(string strng)
        {
            return string.Concat(string.Join("\n", strng.Split(new char[] { '\n' }).Reverse()));
        }
        public delegate string a(string s);
        public static string Oper(a fct, string s)
        {
            return fct(s);
        }
        public static long MaxRot(long n)
        {
            var str = n.ToString();
            var max = n;
            for (int i = 0; i < str.Length - 1; ++i)
            {
                str = str.Substring(0, i) + str.Substring(i + 1) + str[i];
                max = (long.Parse(str) > max) ? long.Parse(str) : max;
            }
            return max;
        }    //30
        public static int NbDig(int n, int d)
        {
            var result = d == 0 ? 1 : 0;
            for (var k = 1; k <= n; ++k)
            {
                for (var x = k * k; x != 0; x /= 10)
                {
                    if (x % 10 == d)
                    {
                        ++result;
                    }
                }
            }
            return result;
        }  //31
        public static string Longest(string s1, string s2)
        {
            return string.Concat((s1 + s2).Distinct().OrderBy(x => x));
        }   //32
        public static string PrinterError(String s)
        {
            int num = s.Select(c => IsValid(c)).Sum();
            return String.Format("{0}/{1}", num, s.Length);
        }
        public static int IsValid(char c)
        {
            if ('a' <= c && 'm' >= c)
                return 0;
            else
                return 1;
        }  //33
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
        }   //34
        public double[] Tribonacci(double[] signature, int n)
        {
            // hackonacci me
        }   //35
        public static string CamelCase(this string str)
        {
            string[] ss = str.Split(new char[] { ' ' });
            string sss;
            string ssf;
            string ssc;
            string ssss = "";
            for (int i = 0; i < ss.Length; i++)
            {
                ssf = ss[i].Substring(0, 1).ToUpper();
                ssc = ss[i].Substring(1, ss[i].Length - 1);
                sss = ssf + ssc;
                ssss += sss;
            }
            return ssss;
        }   //36
        public static long findNb(long m)
        {
            // your code
        }   //37
        public static string stockSummary(String[] lstOfArt, String[] lstOf1stLetter)
        {

        }   //38
        public static long digPow(int n, int p)
        {
            // your code
            return -1;
        }   //39
        public static bool is_valid_IP(string ipAddres)
        {
            return true;
        }   //40
        public static double Mean(string town, string strng)
        {
            // your code
        }   //41
        public static double Variance(string town, string strng)
        {
            // your code
        }
    }
}
