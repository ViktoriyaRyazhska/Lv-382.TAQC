using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks
{
    class Program
    {
        public delegate int InvokeMeth(int i);

        static void Main(string[] args)
        {
            InvokeMeth a;
            while (true)
            {
                Console.WriteLine("Enter task number");
                Methods.PrintMethList();               // List of methods
                string index = Console.ReadLine();
                if(index == "0")         // Exit
                {
                    break;
                }
                switch (index)  // Invoke method depents on number. Add your methods here.
                {
                    case "1":
                        a = Methods.Fibbonachi;          // Delegate that contain your Method. Add according to template or write custome. 
                        Print(a);
                        break;
                    case "2":
                        a = Methods.Mod_Fibbonachi;
                        Print(a);
                        break;
                }
                Console.Clear();

            }

        }
        public static void Print(InvokeMeth a)
        {
            Console.WriteLine("Enter number");
            int n = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine(a.Invoke(n));
            Console.ReadKey();
        }
    }
}
