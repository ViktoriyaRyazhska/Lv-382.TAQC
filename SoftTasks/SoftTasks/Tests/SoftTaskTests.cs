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
        //Natalia
        [Test]
        public void InterestingRows_1_1returned()
        {
            int inputNumb = 1;
            int expected = 1;
            int actual = Methods.Interesting_Rows(inputNumb);
            Assert.AreEqual(expected, actual, 0.001, "Expected result and actual result are different");
        }

        [Test, TestCaseSource("InterestingRows_Cases")]
        public void InterestingRowsTest(int inputNumb, int expected)
        {
            Assert.AreEqual(expected, Methods.Interesting_Rows(inputNumb), 0.001, "Expected result and actual result are different");
        }
        static object[] InterestingRows_Cases =
       {
            new object [] {2, 1},
            new object [] {5, 11},
            new object [] {-9, 0},
            new object [] {0, 0}
        };

        [Test]
        [TestCase(40, 1431655765)]
        public void InterestingRows_40_1431655765returned(int inputNumb, int expected)
        {
            Assert.AreEqual(expected, Methods.Interesting_Rows(inputNumb), 0.001, "Expected result and actual result are different");
        }
       
        //Natalia_end

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
        //Serhii
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
        [TestCase(3, 4)]
        [TestCase(6, 24)]
        public void WayToCoverIn3Steps_ValidInput_Test3(int input3, int expected)
        {


            Assert.AreEqual(expected, Methods.WayToCoverIn3Steps(input3), $"WayToCoverIn3Steps failed with valid data {input3}");
        }
        [Test, TestCaseSource("WayToCoverIn3StepsDivideCases")]
        public void WayToCoverIn3Steps_ValidInput_Test4(int input4, int expected)
        {
            Assert.AreEqual(expected, Methods.WayToCoverIn3Steps(input4));
        }
        static object[] WayToCoverIn3StepsDivideCases =
        {
            new object[] {3,4},
            new object[] {6,24}

        };
        #region KhrystynaFedun

        static object[] PathsWithoutCrossing_Positive =
        {
            new object[] {2,1},
            new object[] {10,41},
        };

        [Test]
        [TestCase(2, 1)]
        [TestCase(10, 41)]
        [TestCaseSource("PathsWithoutCrossing_Positive")]
        public void KhrystynaFedun_WaisToWriteNAsSum_Test_Positive(int N, int expected)
        {
            Assert.AreEqual(expected, Methods.WaysToWriteNAsSum(N), $"Ways to write n as sum failed");
        }

        static object[] PathsWithoutCrossing_Negative =
        {
            new object[] {-1},
            new object[] {0},
            new object[] {1 },
        };

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCaseSource("PathsWithoutCrossing_Negative")]
        public void KhrystynaFedun_WaisToWriteNAsSum_Test_Negative(int N)
        {
            int expected = 0;
            Assert.AreEqual(expected, Methods.WaysToWriteNAsSum(N), $"Ways to write n as sum failed");
        }

        [Test]
        public void KhrystynaFedun_WaisToWriteNAsSum_AllTests()
        {
            List<int[]> data_positive = new List<int[]>();
            data_positive.Add(new int[] {2,1 });
            data_positive.Add(new int[] { 10, 41 });

            for (int i = 0; i < data_positive.Count; i++)
            {
                Assert.AreEqual(data_positive[i][0], Methods.WaysToWriteNAsSum(data_positive[i][1]), $"Ways to write n as sum failed");
            }


            List<int> data_negative = new List<int>();
            data_negative.Add(-1);
            data_negative.Add(0);
            data_negative.Add(1);

            for (int i = 0; i < data_positive.Count; i++)
            {
                Assert.AreEqual(data_negative[i], Methods.WaysToWriteNAsSum(0), $"Ways to write n as sum failed");
            }
        }

        #endregion KhrystynaFedun

        // Valik
        [Test]
        public void FriendsPairsTest0()
        {
            Assert.AreEqual(4, Methods.FriendPairs(3));
        }
        [Test]
        [TestCase(3, 4)]
        [TestCase(0, 0)]
        [TestCase(-3, 0)]
        public void FriendsPairsTest1(int data, int expected)
        {
            Assert.AreEqual(expected, Methods.FriendPairs(data));
        }
        [Test, TestCaseSource("FriendsPairsDivideCases")]
        public void FriendsPairsTest2(int data, int expected)
        {
            Assert.AreEqual(expected, Methods.FriendPairs(data));
        }
        static object[] FriendsPairsDivideCases =
        {
            new object[] {3,4},
            new object[] {0,0},
            new object[] {1,1},
            new object[] {-3,0}
        };
        //Valik
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

        [Test]
        public void PathsWithoutCrossing_ValidInput_Test1()
        {
            int input1 = 4;
            int expected = 2;
            int actual = Methods.countAllWays(input1);
            Assert.AreEqual(expected, actual, $"PathsWithoutCrossing {input1}");
        }

        [Test]
        [TestCase(4, 2)]
        [TestCase(1, 0)]
        public void PathsWithoutCrossing_Test2(int input2, int expected2)
        {
            Assert.AreEqual(expected2, Methods.countAllWays(input2));
        }

        [Test, TestCaseSource("PathsWithoutCrossing")]
        public void PathsWithoutCrossing_Test3(int input3, int expected3)
        {
            Assert.AreEqual(expected3, Methods.countAllWays(input3));
        }
        static object[] PathsWithoutCrossing =
        {
            new object[] {4,2},
            new object[] {1,0},
            new object[] {4,3}
        };

        //Oleh Hnachuk
        [Test]
        public void WorkToBeHighLowEffort_ValidInput()
        {
            int inputDays = 5;
            int[] inputLow = { 1, 5, 4, 5, 3 };
            int[] inputHigh = { 3, 6, 8, 7, 6 };
            int expected = 20;
            int actual = Methods.maxTasks(inputHigh, inputLow, inputDays);
            Assert.AreEqual(expected, actual, "WorkToBe with high and low effort failed with valid data");
        }

        [Test]
        public void WorkToBeHighLowEffort_InvalidInput()
        {
            int inputDays = 0;
            int[] inputLow = { 1, 5, 4, 5, 3 };
            int[] inputHigh = { 3, 6, 8, 7, 6 };
            int expected = 0;
            int actual = Methods.maxTasks(inputHigh, inputLow, inputDays);
            Assert.AreEqual(expected, actual, "WorkToBe with high and low effort failed with invalid data");
        }

        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 7, 6 }, new int[] { 1, 3, 2, 2, 4, 1 }, 6, 18)]
        [TestCase(new int[] { 3 }, new int[] { 2 }, 1, 3)]
        [TestCase(new int[] { 5 }, new int[] { 4 }, -1, 0)]
        public void WorkToBeHighLowEffort_TestCaseInput(int[] inputHigh,int[] inputLow, int inputDays,int expected)
        {
            Assert.AreEqual(expected, Methods.maxTasks(inputHigh,inputLow,inputDays));
        }

        [Test, TestCaseSource("WorkToBeHighLowEffort")]
        public void WorkToBeHighLowEffort_SourceInput(int[] inputHigh, int[] inputLow, int inputDays, int expected)
        {
            Assert.AreEqual(expected, Methods.maxTasks(inputHigh, inputLow, inputDays));
        }
        static object[] WorkToBeHighLowEffort =
        {
            new object[] {new int[] { 8, 9, 3, 6, 9, 2 }, new int[] { 3, 6, 4, 5, 6, 3 }, 6, 32},
            new object[] {new int[] { 3 }, new int[] { 5 }, 1, 5},
            new object[] {new int[] { 5,4,3,4 }, new int[] { 2,3,4,1 }, -4, 0}
        };
    }
}