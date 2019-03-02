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









        static void Main(string[] args)
        {
            List<int> l1 = new List<int> { 5, 1, 8, 2 };

            List<int> l2 = new List<int> { 5, 1, 8, 2 };

            List<char> l1Char = new List<char> { '!', '4', 'd', '-', '!', '.' };

            List<char> l2Char = new List<char> { ' ', '4', ' ', ' ', ' ', '.', ' ', ' ', '-', ' ', ' ', };


           //DeleteAllExtraSpaces(l2Char).ForEach(Console.Write);

            //ChangeExclamationMarkToDot(l1Char).ForEach(Console.WriteLine);

            //CombineTwoSortedLists(l1, l2).ForEach(Console.WriteLine);

            //l1.ForEach(Console.WriteLine);

            //Console.WriteLine("\n");
            //SortBySelection(l1).ForEach(Console.WriteLine);

        }
    }
}
