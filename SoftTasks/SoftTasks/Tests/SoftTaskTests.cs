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
        public void InterestingRows_1_1returned()
        {
            int inputNumb = 1;
            int expected = 1;
            int actual = Methods.Interesting_Rows(inputNumb);
            Assert.AreEqual(expected, actual, 0.001, "Expected result and actual result are different");
        }
        [Test]
        public void InterestingRows_2_1returned()
        {
            int inputNumb = 2;
            int expected = 1;
            int actual = Methods.Interesting_Rows(inputNumb);
            Assert.AreEqual(expected, actual, 0.001, "Expected result and actual result are different");
        }
        [Test]
        public void InterestingRows_5_11returned()
        {
            int inputNumb = 5;
            int expected = 11;
            int actual = Methods.Interesting_Rows(inputNumb);
            Assert.AreEqual(expected, actual, 0.001, "Expected result and actual result are different");
        }
        [Test]
        public void InterestingRows_40_1431655765returned()
        {
            int inputNumb = 40;
            int expected = 1431655765;
            int actual = Methods.Interesting_Rows(inputNumb);
            Assert.AreEqual(expected, actual, 0.001, "Expected result and actual result are different");
        }
        [Test]
        public void InterestingRows_0_0returned()
        {
            int inputNumb = 0;
            int expected = 0;
            int actual = Methods.Interesting_Rows(inputNumb);
            Assert.AreEqual(expected, actual, 0.001, "Expected result and actual result are different");
        }
        [Test]
        public void InterestingRows_0returned()
        {
            int inputNumb = -9;
            int expected = 0;
            int actual = Methods.Interesting_Rows(inputNumb);
            Assert.AreEqual(expected, actual, 0.001, "Expected result and actual result are different");
        }
    }
}