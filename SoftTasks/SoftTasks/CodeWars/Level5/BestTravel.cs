using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level5
{
    
    public static class SumOfK
    {
        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            if (ls == null || ls.Count < k)
            {
                return null;
            }

            var sumlists = DifferentCombinations(ls, k);
            int c = sumlists.Count();
            int bestSum = 0;
            foreach (var list in sumlists)
            {
                int sum = 0;
                foreach (var l in list)
                {
                    sum += l;
                }

                if (bestSum <= sum && sum <= t)
                {
                    bestSum = sum;
                }
            }

            if (bestSum == 0)
            {
                return null;
            }

            return bestSum;
        }
    }



[TestFixture]
    public class SumOfKTests
    {

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            List<int> ts = new List<int> { 50, 55, 56, 57, 58 };
            int? n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(163, n);

            ts = new List<int> { 50 };
            n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(null, n);

            ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
            n = SumOfK.chooseBestSum(230, 3, ts);
            Assert.AreEqual(228, n);
        }
    }
}
