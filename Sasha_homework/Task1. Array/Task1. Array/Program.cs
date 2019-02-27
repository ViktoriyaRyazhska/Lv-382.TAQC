using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Array
{
    class Program
    {
        public static int CenturyFromYear(int year)
        {
            return (int)(year / 100) + ((year % 100 == 0) ? 0 : 1);
        }

        public static void SequenceByFormula2(int n)
        {
            double[] array = new double[n];
            array[0] = 0;
            array[1] = 5 / 8;
            int k1 = 1;
            int k2 = 2;
            for (int i = 2; i < n; i++)
            {
                array[i] = array[i - 1] * k1 / k2;
                k1 += 2;
                k2 += 2;
            }

            foreach (double d in array)
            {
                System.Console.WriteLine(d + " ");
            }
        }

        public static double SumByFormula3(double b)
        {
            int n = 30;
            double sum = 0;
            double a;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    a = i / 2;
                }
                else
                {
                    a = i;
                }
                sum += (a - b) * (a - b);
            }
            return sum;
        }

        public static double[] ArrayValuesToAbs(double[] array)
        {
            double[] result = new double[array.Length];
            result[0] = Math.Abs(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                result[i] = Math.Abs(result[i - 1] + array[i]);
            }
            return result;
        }

        public static int TriangleType(int a, int b, int c)
        {
            int[] values = new int[3] { a, b, c };

            if (a <= 0 || b <= 0 || c <= 0)
            {
                return 0;
            }
            else if (values.Distinct().Count() == 1)
            {
                return 3;
            }
            else if (values.Distinct().Count() == 2)
            {
                return 2;
            }
            else if (values.Distinct().Count() == 3)

            {
                return 1;
            }
            else
            {
                return 0;
            };
        }

        public static void NumberOfDifferValue(double[] array)
        {
            int n = 0;
            if ((array[0] != array[1]) && (array[0] != array[2]) && (array[0] != array[3]))
            {
                n = 0;
            }
            else if ((array[1] != array[0]) && (array[1] != array[2]) && (array[1] != array[3]))
            {
                n = 1;
            }
            else if ((array[2] != array[0]) && (array[2] != array[1]) && (array[2] != array[3]))
            {
                n = 2;
            }
            else
            {
                n = 3;
            }

            Console.WriteLine("n = " + n);
        }

        public static int DigitOnKPlace(int k)
        {
            string sequence = "";
            for(int i = 10; i <= 99; i++)
            {
                sequence += i.ToString();
            }
            return int.Parse(sequence[k].ToString());
        }
        
        public static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static double CosOfSum(int n)
        {
            double y = 40;
            for (int i = 39; i >= 0; --i)
            {
                y = i + Math.Cos(y);
            }
            return y;
        }

        public static int AmountOfDotsinCircle(int n, double r, double[]a)
        {
            int count = 0;
            if(n < 2)
            {
                return -1;
            }
            else
            {
                for(int i = 0; i < n; i++)
                {
                    if(Math.Sqrt(a[i] * a[i] + a[n-i] * a[n-i])  <= r)
                    {
                        count++;
                    }
                }
            }

            return count;       
        }

        public static int CustomerWaitedTheLongest(int n, int[] t)
        {
            int[] c = new int[n];
            c[0] = 0;
            for(int i = 0; i < n; i++)
            {
                c[i] += t[i];
            }
            int min = c[0];
            int number = 0;
            for(int i = 0; i < n; i++)
            {
                if(c[i] < min)
                {
                    min = c[i];
                    number = i;
                }
            }
            return number + 1;
        }

        public static int GradeForSportsman(int n, int [] a)
        {
            int sum = 0;
            if (n < 3)
            {
                return -1;
            }
            else
            {
                System.Array.Sort(a);
                for(int i = 1; i < n-1; i++)
                {
                    sum += a[i];
                }
            }
            return Convert.ToInt32(sum / (n - 2));
        }

        public static int NumberFromDigitsSquare(int n)
        {
            int[] digits = System.Array.ConvertAll(n.ToString().ToArray(), x => (int)x - 48);
            string res = "";
            foreach (int d in digits)
            {
                res += (d * d).ToString();
            }
            return Convert.ToInt32(res);
        }

        public static int AmountOfUnique(string str)
        {
            return str.Distinct().Count()
;       }

        public static long SumOfTwoSmallest(long [] array)
        {
            System.Array.Sort(array);
            return array[0] + array[1];
        }

        public static int IndexThatSplitsInEqualSums(int [] arr)
        {
            int leftSum = arr[0];
            int rightSum = arr[arr.Length-1];
            int i = 1;
            int j = arr.Length-2;
            while(i != j)
            {
                if (leftSum <= rightSum)
                {
                    leftSum += arr[i++];
                }
                else if (rightSum < leftSum)
                {
                    rightSum += arr[j--];
                }              
            }
            if (rightSum == leftSum)
            {
                return i;
            }
            else return -1;
        }


        static void Main(string[] args)
        {

            
        }
    }
}
