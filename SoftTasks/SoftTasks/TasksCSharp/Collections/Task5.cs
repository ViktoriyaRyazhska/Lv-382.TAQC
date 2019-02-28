using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.Collections
{
    class Task5
    {
        public static int App(char[] chars)
        {
            LinkedList<char> list = new LinkedList<char>(chars);
            LinkedListNode<char> node = list.First;

            int maxSpaces = int.MaxValue,spaces=0;

            while (node != null)
            {
                if (node.Value == ' ')
                {
                    spaces++;
                    if (node.Next!=null&& node.Next.Value!=' ')
                    {
                        if (spaces > maxSpaces)
                        {
                            maxSpaces = spaces;
                            spaces = 0;
                        }
                    }
                    else list.Remove(node);
                }

                node = node.Next;
            }
            return maxSpaces;
        }
    }
}
