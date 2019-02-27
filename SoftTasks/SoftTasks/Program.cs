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
                        Console.WriteLine("Input an array, e.g(4,5,2,7,8,1):");
                        int[] array = Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray();
                        Console.WriteLine("Input N");
                        int N = int.Parse(Console.ReadLine().ToString());
                        Console.WriteLine("Amount of ways: " + Methods.CountWays(N, array));
                        Console.ReadKey(); 
                        break;
                    case "6":
                        Console.WriteLine("Input an array, e.g(4,5,2,7,8,1):");
                        int[] readInput = Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray();
                        int res = Methods.LongestSequenceWithDiff1(readInput);
                        Console.WriteLine("Longest sequence is "+ res);
                        Console.ReadKey();
                        break;
                    case "7":
                        a = Methods.WaysToWriteNAsSum;
                        Print(a);
                        break;
                    case "8":
                        a = Methods.countAllWays;
                        Print(a);
                        break;
                    case "9":
                        a = Methods.Interesting_Rows;
                        Print(a);
                        break;
                    case "10":
                        Console.WriteLine("Enter number");
                        int n = int.Parse(Console.ReadLine().ToString());
                        Console.WriteLine("Enter high");
                        int[] higt = Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray();
                        Console.WriteLine("Enter low");
                        int[] low = Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray();
                        Console.WriteLine("Output:" + "\n" + Methods.maxTasks(higt, low, n).ToString());
                        Console.ReadKey();
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
