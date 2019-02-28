using System.Collections.Generic;

namespace Codewars
{
    static class CollectionsTasks
    {
        public static void Task1(ref List<int> array, params int[] b)
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

    }
}
