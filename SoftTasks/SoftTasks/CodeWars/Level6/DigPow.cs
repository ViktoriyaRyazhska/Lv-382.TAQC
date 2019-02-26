using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    class DigPow
    {
        public static long digPow(int n, int p)
        {
            long sum = 0;
            string num = n.ToString();
            for (int i = 0; i < num.Length; i++)
            {
                sum += (long)Math.Pow((num[i] - '0'), i + p);
            }
            if (sum / (double)n == sum / n) return sum / n;
            else return -1;
        }
    }


    [TestFixture]
    public class DigPowTests
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, DigPow.digPow(89, 1));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(-1, DigPow.digPow(92, 1));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(51, DigPow.digPow(46288, 3));
        }
    }

}
