using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array1
{
    class Array3
    {
        public static void Sum30(int b)
        {
            int n = 30;
            double sum = 0d;
            if (b >= 0)
            {
                double[] arr = new double[n];
                for (int i = 0; i < n; i++)
                {
                    int a;
                    if (i % 2 == 1)
                    {
                        a = i;
                    }
                    else
                    {
                        a = i / 2;
                    }
                    arr[i] = Math.Pow((a - b), 2);
                    sum += arr[i];
                }
                Console.WriteLine("sum = " + sum);
            }
            else
            {
                Console.WriteLine("Enter b  >= 0");
            }
        }
    }
}
