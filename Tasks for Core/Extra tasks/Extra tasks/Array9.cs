using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array9
    {
        public static void SumCos(int x)
        {
            double sum = Math.Cos(x);

            for (int i = x; i > 1; i--)
            {
                sum += Math.Cos((i-1)-sum);
            }
            Console.WriteLine(sum);
        }
    }
}
