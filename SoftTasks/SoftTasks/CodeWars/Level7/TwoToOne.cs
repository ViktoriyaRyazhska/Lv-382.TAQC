using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class TwoToOne
    {
        public static string Longest(string s1, string s2)
        {
            ISet<char> set = new SortedSet<char>();
            FillSet(s1, set);
            FillSet(s2, set);
            StringBuilder result = new StringBuilder();
            foreach (char c in set)
            {
                result.Append(c);
            }
            return result.ToString();
        }

        public static void FillSet(string s, ISet<char> set)
        {
            foreach (char c in s)
            {
                if (!set.Contains(c))
                {
                    set.Add(c);
                }
            }
        }

    }

[TestFixture]
    public static class TwoToOneTests
    {

        [Test]
        public static void test1()
        {
            Assert.AreEqual("aehrsty", TwoToOne.Longest("aretheyhere", "yestheyarehere"));
            Assert.AreEqual("abcdefghilnoprstu", TwoToOne.Longest("loopingisfunbutdangerous", "lessdangerousthancoding"));
            Assert.AreEqual("acefghilmnoprstuy", TwoToOne.Longest("inmanylanguages", "theresapairoffunctions"));
        }
    }
}
