using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
           //Some logic here
        }


        //=================== 1 ====================\\
        public static char GetChar(int charcode)
        {
            return (char)charcode;
        }

        //=================== 2 ==================\\
        public static int TotalPoints(string[] games)
        {
            byte sum = 0, x, y;
            foreach (string element in games)
            {
                x = (byte)element[0];
                y = (byte)element[2];
                if (x > y)
                {
                    sum += 3;
                }
                else if (x < y)
                {
                    sum += 0;
                }
                else
                {
                    sum += 1;
                }
            }
            return sum;
        }

        //=================== 3 ====================\\
        public static int PositiveSum(int[] arr)
        {
            int sum = 0;

            foreach (int element in arr)
            {
                if (element > 0)
                {
                    sum += element;
                }
            }

            return sum;
        }

        //=================== 5 ====================\\
        public static int Opposite(int number)
        {
            // Happy Coding
            return -1 * number;
        }

        //=================== 6 ====================\\



    }
}
