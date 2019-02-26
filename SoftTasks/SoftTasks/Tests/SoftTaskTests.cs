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
        [Test]
        public void WayToCoverIn3Steps_ValidInput_Test1()
        {
            // Arrange
            int input1 = 3;
            int expected = 4;

            // Act
            int actual = Methods.WayToCoverIn3Steps(input1);

            // Assert
           
            Assert.AreEqual(expected, actual, $"WayToCoverIn3Steps failed with valid data {input1}");
        }
        [Test]
        public void WayToCoverIn3Steps_InvalidInput_Test2()
        {
            // Arrange
            int input2 = 6;
            int expected = 24;

            // Act
            int actual = Methods.WayToCoverIn3Steps(input2);

            // Assert

            Assert.AreEqual(expected, actual, $"WayToCoverIn3Steps failed with valid data {input2}");
        }
    }
}
