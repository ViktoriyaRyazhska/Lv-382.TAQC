using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Array14
    {
        public static void CountUnicSymbols()
        {
            Console.WriteLine("Enter string: ");
            string str = Console.ReadLine();
            Console.WriteLine("Number distinct symbols is: " + str.ToCharArray().Distinct().Count());

        }
    }
}
