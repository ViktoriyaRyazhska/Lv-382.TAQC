using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array6
    {
        public static void NotEqualNumber()
        {
            Console.WriteLine("Enter  a1: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter  b2: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter  c3: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter  d4: ");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            int n;
            if (a == b && a == c || a == b && a == d || a == c && a == d || b == a && b == c || b == a && b == d || b == d && b == c || c == a && c == b || c == a && c == d || c == b && c == d || d == a && d == b || d == a && d == c || d == b && d == c)
            {


                if (a == b)
                {
                    if (a == c)
                    {
                        n = d;
                        Console.WriteLine(4);
                    }
                    else
                    {
                        n = c;
                        Console.WriteLine(3);
                    }

                }
                else
                {
                    if (a == c)
                    {
                        n = b;
                        Console.WriteLine(2);
                    }
                    else
                    {
                        n = a;
                        Console.WriteLine(1);
                    }
                }
            }
            else
            {
                Console.WriteLine("Entered incorrect values!");
            }
        }
    }
}
