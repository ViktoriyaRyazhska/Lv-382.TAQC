using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class MinNumber
    {
        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }
    }

    public class Tests
    {
        [Test]
        [TestCase(new int[] { 78, 56, 232, 12, 11, 43 }, ExpectedResult = 11)]
        [TestCase(new int[] { 78, 56, -2, 12, 8, -33 }, ExpectedResult = -33)]
        public static int FixedTest(int[] args)
        {
            return MinNumber.FindSmallestInt(args);
        }
    }
}
