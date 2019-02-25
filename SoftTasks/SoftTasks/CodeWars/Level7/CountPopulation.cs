using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class CountPopulation
    {
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int year = 0;
            while (p0 <= p )
            {
                p0 = (int)(p0 * percent) + aug;
                year++;
            }
            return year;
        }
    }
}
