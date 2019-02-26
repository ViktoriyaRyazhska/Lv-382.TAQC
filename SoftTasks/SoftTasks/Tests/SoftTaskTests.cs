using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SoftTasks.Tests
{
    [TestFixture]
    public class SoftTaskTests
    {
        [Test]
        public void MyTestMethod()
        {
            
        }
        [Test]
        public void TestCountAllWays()
        {
            Assert.AreEqual(2, Methods.countAllWays(4));
            Assert.AreEqual(0, Methods.countAllWays(1));
        }
        [Test]
        public void WayToCoverIn3Steps_ValidInput_Test1()
        {
            int input1 = 3;
            int expected = 4;
            int actual = Methods.WayToCoverIn3Steps(input1);
            Assert.AreEqual(expected, actual, $"WayToCoverIn3Steps failed with valid data {input1}");
        }
        [Test]
        public void WayToCoverIn3Steps_ValidInput_Test2()
        {
            int input2 = 6;
            int expected = 24;
            int actual = Methods.WayToCoverIn3Steps(input2);
            Assert.AreEqual(expected, actual, $"WayToCoverIn3Steps failed with valid data {input2}");
        }
    }
}
