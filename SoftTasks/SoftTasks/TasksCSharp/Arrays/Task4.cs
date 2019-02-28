using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task4
    {
        public static void App(int N, double[] values)
        {
            double sum = values[0];
            Console.WriteLine(sum);

            for (int i = 1; i < N; i++)
            {
                sum += values[i];
                Console.WriteLine(sum);
            }
        }
    }
}
