using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array1
{
    class Array4
    {
        public static void Row2()

        {
            public static double[] Sequence(double[] array)

            {
                double[] result = new double[array.Length];
                result[0] = Math.Abs(array[0]);
                for (int i = 1; i < array.Length; i++)
                {
                    result[i] = Math.Abs(result[i - 1] + array[i]);
                }
                return result;
            }



            public static int Triangle(int a, int b, int c)
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



            public static void Numbers(double[] array)
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

        }
    }
}
