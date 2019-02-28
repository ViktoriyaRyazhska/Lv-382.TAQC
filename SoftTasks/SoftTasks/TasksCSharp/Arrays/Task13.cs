using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task13
    {
        public static long App(int num)
        {
            string nums = num.ToString();
            StringBuilder result = new StringBuilder();

            foreach (char ch in nums)
            {
                result.Append(Math.Pow(ch - '0',2));
            }
            return long.Parse(result.ToString());
        }
    }
}
