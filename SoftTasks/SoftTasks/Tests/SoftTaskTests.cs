﻿using System;
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
        [Test]
        public void CountAllWaysTest1()
        {
            Assert.AreEqual(2, Methods.countAllWays(4)); // Positive
        }
        [Test]
        public void CountAllWaysTest2()
        {
            Assert.AreEqual(0, Methods.countAllWays(5)); //  Negative
        }
        [Test]
        public void CountAllWaysTest3()
        {
            Assert.AreEqual(0, Methods.countAllWays(1)); // Negative
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

        [Test]
        [TestCase(2, 1)]
        [TestCase(10, 41)]
        public void KhrystynaFedun_WaisToWriteNAsSum_Test_Positive(int N, int expected)
        {
            Assert.AreEqual(expected, Methods.WaysToWriteNAsSum(N), $"Ways to write n as sum failed");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void KhrystynaFedun_WaisToWriteNAsSum_Test_Negative(int N)
        {
            int expected = 0;
            Assert.AreEqual(expected, Methods.WaysToWriteNAsSum(N), $"Ways to write n as sum failed");
        }
        [Test]

        public void FriendsPairsTest1()
        {
            Assert.AreEqual(4, Methods.FriendPairs(3));
        }
        [Test]
        public void FriendsPairsTest2()
        {
            Assert.AreEqual(2, Methods.FriendPairs(2));
        }
        [Test]
        public void FriendsPairsTest3()
        {
            Assert.AreEqual(0, Methods.FriendPairs(0));
        }
        
        [Test]
        public void CountWaysTest_NLessThan1()
        {
            int N = -4;
            int[] arr = { 1, 1 };
            int expected = -1;
            Assert.AreEqual(expected, Methods.CountWays(N, arr));   //Positive
        }

        [Test]
        public void CountWaysTest_RightValues()
        {
            int N = 7;
            int[] arr = { 1, 5, 6 };
            int expected = 6;
            Assert.AreEqual(expected, Methods.CountWays(N, arr));   //Positive
        }

        [Test]
        public void CountWaysTest_ArrayWith0()
        {
            int N = 7;
            int[] arr = { 0 };
            int expected = 0;
            Assert.AreEqual(expected, Methods.CountWays(N, arr));   //Positive
        }

        [Test]
        public void CountWaysTest_NIs1()
        {
            int N = 1;
            int[] arr = { 6, 8, 9 };
            int expected = 0;
            Assert.AreEqual(expected, Methods.CountWays(N, arr));   //Positive
        }
    }
}