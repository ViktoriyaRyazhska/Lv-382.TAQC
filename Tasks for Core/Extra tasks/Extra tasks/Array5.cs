using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array5
    {
        public static void TriangleType()
        {
            Console.WriteLine("Enter side a: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter side b: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter side c: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || b + c <= a || a + c <= b)
            {
                Console.WriteLine("Triangle type: " + 0);
            }
            else if (a == b && b == c)
            {
                Console.WriteLine("Triangle type: " + 3);
            }
            else if (a == b || b == c || a == c)
            {
                Console.WriteLine("Triangle type: " + 2);
            }
            else
            {
                Console.WriteLine("Triangle type: " + 1);
            }
        }
    }
}
