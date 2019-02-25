using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class SumBetweenAandB
    {
        public static int GetSum(int a, int b)
        {
            int c;
            if (a > b)
            {
                c = a;
                a = b;
                b = c;
            }
            else if (a == b) return a;

            return (a + b) * (b - a + 1) / 2;
        }


    }

    [TestFixture]
    public class SumTest1
    {
        

        [Test]
        public void Test1()
        {
            Assert.AreEqual(10, SumBetweenAandB.GetSum(0, 4));
            Assert.AreEqual(15, SumBetweenAandB.GetSum(0, 5));
        }
    }
}
