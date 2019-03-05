using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array1
{
    class Class5
    {
        public static void NumberK(int k) //7
        {
            string row = "";
            int[] arr = new int[90];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 10;
                row += arr[i];
            }
            Console.WriteLine(row.Substring(k - 1, 1));
        }

        public static void TopSameD(int a, int b) //8

        {
            int rez = 1_000_000;
            int[] la = new int[a];
            int[] lb = new int[b];

            la[0] = 1;
            lb[0] = 1;
            for (int i = 0; i < a; i++)
            {
                if (a % (i + 1) == 0)
                {
                    la[i] = i + 1;
                }
            }
            for (int i = 0; i < b; i++)
            {
                if (b % (i + 1) == 0)
                {

                    lb[i] = i + 1;
                }
            }
            for (int i = 0; i < la.Length; i++)
            {
                for (int j = 0; j < lb.Length; j++)
                {
                    if (la[i] == lb[j] && la[i] != 0 && lb[j] != 0)
                    {
                        rez = la[i];

                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine(rez);

        }

        public static void SumCos(int x)  //9

        {
            double sum = Math.Cos(x);
            for (int i = x; i > 1; i--)
            {
                sum += Math.Cos((i - 1) - sum);

            }
            Console.WriteLine(sum);
        }

        public static int Rad(int[] a, int r)  //10
        {
            int counter = 0;
            int Lenght = a.Length;
            for (int i = 0; i < a.Length; i++)
            {
                if (Distance(a[i], a[Lenght - i]) <= r)
                    counter++;
            }
            return counter;
        }
        const int aX = 0;
        const int aY = 0;
        private static double Distance(int bX, int bY)
        {
            return Math.Sqrt(Math.Pow((bX - aX), 2) + Math.Pow((aY - aX), 2));
        }

        public static void TMax()  //11
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

        public static void AverageMark()  //12
        {
            Console.WriteLine("Enter n judgies: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter mark j[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            double sum = 0;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                sum += arr[i];
            }
            sum /= (arr.Length - 2);
            Console.WriteLine("Average mark is: " + sum);
        }

        public static void NatNumber()  //13

        {
            Console.WriteLine("Enter natural number: ");
            string str = Console.ReadLine();
            int[] arr = new int[str.Length];
            string str2 = "";
            for (int i = 0; i < arr.Length; i++)

            {
                arr[i] = int.Parse(str.Substring(i, 1));
                arr[i] = arr[i] * arr[i];
                str2 += arr[i];
            }
            Console.WriteLine("Rezult number is: " + str2);
        }


        public static void CountUnicSymbols()  //14

        {
            Console.WriteLine("Enter string: ");
            string str = Console.ReadLine();
            Console.WriteLine("Number distinct symbols is: " + str.ToCharArray().Distinct().Count());
        }

        public static void Sum2LovestElements()  //15

        {
            Console.WriteLine("Enter array length >= 4: ");
            int n = int.Parse(Console.ReadLine());
            double[] arr = new double[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter element[" + (i + 1) + "]: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            double sum = arr[0] + arr[1];
            Console.WriteLine("Sum 2 Lovest Elements is: " + sum);
        }


    }
}

