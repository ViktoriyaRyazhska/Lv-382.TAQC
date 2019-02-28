using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Arrays
{
    class Task14
    {
        public static int App(string text)
        {
            HashSet<char> set = new HashSet<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!set.Contains(text[i])) set.Add(text[i]);
            }

            return set.Count;
        }
    }
}
