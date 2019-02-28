using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task2
    {
        public static void App()
        {
            int N = 20;
            double[] values = new double[N];
            values[0] = 0;
            values[1] = 5.0 / 8.0;
            Console.WriteLine(values[0]);
            Console.WriteLine(values[1]);

            for (int i = 2; i < N; i++)
            {
                values[i] = (values[i] - 1) / 2 + values[i - 2] * 3 / 4;
                Console.WriteLine(values[i]);
            }

        }
    }
}
