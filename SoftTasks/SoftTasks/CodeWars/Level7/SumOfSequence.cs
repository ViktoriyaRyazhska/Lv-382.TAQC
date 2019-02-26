using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class SumOfSequence
    {
        public static int SequenceSum(int start, int end, int step)
        {
            if (start > end) return 0;
            int n = (end - start) / step + 1;
            end = (end - start) / step * step + start;
            return (start + end) * n / 2;
        }
    }

    namespace Solution
    {
        using NUnit.Framework;
        using System;

        [TestFixture]
        public class SolutionTest
        {
            [Test]
            public void BasicTest()
            {
                Assert.AreEqual(12, SumOfSequence.SequenceSum(2, 6, 2));
                Assert.AreEqual(15, SumOfSequence.SequenceSum(1, 5, 1));
                Assert.AreEqual(5, SumOfSequence.SequenceSum(1, 5, 3));
                Assert.AreEqual(45, SumOfSequence.SequenceSum(0, 15, 3));
                Assert.AreEqual(0, SumOfSequence.SequenceSum(16, 15, 3));
                Assert.AreEqual(26, SumOfSequence.SequenceSum(2, 24, 22));
                Assert.AreEqual(2, SumOfSequence.SequenceSum(2, 2, 2));
                Assert.AreEqual(2, SumOfSequence.SequenceSum(2, 2, 1));
                Assert.AreEqual(35, SumOfSequence.SequenceSum(1, 15, 3));
                Assert.AreEqual(0, SumOfSequence.SequenceSum(15, 1, 3));
            }
        }
    }
}
