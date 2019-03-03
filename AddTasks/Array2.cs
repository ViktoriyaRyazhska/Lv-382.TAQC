using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array1
{
    class Array2
    {
        public static void Row(int n)
        {
            if (n > 0)
            {
                double[] arr = new double[n];
                double ar0 = 0d;
                double ar1 = (double)5 / 8;
                if (n > 2)
                {
                    arr[0] = ar0;
                    arr[1] = ar1;
                    for (int i = 2; i < n; i++)
                    {
                        arr[i] = arr[i - 1] / 2d + arr[i - 2] * 3d / 4d;
                    }
                }
                else if (n == 2)
                {
                    arr[0] = 0;
                    arr[1] = ar1;
                }
                else if (n == 1)
                {
                    arr[0] = 0;
                }
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("arr[" + i + "]= " + arr[i]);
                }
            }
            else
            {
                Console.WriteLine("Enter elements quantity >= 1");
            }
        }
    }
}
