using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars
{
    static class Arrays
    {
        public static int Task16(int[] arr)
        {
            int indexer = -1;
            int r, l;
            for (int i = 0; i < arr.Length; i++)
            {
                r = 0;
                l = 0;
                for (int j = 0; j < i; j++)
                {
                    l += arr[j];
                }
                for (int j = i+1; j < arr.Length; j++)
                {
                    r += arr[j];
                }
                Console.WriteLine(l+" "+r);
                if (l == r)
                {
                    indexer = i;
                    break;
                }
                    
            }
            return indexer;
        }
    }
}
