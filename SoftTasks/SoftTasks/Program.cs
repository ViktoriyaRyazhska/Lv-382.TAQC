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
                Methods.PrintMethList();               // List of methods
                string index = Console.ReadLine();
                if(index == "0")         // Exit
                {
                    break;
                }
                switch (index)  // Depends on number invoke method. Add your method here.
                {
                    case "1":
                        Console.WriteLine("Enter number");    
                        Console.WriteLine(Methods.Fibbonachi(int.Parse(Console.ReadLine().ToString())));
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Enter number");
                        Console.WriteLine(Methods.Mod_Fibbonachi(int.Parse(Console.ReadLine().ToString())));
                        Console.ReadKey();
                        break;
                }
                Console.Clear();

            }

        }
    }
}
