using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task16
    {
        public static int App(int[] nums)
        {
            int left = 0,right=0;

            for (int i = 2; i < nums.Length; i++)
            {
                right += nums[i];
            }

            for (int i = 1; i < nums.Length-2; i++)
            {
                left += nums[i-1];
                right -= nums[i];
                if (left == right)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
