using System.Collections.Generic;

namespace Codewars
{
    static class CollectionsTasks
    {
        public static void Task1(ref List<int> array, params int[] b) // Done
        {
            array.Sort();
            foreach (var n in b)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    if (array[i] >= n)
                    {
                        array.Insert(i, n);
                        break;
                    }
                }
            }
        }
        public static List<int> Task2(List<int> a, List<int> b) // Done
        {
            List<int> c = new List<int>();
            c.AddRange(a);
            c.AddRange(b);
            return c;
        }
        public static int[] Task3(List<int> list)
        {
            int min;
            for (int i = 0; i < length; i++)
            {

            }
        }
        private static void Swap(ref List<int> list,int a,int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = list[a];
        }
    }

}
