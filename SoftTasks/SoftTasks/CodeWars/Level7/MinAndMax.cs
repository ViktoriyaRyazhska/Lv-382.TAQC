using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class MinAndMax
    {
        public static string HighAndLow(string numbers)
        {
            string[] nums = numbers.Split(' ');
            int min = int.MaxValue;
            int max = int.MinValue;
            int current;
            for (int i = 0; i < nums.Length; i++)
            {
                current = int.Parse(nums[i]);
                if (current > max)
                {
                    max = current;
                }
                if (current < min)
                {
                    min = current;
                }
            }
            return $"{max} {min}";
        }
    }

    [TestFixture]
    public class TestsMinAndMax
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("42 -9", MinAndMax.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
        }

    }
}