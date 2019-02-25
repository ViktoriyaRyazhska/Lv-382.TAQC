using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class MaxLenghtDiff
    {
        public static int Mxdiflg(string[] a1, string[] a2)
        {
            int[] a1Values = GetMinAndMax(a1);
            int[] a2Values = GetMinAndMax(a2);
            if (a1Values == null || a2Values == null) return -1;

            if (a1Values[1] - a2Values[0] > a2Values[1] - a1Values[0])
            {
                return a1Values[1] - a2Values[0];
            }
            return a2Values[1] - a1Values[0];
        }

        public static int[] GetMinAndMax(string[] arr)
        {
            if (arr==null||arr.Length == 0) return null;

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i].Length)
                {
                    min = arr[i].Length;
                }
                if (max < arr[i].Length)
                {
                    max = arr[i].Length;
                }
            }
            return new int[] { min, max };
        }
    }
 

[TestFixture]
    public static class MaxDiffLengthTests
    {

        [Test]
        public static void test1()
        {
            string[] s1 = new string[] { "hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz" };
            string[] s2 = new string[] { "cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww" };
            Assert.AreEqual(13, MaxLenghtDiff.Mxdiflg(s1, s2));
        }
    }

}
