using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class Summation
    {
        public static int summation(int num)
        {
            return (1 + num) * num / 2;


           
        }
    }


    [TestFixture]
    public static class SummationTests
    {
        [Test]
        public static void BasicTests()
        {
            Assert.AreEqual(1, Summation.summation(1));
            Assert.AreEqual(36, Summation.summation(8));
            Assert.AreEqual(253, Summation.summation(22));
            Assert.AreEqual(5050, Summation.summation(100));
            Assert.AreEqual(22791, Summation.summation(213));
        }
    }
}
