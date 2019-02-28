using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task12
    {
        public static int App(int[] ratings)
        {
            int min = ratings[0], max = ratings[0], sum = ratings[0];

            for(int i = 1; i < ratings.Length; i++)
            {
                sum += ratings[i];
                if (ratings[i] < min) min = ratings[i];
                if (ratings[i] > max) max = ratings[i];
            }

            return (sum - min - max)/(sum-2);
        }
    }
}
