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
                foreach (string str in Methods.MethodsList)
                    Console.WriteLine(str);                 // List of methods
                string index = Console.ReadLine();
                if (index == "0")         // Exit
                {
                    break;
                }

                switch (index)  // Invoke method depents on number. Add your methods here as a case.
                {
                    case "1":
                        a = Methods.Fibbonachi;          // Delegate that contain your Method. Add according to template or write custome. 
                        Print(a);
                        break;
                    case "2":
                        a = Methods.Mod_Fibbonachi;
                        Print(a);
                        break;
                    case "3":
                        a = Methods.WayToCoverIn3Steps;
                        Print(a);
                        break;
                    case "4":
                        a = Methods.FriendPairs;
                        Print(a);
                        break;
                    case "5":
                        a = Methods.CountWays;
                        Print(a);
                        break;
                    case "6":
                        a = Methods.LongestSequenceWithDiff1;
                        Print(a);
                        break;
                    case "7":
                        a = Methods.WaysToWriteNAsSum;
                        Print(a);
                        break;
                    case "8":
                        a = Methods.countAllWays;
                        Print(a);
                        break;
                }
                Console.Clear();

            }

        }

        public static void Print(InvokeMeth a)
        {
            int n;
            Console.WriteLine("Enter number");
            try
            {
                n = int.Parse(Console.ReadLine().ToString());             
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Output:" + "\n" + a.Invoke(n));
            Console.ReadKey();
        }
    }
}
