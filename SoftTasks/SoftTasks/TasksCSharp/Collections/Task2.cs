using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Collections
{
    class Task2
    {
        public static double[] App(double[] arr1, double[] arr2)
        {
            List<double> result = new List<double>(arr1);

            result.AddRange(arr2);

            result.Sort();
            return result.ToArray();
        }
    }
}
