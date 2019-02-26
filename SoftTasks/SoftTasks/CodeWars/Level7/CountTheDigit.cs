using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class CountTheDigit
    {
        //TODO
        public static int NbDig(int n, int d)
        {
            return 0;
        }
    }


[TestFixture]
    public static class NbDigTests
    {

        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Fixed Tests NbDig");
            testing(CountTheDigit.NbDig(5750, 0), 4700);
            testing(CountTheDigit.NbDig(11011, 2), 9481);
            testing(CountTheDigit.NbDig(12224, 8), 7733);
            testing(CountTheDigit.NbDig(11549, 1), 11905);
        }
    }
}
