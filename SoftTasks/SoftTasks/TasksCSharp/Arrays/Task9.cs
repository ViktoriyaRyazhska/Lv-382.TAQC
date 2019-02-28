using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task9
    {
        public static double App()
        {
            int N = 40;
            double value = N;

            for (int i = N-1; i>0; i--)
            {
                value = N + Math.Cos(value);
            }
            return Math.Cos(value);
        }
    }
}
