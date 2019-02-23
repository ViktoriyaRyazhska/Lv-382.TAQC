using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks
{
    static class Methods
    {
        static public int Fibonachi(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
        static public int Fibonachiv2(int n)
        {
            int f1 = 1;
            int f2 = 2;
            int fsum = 0;
            if (n == 1) fsum = f1;
            else if (n == 2) fsum = f2;
            for (int i = 2; i < n; i++)
            {
                fsum = f1 + f2;
                f1 = f2;
                f2 = fsum;
            }
            return fsum;
        }
    }
}
