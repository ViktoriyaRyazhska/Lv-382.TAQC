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
            /////lalalalal
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
           
            Assert.AreEqual(expected, actual, $"WayToCoverIn3Steps failed with valid data{input1}");
        }
    }
}
