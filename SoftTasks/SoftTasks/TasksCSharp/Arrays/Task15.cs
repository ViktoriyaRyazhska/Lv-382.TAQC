using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task15
    {
        public static int App(int[] nums)
        {
            int min = nums[0], max = nums[0];

            foreach (int num in nums)
            {
                if (min > num) min = num;
                if (max < num) max = num;
            }

            return min + max;
        }
    }
}
