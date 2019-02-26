using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class RotateForMax
    {
        public static long MaxRot(long n)
        {
            string first = n.ToString();
            string[] nums = new string[first.Length];
            long max = n, tmp;
            nums[0] = first;
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i - 1].Remove(i-1,1) + nums[i - 1][i - 1];
                tmp = long.Parse(nums[i]);
                if (tmp > max) max = tmp;
            }
            return max;
        }
    }

    [TestFixture]
    public static class RotateForMaxTests
    {
        private static void testing(long actual, long expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests");
            testing(RotateForMax.MaxRot(38458215), 85821534);
            testing(RotateForMax.MaxRot(195881031), 988103115);
            testing(RotateForMax.MaxRot(896219342), 962193428);
            testing(RotateForMax.MaxRot(69418307), 94183076);
        }
    }
}
