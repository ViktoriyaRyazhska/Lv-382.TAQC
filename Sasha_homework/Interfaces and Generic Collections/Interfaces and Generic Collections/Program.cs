using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_and_Generic_Collections
{
    class Program
    {
        public static List<int> InputValueInList(List<int> list, List<int> b)
        {
            list.Sort();
            foreach (int bElement in b)
            {
                list.Add(bElement);
            }
            list.Sort();

            return list;
        }


        public static List<int> CombineTwoSortedLists(List<int> a, List<int> b)
        {
            a.Sort();
            b.Sort();

            foreach (int bElement in b)
            {
                a.Add(bElement);
            }

            return a;
        }


        public static List<int> SortBySelection(List<int> list)
        {
            int min = list[0];

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list.Count; j++)
                    if (list[j] > list[i])
                    {
                        min = list[j];
                        list[j] = list[i];
                        list[i] = min;
                    }

            return list;
        }


        public static List<char> ChangeExclamationMarkToDot(List<char> list)
        {
            var resultList = list.Select(l =>
            {
                if (l == '!') l = '.';
                return l;
            }).ToList();

            Console.WriteLine("There are " + resultList.Distinct().Count() + " different elements in the list");

            return resultList;
        }


        public static List<char> DeleteAllExtraSpaces(List<char> list)
        {
            int[] amountsOfSpaces = new int[list.Count()];
            int amountsOfSpacesCounter = 0;

            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == ' ')
                {
                    amountsOfSpaces[amountsOfSpacesCounter] += 1;
                }
                else if (i != 0 && list[i] != ' ')
                {
                    amountsOfSpacesCounter++;
                }
            }

            Console.WriteLine("The biggest amount of spaces in a row: " + amountsOfSpaces.Max());

            string str = string.Concat(list);
            str = string.Join(" ", str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            foreach (char c in str)
            {
                list.Add(c);
            }

            return list;
        }


        public static IList<string> CharectersBetweenDoubleDots(List<char> s)
        {
            string str = string.Concat(s);

            str = str.Substring(str.IndexOf(":") + 1);

            IList<string> result = str.Split(new string[] { ":", " " },
                StringSplitOptions.RemoveEmptyEntries);

            return result;
        }


        public static void CheckIfListIsSorted(List<int> list)
        {
            var orderedByAsc = list.OrderBy(d => d);
            if (list.SequenceEqual(orderedByAsc))
            {
                Console.WriteLine("Input list is sorted by ascending order");
                return;
            }

            var orderedByDsc = list.OrderByDescending(d => d);
            if (list.SequenceEqual(orderedByDsc))
            {
                Console.WriteLine("Input list is sorted by descending order");
                return;
            }

            Console.WriteLine("Input list is not sorted");
        }


        public static List<int> MovingElementsAroundMiddle(List<int> list)
        {
            int indexOfMiddle = list.Count / 2 ;
            Console.WriteLine(indexOfMiddle);
            List<int> result = new List<int>();

            for (int i = 0; i < indexOfMiddle; i++)
            {
                if (list[i] <= list[indexOfMiddle])
                {
                    result.Add(list[i]);
                }
            }

            for (int i = indexOfMiddle + 1; i < list.Count; i++)
            {
                if (list[i] <= list[indexOfMiddle])
                {
                    result.Add(list[i]);
                }
            }

            result.Add(list[indexOfMiddle]);

            for (int i = 0; i < indexOfMiddle; i++)
            {
                if (list[i] > list[indexOfMiddle])
                {
                    result.Add(list[i]);
                }
            }

            for (int i = indexOfMiddle + 1; i < list.Count; i++)
            {
                if (list[i] > list[indexOfMiddle])
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }





        static void Main(string[] args)
        {
            List<int> l1 = new List<int> { 5, 1, 8, 2 };

            List<int> l2 = new List<int> { 5, 1, 8, 2 };

            List<char> l1Char = new List<char> { '!', '4', 'd', '-', '!', '.' };

            List<char> l2Char = new List<char> { ' ', '4', ' ', ' ', ' ', '.', ' ', ' ', '-', ' ', ' ', };

            List<char> listWithDoubleDots = new List<char> { '1', '4', ':', '5', '7', ':', '6', '2', ':' };

            List<int> sortedListAsc = new List<int> { 1, 3, 5, 6 };

            List<int> sortedListDesc = new List<int> { 9, 9, 8, 2, 1 };

            //MovingElementsAroundMiddle(sortedListDesc).ForEach(Console.Write);

            //CheckIfListIsSorted(l1);
            //CheckIfListIsSorted(sortedListAsc);
            //CheckIfListIsSorted(sortedListDesc);

            //foreach(string s in CharectersBetweenDoubleDots(listWithDoubleDots))
            //{
            //    Console.WriteLine(s + "\n");
            //}

            //DeleteAllExtraSpaces(l2Char).ForEach(Console.Write);

            //ChangeExclamationMarkToDot(l1Char).ForEach(Console.WriteLine);

            //CombineTwoSortedLists(l1, l2).ForEach(Console.WriteLine);

            //l1.ForEach(Console.WriteLine);

            //Console.WriteLine("\n");
            //SortBySelection(l1).ForEach(Console.WriteLine);

        }
    }
}
