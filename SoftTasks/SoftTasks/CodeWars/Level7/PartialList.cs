using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class PartialList
    {
        public static string[][] Partlist(string[] arr)
        {
            string[][] result = new string[arr.Length - 1][];

            result[0] = new string[2];
            result[0][0] = arr[0];

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = new string[2];
                result[i][0] = result[i - 1][0] + " " + arr[i];
            }
            result[result.Length - 1][1] = arr[result.Length];
            for (int i = result.Length - 2; i >= 0; i--)
            {
                result[i][1] = arr[i + 1] + " " + result[i + 1][1];
            }

            string.Format("{:}");

            return result;
        }
    }
    [TestFixture]
    public static class PartListTests
    {
        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }

    }


    [TestFixture]
    public static class TestPartListTests
    {
        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void test0()
        {
            Console.WriteLine("Fixed Tests Partlist");

            String[] s1 = new String[] { "cdIw", "tzIy", "xDu", "rThG" };
            String a = "[[cdIw, tzIy xDu rThG], [cdIw tzIy, xDu rThG], [cdIw tzIy xDu, rThG]]";
            testing(string.Join<string[]>(", ", PartialList.Partlist(s1)), a);

            s1 = new String[] { "I", "wish", "I", "hadn't", "come" };
            a = "[[I, wish I hadn't come], [I wish, I hadn't come], [I wish I, hadn't come], [I wish I hadn't, come]]";
            testing(string.Join<string[]>(", ", PartialList.Partlist(s1)), a);

            s1 = new String[] { "vJQ", "anj", "mQDq", "sOZ" };
            a = "[[vJQ, anj mQDq sOZ], [vJQ anj, mQDq sOZ], [vJQ anj mQDq, sOZ]]";
            testing(string.Join<string[]>(", ", PartialList.Partlist(s1)), a);
        }
    }
}

