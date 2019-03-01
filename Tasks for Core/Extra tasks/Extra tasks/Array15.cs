using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array15
    {
        public static void Sum2LovestElements()
        {
            Console.WriteLine("Enter array length >= 4: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter element[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            Array.Sort(arr);

            double sum = arr[0]+ arr[1];
            
            Console.WriteLine("Sum 2 Lovest Elements is: " + sum);
        }
    }
}
