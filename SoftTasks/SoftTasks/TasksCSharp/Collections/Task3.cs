using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Collections
{
    class Task3
    {
        public static double[] App(double[] arr)
        {
            double tmp, min;
            int minIndex;
            for (int i = 0, j; i < arr.Length; i++)
            {
                min = double.MaxValue;
                minIndex = 0;
                for (j = i; j < arr.Length; j++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                tmp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = tmp;
            }

            return arr;
        }

    }
}
