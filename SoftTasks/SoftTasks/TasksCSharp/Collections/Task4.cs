using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Collections
{
    class Task4
    {
        public static int App(char[] chars)
        {
            HashSet<char> set = new HashSet<char>();

            for (int i=0;i< chars.Length; i++)
            {
                if (!set.Contains(chars[i]))set.Add(chars[i]);

                if (chars[i] == '!') chars[i] = '.';
            }

            return set.Count;
        }
    }
}
