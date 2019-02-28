using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array11
    {
        public static void TMax()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter t[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            double sum = 0;
            double ci = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > ci)
                {
                    ci = arr[i];
                    
                }
                sum += arr[i];
                Console.WriteLine("t ci " + sum);
            }
            Console.WriteLine("");
            Console.WriteLine("t Max= " + ci);
        }
    }
}
