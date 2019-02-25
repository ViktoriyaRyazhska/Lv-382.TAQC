using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class ShortestWord
    {
        public static int FindShort(string s)
        {
            string[] words = s.Split(' ');

            int count = int.MaxValue;

            for (int i = 0; i < words.Length; i++)
            {
                if(count> words[i].Length)
                {
                    count = words[i].Length;
                }
            }
            return count;
        }
    }

    [TestFixture]
    public class TestsShortestWord
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(3, ShortestWord.FindShort("bitcoin take over the world maybe who knows perhaps"));
            Assert.AreEqual(3, ShortestWord.FindShort("turns out random test cases are easier than writing out basic ones"));
        }
    }
}
