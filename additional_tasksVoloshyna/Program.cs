using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace additional_tasksVoloshyna
{
    class Program
    {
        static void Main(string[] args)
        {
            //CenturyOfYear(1901);
            //FourthTask(new int[] { 1, 3, 1});
            //SecondTask();
            //KPlace(5);
            Console.ReadKey();
        }
        static int CenturyOfYear(int year)
        {
            int century = 0;
            century = year / 100 + 1;
            Console.WriteLine(century);
            return century;
        }
        static void SecondTask()
        {
            double[] sums = new double[19];
            sums[0] = 0;
            sums[1] = 5/8;           
            for (int i = 2; i < 19; i++)
            {
                sums[i] = (sums[i - 1] / 2) + (sums[i - 2] * (3 / 4));                
                Console.WriteLine(sums[i]);
            }
        }

        static int FourthTask(int[] input)
        {
            List<int> sums = new List<int>();
            int tmp_sum = 0;
            foreach (int _element in input)
            {
                sums.Add(tmp_sum);
                tmp_sum += _element;
                Console.WriteLine(tmp_sum);
            }
            return tmp_sum;
        }

        static int TypeOfTriangle (int a, int b, int c)
        {
            int[] value = new int[3] { a, b, c };
            if ((a + b > c) && (b + c > a) && (a + c > b))
            {
                return 1;
            }
            else if (a == b || a == c || b == c)
            {
                return 2;
            }
            else if (a == b && a == c)
            {
                return 3;
            }
            
            return 0;
        }

        static int Number (int[] arr)
        {
            int numb = 0;
            if(arr[0] != arr[1] && arr[0] != arr[2] && arr[0] != arr[3])
            {
                numb = 1;
            }
            if (arr[1] != arr[0] && arr[1] != arr[2] && arr[1] != arr[3])
            {
                numb = 2;
            }
            if (arr[2] != arr[0] && arr[2] != arr[1] && arr[1] != arr[3])
            {
                numb = 3;
            }
            if (arr[3] != arr[0] && arr[3] != arr[1] && arr[3] != arr[3])
            {
                numb = 4;
            }
            return numb;
        }
        static string KPlace(int k)
        {
            string place = "";
            string numbs = "";
            for (int i = 10; i < 99; i++)
            {
                numbs += i.ToString();
            }
            place = numbs[k].ToString();
            Console.WriteLine(place);
            return place;
        }
        static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static double Cos()
        {
            double y = 40;
            for (int i = 39; i >=0; i--)
            {
                y = i + Math.Cos(y);
            }
            return y;
        }
    }


}

