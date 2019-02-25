using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level5
{
    class WeightForweight
    {
        public static string orderWeight(string strng)
        
            {
            List<string> result = new List<string>(strng.Split(' '));
            result.Sort(new Comp());
            return string.Join(" ", result);
        }

        class Comp : IComparer<string>
        {
            StringComparer DefaultComp = StringComparer.Ordinal;
            public int Compare(string x, string y)
            {
                int dif = SumDigits(x) - SumDigits(y);
                if (dif < 0) return -1;
                if (dif > 0) return 1;
                return DefaultComp.Compare(x, y);
            }
            private int SumDigits(string val) => val.Sum(ch => ch - '0');
        }
    }


[TestFixture]
    public class WeightSortTests
    {

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            Assert.AreEqual("2000 103 123 4444 99", WeightForweight.orderWeight("103 123 4444 99 2000"));
            Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", WeightForweight.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
        }
    }

}
