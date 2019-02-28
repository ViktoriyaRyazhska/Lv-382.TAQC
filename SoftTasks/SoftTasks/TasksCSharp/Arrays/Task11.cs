using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task11
    {
        public static int[] App(int N,int[] t)
        {
            int[] c = new int[N];
            int tMin=t[0], tMinIndex=0;
            c[0] = 0;

            for (int i = 1; i < c.Length; i++)
            {
                c[i] = c[i - 1] + t[i - 1];
                if (tMin > t[i])
                {
                    tMin = t[i];
                    tMinIndex = i;
                }
            }
            Console.WriteLine(tMinIndex);

            return c;
        }
    }
}
