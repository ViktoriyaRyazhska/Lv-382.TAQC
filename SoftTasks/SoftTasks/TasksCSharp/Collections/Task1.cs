using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Collections
{
    class Task1
    {
        public static double[] App(double[] values, double value)
        {
            List<double> result = new List<double>(values);
            result.Add(value);
            result.Sort();

            return result.ToArray();
        }
    }
}
