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
            int rez = 1_000_000;
            int[] la = new int[a];
            int[] lb = new int[b];
           
            la[0] = 1;
            lb[0] = 1;
            for (int i = 0; i < a; i++)
            {
                if (a % (i+1) == 0)
                {
                    la[i]=i+1;
                    //Console.WriteLine(la[i]);
                }
            }
            for (int i = 0; i < b; i++)
            {
                if (b % (i+1) == 0)
                {
                    lb[i] = i+1;
                    //Console.WriteLine(lb[i]);
                }
            }
            for (int i = 0; i < la.Length; i++)
            {
                for (int j = 0; j < lb.Length; j++)
                {
                    if (la[i] == lb[j]&& la[i] !=0&& lb[j]!=0)
                    {
                         
                        rez = la[i];
                        

                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine(rez);
        }
    }
}
