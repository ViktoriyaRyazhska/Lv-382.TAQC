using System.Collections.Generic;
using System.Linq;
using System;
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
        public static List<int> Task3(ref List<int> list) // Task3 part1 Done
        {
            int min;
            for (int i = 0; i < list.Count - 1; i++)
            {
                min = i;
                for (int index = i + 1; index < list.Count; index++)
                {
                    if (list[index] < list[min])
                    {
                        min = index;
                    }
                }
                Swap(ref list, i, min);
            }
            return list;
        }
        private static void Swap(ref List<int> list, int a, int b) // Task3 part2 Done
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        public static void Task4(List<char> a)
        {
            a.Where(x => x == '!').Select(x => x = '.');
            foreach (var i in a)
            {
                Console.WriteLine(i+" ");
            }
            Console.WriteLine("Count of Distinct characters: "+a.Distinct().Count());
        }
    }

}
