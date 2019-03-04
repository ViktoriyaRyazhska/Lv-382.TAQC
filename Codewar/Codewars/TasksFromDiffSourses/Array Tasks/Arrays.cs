using System;
using System.Linq;

namespace Codewars
{

    static class Arrays
    {
        const int aX = 0;
        const int aY = 0;
        public static void Task1(int year)
        {
            Console.WriteLine(((year - 1) / 100) + 1);
        }
        public static void Task2()
        {
            float[] res = new float[20];
            res[0] = 0f;
            res[1] = 5f / 8f;
            for (int i = 2; i < res.Length; i++)
            {
                res[i] = (res[i - 1] / 2) + ((3 / 2) * res[i - 2]);
            }
            foreach (var x in res)
            {
                Console.Write(x + " ");
            }
        }
        public static void Task4(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    if (j <= i)
                    {
                        temp += a[j];
                    }
                    else
                    {
                        break;
                    }

                }
                b[i] = Math.Abs(temp);
            }
            foreach (var n in b)
            {
                Console.Write(n + " ");
            }
        }
        public static int Task5(int a, int b, int c)
        {
            if (a + b > c || a + c > b || c + b > a || a == 0 || b == 0 || c == 0)
            {
                return 0;
            }
            else if (a == b || a == c || b == c)
            {
                return 2;
            }
            else if (a == b && b == c)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        public static void Task6(int[] a)
        {
            int[] b = a.Distinct().ToArray();
            int n = a.Where(x => x == b[0]).Count() == 1 ? b[0] : b[1];
            Console.WriteLine(Array.IndexOf(a, n) + 1);
        }
        public static void Task7(int k)
        {
            string b = String.Concat(Enumerable.Range(1, 180).Where(x => x.ToString().Length == 2).ToArray());
            char[] a = b.ToCharArray();
            Console.WriteLine(b + "\n" + a[k - 1]);

        }
        public static void Task8(int a, int b)
        {
            int c = 0;
            int min = Math.Min(a, b);
            for (int i = 1; i <= min; i++)
            {
                if (a % i == 0 && b % i == 0)
                    c = i;
            }
            Console.WriteLine("Higher divide by value: " + c);
        }
        public static void Task9()
        {
            double[] a = new double[40];
            a[0] = 39d + Math.Cos(40d);
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = (39d - i) + Math.Cos(a[i-1]);
            }
            Console.WriteLine(a.Last());
        }
        public static int Task10(int[] a, int r)
        {
            int counter = 0;
            int Lenght = a.Length;
            for (int i = 0; i < a.Length; i++)
            {
                if (Distance(a[i], a[Lenght - i]) <= r)
                    counter++;
            }
            return counter;
        }
        private static double Distance(int bX, int bY)
        {
            return Math.Sqrt(Math.Pow((bX-aX),2)+Math.Pow((aY-aX),2));
        }
        public static void Task11()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter t[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            double sum = 0;
            double ci = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > ci)
                {
                    ci = arr[i];

                }
                sum += arr[i];
                Console.WriteLine("t ci " + sum);
            }
            Console.WriteLine("");
            Console.WriteLine("t Max= " + ci);
        }
        public static void Task12()
        {
            Console.WriteLine("Enter n judgies: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter mark j[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            Array.Sort(arr);

            double sum = 0;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                sum += arr[i];
            }
            sum /= (arr.Length - 2);
            Console.WriteLine("Average mark is: " + sum);
        }
        public static void Task13()
        {
            Console.WriteLine("Enter natural number: ");
            string str = Console.ReadLine();
            int[] arr = new int[str.Length];

            string str2 = "";
            for (int i = 0; i < arr.Length; i++)
            {

                arr[i] = int.Parse(str.Substring(i, 1));
                arr[i] = arr[i] * arr[i];
                str2 += arr[i];
            }
            Console.WriteLine("Rezult number is: " + str2);
        }
        public static void Task14()
        {
            Console.WriteLine("Enter string: ");
            string str = Console.ReadLine();
            Console.WriteLine("Number distinct symbols is: " + str.ToCharArray().Distinct().Count());

        }
        public static void Task16()
        {
            Console.WriteLine("Enter array length >= 4: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter element[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            Array.Sort(arr);

            double sum = arr[0] + arr[1];

            Console.WriteLine("Sum 2 Lovest Elements is: " + sum);
        }

        public static int Task16(int[] arr)
        {
            int indexer = -1;
            int r, l;
            for (int i = 0; i < arr.Length; i++)
            {
                r = 0;
                l = 0;
                for (int j = 0; j < i; j++)
                {
                    l += arr[j];
                }
                for (int j = i + 1; j < arr.Length; j++)
                {
                    r += arr[j];
                }
                Console.WriteLine(l + " " + r);
                if (l == r)
                {
                    indexer = i;
                    break;
                }

            }
            return indexer;
        }
    }
}
