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
                return 1;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
        static public int Fibonachi2(int n)
        {
            int s = 0;
            for(int i = 1; i<=n; i++)
            {
                if (i == 1)
                {
                    s = 1;
                }
                if (i == 2)
                {
                    s = 2;
                }
                s += (s - 2) + (s - 1);
            }
            return s;
        }
    }
}
