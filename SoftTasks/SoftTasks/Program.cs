using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter task number");
                string index = Console.ReadLine();
                switch (index)
                {
                    case "0":
                        break;
                    case "1":
                        Console.WriteLine("Enter fib 1 number");
                        Console.WriteLine(Methods.Fibonachi(int.Parse(Console.ReadLine().ToString())));
                        break;
                    case "2":
                        Console.WriteLine("Enter fib 2 number");
                        Console.WriteLine(Methods.Fibonachi2(int.Parse(Console.ReadLine().ToString())));
                        break;
                }

            }

        }
    }
}
