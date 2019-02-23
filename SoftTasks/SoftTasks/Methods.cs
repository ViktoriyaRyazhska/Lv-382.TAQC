using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks
{
    static class Methods
    {
        static public void PrintMethList()  // Add method name here
        {
            Console.WriteLine("1.Fibbonachi");
            Console.WriteLine("2.Mod_Fibbonachi");
            Console.WriteLine("3.FriendPairs");
            Console.WriteLine("0.Exit");
        }
        static public int Mod_Fibbonachi(int n)
        {

            if (n <= 3)
            {
                return 1;
            }
            return Mod_Fibbonachi(n - 1) + Mod_Fibbonachi(n - 3);
        }
        static public int Fibbonachi(int n)
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

        static public int FriendPairs(int n)
        {
            int[] arr = new int[n + 1];
 
            for (int i = 0; i <= n; i++)
            {
                if (i <= 2)
                    arr[i] = i;
                else
                    arr[i] = arr[i - 1] + (i - 1)
                                    * arr[i - 2];
            }
            return arr[n];
        }

    }
}
