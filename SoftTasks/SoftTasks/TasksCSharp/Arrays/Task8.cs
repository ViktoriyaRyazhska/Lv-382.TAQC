using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task8
    {
        //Euclidian algorithm
        public static int App(int a,int b)
        {
            int r;
            if (a < b)
            {
                r = a;
                a = b;
                b = r;
            }

            do
            {
                r = a % b;

                a = b;
                b = r;

            } while (r > 1);

            return a;
        }
    }
}
