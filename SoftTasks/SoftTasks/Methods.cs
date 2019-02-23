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
            Console.WriteLine("3.Ways to sum array elements with repetition");
            Console.WriteLine("0.Exit");
        }
        static public int Mod_Fibbonachi(int n)

    
        static public List<String> MethodsList = new List<string>() { "1.Fibbonachi", "2.Mod_Fibbonachi",
            "3.WayToCoverIn3Steps", "4.FriendPairs", "8.Paths without crossing" , "0.Exit" };    // Add method name befor "0.Exit"



        static public int Mod_Fibbonachi(int n)                  //2
        {

            if (n <= 3)
            {
                return 1;
            }
            return Mod_Fibbonachi(n - 1) + Mod_Fibbonachi(n - 3);
        }


        static public int Fibbonachi(int n)                   // 1
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

        /// <summary>
        /// Khrystyna Fedun
        /// </summary>
        public static int CountWays(int N)
        {
            Console.WriteLine("Input array, e.g(1,4,3,7):");

            string[] values = Console.ReadLine().Split(',');
            int[] arr = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                arr[i] = int.Parse(values[i]);
            }
            int[] count = new int[N + 1];
            count[0] = 1;


            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {

                    if (i >= arr[j])
                    {
                        count[i] += count[i - arr[j]];
                    }
                }
            }

            Console.Write("Count ways:");
            return count[N];
        }

        static public int WayToCoverIn3Steps(int n)           // 3
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            return WayToCoverIn3Steps(n - 1) + WayToCoverIn3Steps(n - 2) + WayToCoverIn3Steps(n - 3);
        }


        static public int FriendPairs(int n)                  //4
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


        static public int myPairs(int n)
        {
            int[] myArr = new int[n + 1];
            myArr[0] = myArr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                myArr[i] = 0;
                for (int j = 0; j < i; j++)
                    myArr[i] += myArr[j] * myArr[i - j - 1];
            }
            return myArr[n];
        }
        static public int countAllWays(int n)
        {
            if (n <= 1)
            {
                Console.WriteLine("Invalid");
                return 0;
            }
            return myPairs(n / 2);
        }


    }
}
