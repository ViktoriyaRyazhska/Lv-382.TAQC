using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array12
    {
        public static void AverageMark()
        {
            Console.WriteLine("Enter n judgies: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter mark j[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            Array.Sort(arr);

            double sum = 0;
            for (int i = 1; i < arr.Length-1; i++)
            {
                sum += arr[i];
            }
            sum /= (arr.Length - 2);
            Console.WriteLine("Average mark is: " + sum);
        }
    }
}
