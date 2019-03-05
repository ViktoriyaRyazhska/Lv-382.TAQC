using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array16
    {
        public static void Index()
        {
            Console.WriteLine("Enter array length : ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int resIndex = -1;
            int s1 = 0;
            int s2 = 0;
            int c = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter element[" + i + "]: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int g = 0; g < arr.Length; g++)
            {
                for (int j = 0; j < g; j++)
                {
                    s1 = s1 + arr[j];
                }
                for (int k = g + 1; k < arr.Length; k++)
                {
                    s2 = s2 + arr[k];
                }
                if (s1 == s2)
                {
                    Console.WriteLine();
                    Console.WriteLine("index: " + g);
                    s1 = 0;
                    s2 = 0;
                    c++;
                }
                else
                {

                    s1 = 0;
                    s2 = 0;
                }
            }
            if (c == 0)
            {
                Console.WriteLine();
                Console.WriteLine("index: " + resIndex);
            }
        }
    }
}
