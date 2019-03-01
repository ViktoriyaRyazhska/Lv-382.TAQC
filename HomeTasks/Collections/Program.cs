using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] FirstTask (int[] numbs, int b)
        {
            List<int> result = new List<int>(numbs);
            result.Add(b);
            result.Sort();
            return result.ToArray();
        }

        static int [] FirstTaskB (int[] numbs, int[] secondNum)
        {
            List<int> result = new List<int>(numbs);
            for (int i = 0; i < secondNum.Length; i++)
            {
                result.Add(secondNum[i]);
            }
            result.Sort();
            return result.ToArray();
        }

        static int [] SecondTask (int [] a, int [] b)
        {
            List<int> result = new List<int>(a);
            result.AddRange(b);
            result.Sort();
            return result.ToArray();                
        }

        static int [] ThirdTask (int [] values)
        {
            int min = 0; int temp = 0;
            for (int i = 0; i < values.Length; i++)
            {
                min = values.Min();
                int indexMin = 0;
                for (int j = 0; j < values.Length; j++)
                {
                    if (values[j] < min)
                    {
                        min = values[j];
                        indexMin = j;
                    }
                }
                temp = values[i];
                values[i] = values[indexMin];
                values[indexMin] = temp;
            }
            
            return values;
        }
        static int FourthTask(int n, char [] characters)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < characters.Length; i++)
            {
                if(characters[i] == '!')
                {
                    characters[i] = '.';
                }
            }
            for (int i = 0; i < characters.Length; i++)
            {
                if (!list.Contains(characters[i]))
                {
                    list.Add(characters[i]);
                }
            }
            Console.WriteLine(list.Count);
            return list.Count;
        }
        static string[] SixthTask(char[] characters)
        {
            string text = characters.ToString();
            return text.Split(':');
        }

        static string SeventhTask(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if(values[i] > values[i + 1])
                {
                    return "Sorted in descending order";
                }
                if (values[i] < values[i + 1])
                {
                    return "Sorted in ascending order";
                }
            }
            return " ";
        }       

    }
}
