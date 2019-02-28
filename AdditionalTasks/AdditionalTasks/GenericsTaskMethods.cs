using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    public static class GenericsTaskMethods
    {
        public static void InsertIntoSortedList()
        {
            List<int> sortedList = new List<int>() { 1, 2, 3, 4, 4, 5, 6 };
            List<int> inputValues = new List<int>() { 5, 6, 2, 9, 4, 0, 1, 5, 3 };
            foreach (int temp in sortedList)
            {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
            sortedList.AddRange(inputValues);
            sortedList.Sort();
            foreach (int temp in sortedList)
            {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
        }
        public static void Add2SortedLists()
        {
            List<int> fList = new List<int>() { 1, 2, 3, 4, 4, 5, 6 };
            List<int> sList = new List<int>() { 3, 4, 5, 6, 7, 8 };
            foreach (int temp in fList)
            {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
            foreach (int temp in sList)
            {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
            fList.AddRange(sList);
            foreach (int temp in fList)
            {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
        }
        public static void ManuallySort()
        {
            List<int> listToBeSorted = new List<int>() { 2, 7, 3, 1, 9, 3, 7, 5, 2, 6 };
            foreach (int temp in listToBeSorted)
            {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < listToBeSorted.Count; i++)
            {
                int tempMin = listToBeSorted.GetRange(i,listToBeSorted.Count-i).Min();
                int tempPos = listToBeSorted.FindIndex(x=>x==tempMin);
                listToBeSorted.RemoveAt(tempPos);
                listToBeSorted.Insert(tempPos-1, listToBeSorted[i]);
                listToBeSorted[i] = tempMin;
            }
            foreach (int temp in listToBeSorted)
            {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
        }
        public static int CountDistinctSymbols()
        {
            List<char> symbols = new List<char>() { 'a', '!', 'r', ',', '4', 'f', '!', '!', 's', 'a' };
            symbols = symbols.Select<char, char>(s => s == '!' ? '.' : s).ToList<char>();
            foreach (char a in symbols)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            int res = symbols.Distinct().Count();
            Console.WriteLine(res);
            return res;
        }
        public static void SymbolsBetweenColons()
        {
            List<char> symbols = new List<char>() { 'a', ':', 'r', ',', '4', ':', '!', '!', 's', 'a', 't', 'w' };
            List<List<char>> res = new List<List<char>>();
            bool adding = false;
            foreach (char a in symbols)
            {
                if (a == ':')
                {
                    res.Add(new List<char>());
                    adding = true;
                }
                else if (a != ':' && adding)
                {
                    res[res.Count-1].Add(a);
                }
            }
            foreach (List<char> qwe in res)
            {
                foreach (char ch in qwe)
                {
                    Console.Write(ch + " ");
                }
                Console.WriteLine();
            }
        }
        public static void IsItSorted()
        {
            List<double> arrToCheck = new List<double>() { 7,6,5,4,3,2,1 };
            bool flag = true;
            for (int i = 0; i < arrToCheck.Count-1; i++)
            {
                if (arrToCheck[i] <= arrToCheck[i + 1])
                {
                    continue;
                }
                else
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Console.WriteLine("Array is sorted in ascending order");
                return;
            }
            else
            {
                flag = true;
                for (int i = 0; i < arrToCheck.Count - 1; i++)
                {
                    if (arrToCheck[i] >= arrToCheck[i + 1])
                    {
                        continue;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Array is sorted in descending order");
                    return;
                }
                else
                {
                    Console.WriteLine("Array is not sorted");
                    return;
                }
            }
        }
    }
}
