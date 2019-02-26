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
            Assert.AreEqual(2, Methods.countAllWays(4)); // Positive
            Assert.AreEqual(0, Methods.countAllWays(5)); //  Negative
            Assert.AreEqual(0, Methods.countAllWays(1)); // Negative
        }
    }
}
