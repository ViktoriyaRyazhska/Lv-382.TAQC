using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void Task4(List<char> a) // Done
        {
            List<char> b = a.Select(x => x == '!' ? '.' : x).ToList();
            foreach (var i in b)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine("Count of Distinct characters: " + a.Distinct().Count());
        }
        public static void Task5(List<char> a)  //Check the speed
        {
            int res = 0;
            for (int i = 0; i < a.Count; i++)
            {
                int temp = 0;
                for (int j = i; j < a.Count; j++)
                {
                    if(a[j]==' ')
                    {
                        temp++;
                        if (res < temp)
                        {
                            res++;
                        }
                        continue;
                    }
                    else
                    {
                        i = j;
                        break;
                    }
                    
                }
            }
            a.Distinct();
            Console.WriteLine(res);
        }
        public static List<char> Task6(List<char> a)
        {
            List<char> b = new List<char>();
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == ':')
                {
                    for (int j = i+1; j < a.Count; j++)
                    {
                        if (a[j]==':')
                        {
                            i = j+1;
                            break;
                        }
                        b.Add(a[j]);
                    }
                }
            }
            return b;
        }
        public static string Task7(List<int> a)
        {
            List<int> b = a.OrderBy(x=>x);
        }
        public static void Task8(List<int> a)
        {
            int mid = a.Count / 2;
            for (int i = 0; i < a.Count; i++)
            {
               
            }
        }
    }

}
