using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array10
    {
        public static int Rad(int[] a, int r)
        {
            int counter = 0;
            int Lenght = a.Length;
            for (int i = 0; i < a.Length; i++)
            {
                if (Distance(a[i], a[Lenght - i]) <= r)
                    counter++;
            }
            return counter;
        }
        const int aX = 0;
        const int aY = 0;
        private static double Distance(int bX, int bY)
        {
            return Math.Sqrt(Math.Pow((bX-aX),2)+Math.Pow((aY-aX),2));
        }
    }
}
