using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array8
    {
        public static void TopSameD(int a, int b)
        {
            int rez;
            List<int> la = new List<int>();
            List<int> lb = new List<int>();
            for (int i = 0; i < a; i++)
            {
                if (a % i == 0)
                {
                    la.Add(i);
                }
            }
            for (int i = 0; i < b; i++)
            {
                if (b % i == 0)
                {
                    la.Add(i);
                }
            }
            for (int i = 0; i < la.Count; i++)
            {
                for (int j = 0; j < lb.Count; j++)
                {
                    if (la[i] == lb[i])
                    {
                        rez = la[i];
                    }
                    else
                    {
                        rez = 1;
                    }
                }
            }
            Console.WriteLine(rez);
        }
    }
}
