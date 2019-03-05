using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array1
    {
        public static int Century()
        {
            Console.Write("Enter year: ");
            int z;
            int x = int.Parse(Console.ReadLine());
            if (x > 0)
            {
                double y = (x / 100.00d);
                if ((y % 1) > 0.00d)
                {
                    z = (int)(y + 1);
                    Console.WriteLine("Century: " + z);
                    return z;
                }
                else
                {
                    Console.WriteLine("Century: " + y);
                    return (int)y;
                }
            }
            Console.WriteLine("Enter year > 0");
            return 0;
        }
    }
}
