using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    public class ArraysTask
    {
        public static int Century(int year)
        {
            int res = year % 100 == 0 ? year / 100 : year / 100 + 1;
            Console.WriteLine(res);
            return res;
        }

        public static double[] StrangeSequence()
        {
            double[] res = new double[20];
            res[0] = 0;
            res[1] = 5.0 / 8.0;
            for (int i = 2; i < 20; i++)
            {
                res[i] = res[i - 1] / 2 + 3 * res[i - 2] / 4;
            }
            foreach (double d in res)
            {
                Console.WriteLine(d);
            }
            return res;
        }

        public static double[] StrangeSum(double[] input)
        {
            double[] res = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    res[i] += input[j];
                }
                res[i] = Math.Abs(res[i]);
            }
            foreach (double d in res)
            {
                Console.WriteLine(d);
            }
            return res;
        }

        public static int Triangle(int a, int b, int c)
        {
            int res = 0;
            if (a + b > c && b + c > a && a + c > b)
            {
                if (a == b && a == c)
                {

                    res = 3;
                }
                else if (a == b || b == c || a == c)
                {
                    res = 2;
                }
                else
                {
                    res = 1;
                }
            }
            Console.WriteLine(res);
            return res;
        }

        public static int Different(int[] a)
        {
            int res = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0)
                {
                    if (a[i] != a[i + 1] && a[i] != a[a.Length - 1])
                    {
                        res = i;
                    }
                }
                else if (i == a.Length - 1)
                {
                    if (a[i] != a[i - 1] && a[i] != a[0])
                    {
                        res = i;
                    }
                }
                else
                {
                    if (a[i] != a[i - 1] && a[i] != a[i + 1])
                    {
                        res = i;
                    }
                }
            }
            Console.WriteLine(res);

            return res;
        }

        public static int NumInPos(int k)
        {
            int num = 10;
            int counter = 2;
            while (counter < k)
            {
                num++;
                counter += 2;
            }
            if (k % 2 == 0)
            {
                Console.WriteLine(num % 10);
                return num % 10;
            }
            else
            {
                Console.WriteLine(num / 10);
                return num / 10;
            }
        }

        public static double StrangeSin()
        {
            double res = Math.Sin(40);
            for (int i = 39; i > 0; i--)
            {
                res = Math.Sin(i + res);
            }
            Console.WriteLine(res);
            return res;
        }

        public static int NumOfUniqueSymbols(string input)
        {
            int counter = 0;
            for (char c = ' '; c < '~'+ 1; c++)
            {
                if (input.Contains(c))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
            return counter;
        }
        public static int SumOf2Min(int[] input)
        {
            int sum = 0;
            List<int> nums = input.ToList<int>();
            sum += nums.Min();
            nums.Remove(nums.Min());
            sum += nums.Min();
            Console.WriteLine(sum);
            return sum;
        }
    }
}
