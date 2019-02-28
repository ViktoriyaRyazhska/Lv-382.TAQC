using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array13
    {
        public static void NatNumber()
        {
            Console.WriteLine("Enter natural number: ");
            string str = Console.ReadLine();
            int[] arr = new int[str.Length];

            string str2 = "";
            for (int i = 0; i < arr.Length; i++)
            {

                arr[i] = int.Parse(str.Substring(i, 1));
                arr[i] = arr[i] * arr[i];
                str2 += arr[i];
            }
            Console.WriteLine("Rezult number is: " + str2);
        }
    }
}
