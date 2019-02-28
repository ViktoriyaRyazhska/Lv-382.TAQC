using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task6
    {
        public static int App(int[] nums)
        {
            int N=0;
            if(nums[0]!= nums[1])
            {
                if (nums[0] != nums[2])
                {
                    N = 0;
                }
                else N = 1;
            }
            else
            {
                for (int i = 2; i < nums.Length; i++)
                {
                    if (nums[0] != nums[i])
                    {
                        N = i;
                        break;
                    }
                }
            }
            Console.WriteLine(N);
            return N;
        }
    }
}
