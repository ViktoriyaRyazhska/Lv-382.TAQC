using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class CompareString
    {
        public static bool IsOpposite(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            if (s1.Length == 0) return false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (Math.Abs(s1[i] - s2[i]) != 32)
                {
                    return false;
                }
            }
            return true;
        }
    }

    [TestFixture]
    public class TestCompareString
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual(true, CompareString.IsOpposite("ab", "AB"), "ab, AB => true");
            Assert.AreEqual(true, CompareString.IsOpposite("aB", "Ab"), "aB, Ab => true");
            Assert.AreEqual(true, CompareString.IsOpposite("aBcd", "AbCD"), "aBcd, AbCD => true");
            Assert.AreEqual(false, CompareString.IsOpposite("aBcde", "AbCD"), "aBcde, AbCD => false");
            Assert.AreEqual(false, CompareString.IsOpposite("AB", "Ab"), "AB, Ab => false");
            Assert.AreEqual(false, CompareString.IsOpposite("", ""), "String.Empty, String.Empty => false");
        }
    }
}
