using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Collections
{
    class Task7
    {
        public static void App(double[] values)
        {
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > values[i-1])
                {
                    Console.WriteLine("Chars are in descending order");
                }
                else if (values[i] < values[i-1])
                {
                    Console.WriteLine("Chars are in accending  order");
                }
            }
            Console.WriteLine("Chars are all equal");
        }

    }
}
