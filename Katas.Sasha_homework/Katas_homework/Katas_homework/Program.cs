using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Katas_homework
{
    public static class Program
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


        public static List<int> ReverseList(List<int> list)    //Reverse List Order
        {
            return Enumerable.Reverse(list).ToList();
        }


        public static int[] CountPositivesSumNegatives(int[] input)    //Count of positives / sum of negatives
        {
            int[] arr2 = new int[0];
            if (input == null || input.Length == 0) return arr2;
            else
            {
                int[] arr = new int[2];
                int count = 0, sum = 0;
                foreach (int element in input)
                {
                    if (element > 0) count++;
                    else if (element < 0) sum += element;
                }

                arr[0] = count;
                arr[1] = sum;


                return arr;
            }
        }


        public static int FindSmallestInt(int[] args)     //Find the smallest integer in the array
        {
            int min = args[0];
            foreach (int arg in args)
            {
                if (arg < min) min = arg;
            }
            return min;
        }


        public static int CountSheeps(bool[] sheeps)     //Counting sheep...
        {
            int count = 0;
            foreach (bool sheep in sheeps)
            {
                if (sheep == true) count++;
            }
            return count;
        }


        public static string Remove_char(string s)    //Remove First and Last Character
        {
            if (s.Length > 2)
            {
                s = s.Substring(1, s.Length - 2);
                return s;
            }
            else return "";
        }


        public static string EvenOrOdd(int number)    //Even or Odd
        {
            if (number % 2 == 0) return "Even";
            else return "Odd";
        }


        public static int RentalCarCost(int d)    //Transportation on vacation
        {
            int total = 0;
            if (d < 3)
            {
                total = d * 40;
            }
            else if (d >= 3 && d < 7)
            {
                total = d * 40 - 20;
            }
            else total = d * 40 - 50;

            return total;
        }


        public static int MakeNegative(int number)    //Return Negative
        {
            if (number <= 0) return number;
            else return number * -1;
        }


        public static string boolToWord(bool word)    //Convert boolean values to strings 'Yes' or 'No'.
        {
            if (word == true) return "Yes";
            else return "No";
        }


        public static double basicOp(char operation, double value1, double value2)    //Basic Mathematical Operations
        {
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = value1 + value2;
                    break;
                case '-':
                    result = value1 - value2;
                    break;
                case '*':
                    result = value1 * value2;
                    break;
                case '/':
                    result = value1 / value2;
                    break;
                default:
                    break;
            }
            return result;
        }


        public static int GetSum(int a, int b)    //Beginner Series #3 Sum of Numbers
        {
            int sum = 0;
            if (a < b)
            {
                for (int i = a; i <= b; i++)
                    sum += i;
            }
            else if (a > b)
            {
                for (int i = b; i <= a; i++)
                    sum += i;
            }
            else sum = a;

            return sum;
        }


        public static string seriesSum(int n)    //Sum of the first nth term of Series
        {
            if (n == 0) return "0.00";
            else
            {
                double sum = 1, i = 1, temp = 4;
                while (i < n)
                {
                    sum += 1 / temp;
                    i++;
                    temp += 3;
                }
                return sum.ToString("N2");
            }
        }


        public static bool IsSquare(int n)    //You're a square!
        {
            double result = Math.Sqrt(n);
            return result % 1 == 0;
        }


        public static string HighAndLow(string numbers)    //Highest and Lowest
        {
            string[] tokens = numbers.Split(' ');
            int[] array = Array.ConvertAll<string, int>(tokens, int.Parse);
            int min = array[0], max = array[0];
            foreach (int arr in array)
            {
                if (arr < min) min = arr;
                if (arr > max) max = arr;
            }
            return max + " " + min;
        }


        public static int NbYear(double p0, double percent, int aug, int p)    //Growth of a Population
        {
            int year = 0;
            while (p0 < p)
            {
                p0 += Math.Truncate(p0 * (percent / 100)) + aug;
                year++;
            }
            return year;
        }


        public static int GetVowelCount(string str)    //Vowel Count
        {
            int vowelCount = 0;

            str = str.Replace(" ", "");
            char[] arr = str.ToCharArray();
            foreach (char c in arr)
            {
                if (c == 'a' || c == 'e' || c == 'u' || c == 'i' || c == 'o')
                    vowelCount++;
            }

            return vowelCount;
        }


        public static int FindShort(string s)    //Shortest Word
        {
            string[] strArray = s.Split(' ');
            int length = strArray[0].Length;
            foreach (string str in strArray)
            {
                if (str.Length < length)
                    length = str.Length;
            }
            return length;
        }


        public static int Mxdiflg(string[] a1, string[] a2)    //Maximum Length Difference
        {
            if (a1.Length == 0 || a2.Length == 0)
                return -1;
            else
            {
                int max = Math.Abs(a1[0].Length - a2[0].Length);
                foreach (string str1 in a1)
                {
                    foreach (string str2 in a2)
                    {
                        if (max < Math.Abs(str1.Length - str2.Length))
                            max = Math.Abs(str1.Length - str2.Length);
                    }
                }
                return max;
            }
        }


        public static String Accum(string s)    //Mumbling
        {
            List<string> list = new List<string>();

            for (int i = 0; i < s.Length; i++)
                list.Add(s[i].ToString().ToLower());

            for (int i = 0; i < s.Length; i++)
            {
                string temp = list[i];
                list[i] = list[i].ToUpper();
                
                for (int j = 0; j < i; j++)
                {
                    list[i] += temp;
                }
            }
            return String.Join("-", list);
        }


        public static string[][] Partlist(string[] arr)    //Parts of a list
        {
            string[][] res = new string[arr.Length - 1][];
            for (int i = 1; i < arr.Length; ++i)
            {
                var first = string.Join(" ", arr.Take(i));
                var other = string.Join(" ", arr.Skip(i));
                res[i - 1] = new string[] { first, other };
            }
            return res;
        }


        public static string VertMirror(string strng)    //Moves in squared strings (I)
        {
            return string.Join("\n", strng.Split('\n').Select(i => string.Concat(i.Reverse())));
        }
        public static string HorMirror(string strng)     //Moves in squared strings (I)
        {
            return string.Join("\n", strng.Split('\n').Reverse());
        }   
        public static string Oper(Func<string, string> fct, string s)    //Moves in squared strings (I)
        {
            return fct(s);
        }


        public static double[] Tribonacci(double[] signature, int n)   //Tribonacci Sequence
        {
            if (n == 0) return new double[] { };

            double[] result = new double[n];


            if (n < signature.Length)
            {
                for (int i = 0; i < n; i++)
                {
                    result[i] = signature[i];
                }

                return result;
            }

            for (int i = 0; i < signature.Length; i++)
                result[i] = signature[i];

            for (int i = signature.Length; i < n; i++)
            {
                result[i] = result[i - 1] + result[i - 2] + result[i - 3];
            }
            return result;
        }


        public static string CamelCase(this string str)      //CamelCase Method
        {
            str = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
            return str.Replace(" ", "");
        }


        public static long findNb(long m)    //Build a pile of Cubes
        {
            decimal sum = 0;
            int n = 0;

            while (sum < m)
            {
                n++;
                sum += Convert.ToDecimal(Math.Pow(n, 3));
            }

            if (sum == m) return n;
            else return (-1);
        }


        public static int TrailingZeros(int n)    //Number of trailing zeros of N!
        {
            int count = 0;


            for (int i = 5; n / i >= 1; i *= 5)
                count += n / i;

            return count;
        }


        public static string WhoIsNext(string[] names, long n)    //Double Cola
        {
            var result = Enumerable.Range(1, names.Length)
              .Select((m, i) => new { m, i })
              .ToDictionary(x => x.i, x => (long)1);
            long k = 0;
            while (n > 0)
                result = result.Select(i =>
                {
                    if (n > 0)
                    {
                        n -= i.Value;
                        if (n > 0)
                            k = i.Key + 1 > names.Length - 1 ? 0 : i.Key + 1;
                    }
                    return i.Value * 2;
                })
                 .Select((m, i) => new { m, i })
                 .ToDictionary(x => x.i, x => x.m);

            return names[k];
        }


        public static string Longest(string s1, string s2)   //Two to One
        {
            return new string((s1 + s2).Distinct().OrderBy(x => x).ToArray());
        }


        public static string PrinterError(String s)    //Printer Errors
        {
            string goodAlphabet = "abcdefghijklm";
            int errorCount = 0;
            foreach (char x in s)
                if (!(goodAlphabet.Contains(x)))
                    errorCount += 1;
            return errorCount + "/" + s.Length;
        }


        public static int SequenceSum(int start, int end, int step)    //Sum of a sequence
        {
            if (start > end)
                return 0;
            int sum = 0;
            for (int i = start; i <= end; i += step)
                sum += i;
            return sum;
        }


        public static bool is_valid_IP(string ipAddres)    //IP Validation
        {
            if (ipAddres == null || ipAddres.Length == 0)
            {
                return false;
            }

            if (Regex.Match(ipAddres, @"^(([1-9]?\d|1\d\d|2[0-4]\d|25[0-5])(\.(?!$)|$)){4}$").Success)
                return true;
            else return false;
        }


        public static long MaxRot(long n)     //Rotate for a Max
        {
            long max = n;
            string number = n.ToString();
            for (int i = 0; i < number.Length - 1; i++)
            {
                number = number.Substring(0, i) + number.Substring(i + 1) + number[i];
                n = long.Parse(number);
                if (n > max) max = n;
            }
            return max;
        }


        public static int NbDig(int n, int d)     //Count the Digit
        {

            int count = 0;

            for (int k = 0; k <= n; k++)
            {
                string k2 = (k * k).ToString();

                for (int i = 0; i < k2.Length; i++)
                {
                    if (k2[i] == d.ToString()[0])
                        count++;

                }
            }
            return count;
        }


        public static string stockSummary(String[] lstOfArt, String[] lstOf1stLetter)     //Help the bookseller !
        {
            if (lstOfArt.Length == 0 || lstOf1stLetter.Length == 0)
                return string.Empty;

            List<string> values = new List<string>();

            foreach (string s in lstOf1stLetter)
            {
                int sum = lstOfArt.Where(a => a.StartsWith(s)).Select(a => int.Parse(a.Split(' ')[1])).Sum();
                values.Add(string.Format("({0} : {1})", s, sum));
            }

            return string.Join(" - ", values.ToArray());
        }


        public static long digPow(int n, int p)     //Playing with digits
        {
            int countOfDigitsMinusOne = (int)Math.Log10(n);
            p = p + countOfDigitsMinusOne;
            int nk = 0;
            int N = n;
            while (N != 0)
            {
                int digit = N % 10;
                nk += (int)Math.Pow(digit, p);
                N /= 10;
                p--;
            }
            if (nk % n == 0)
                return nk / n;
            return -1;
        }


        public static string orderWeight(string s)      //Weight for weight
        {
            return string.Join(" ", s.Split(' ')
                .OrderBy(n => n.ToCharArray()
                .Select(c => (int)char.GetNumericValue(c)).Sum())
                .ThenBy(n => n));
        }







        static void Main(string[] args)
        {
            
        }
    }
}
