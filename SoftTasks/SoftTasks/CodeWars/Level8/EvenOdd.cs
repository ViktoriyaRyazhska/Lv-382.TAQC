using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class EvenOdd
    {
        public static string GetEvenOrOdd(int number)
        {
            if (number % 2 == 0)
            {
                return "Even";
            }
            return "Odd";
        }
    }



    [TestFixture]
    public class TestEvenOdd
    {
        [Test]
        public void MyTest()
        {
            Assert.AreEqual("Even", EvenOdd.GetEvenOrOdd(2));
            Assert.AreEqual("Odd", EvenOdd.GetEvenOrOdd(1));
            Assert.AreEqual("Even", EvenOdd.GetEvenOrOdd(0));
            Assert.AreEqual("Odd", EvenOdd.GetEvenOrOdd(7));
            Assert.AreEqual("Odd", EvenOdd.GetEvenOrOdd(-1));
        }
    }

}
