using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array7
    {
        public static void NumberK(int k)
        {
            string row="";
            int[] arr = new int[90];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i+10;
                row += arr[i];
            }

            Console.WriteLine(row.Substring(k-1,1));
        }
    }
}
