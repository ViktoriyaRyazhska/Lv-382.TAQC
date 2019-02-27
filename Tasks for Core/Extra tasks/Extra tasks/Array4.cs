using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array4
    {
        public static void Row2()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            double[] arr2 = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter arr[" + i + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            double sum = 0d;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                Console.WriteLine("arr[" + i + "]= " + sum);
            }
        }
    }
}
