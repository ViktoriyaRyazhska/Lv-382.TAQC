using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class BoolWord
    {
        public static string boolToWord(bool word)
        {
            if (word) return "Yes";
            return "No";
        }
    }



[TestFixture]
    public class boolToWordTest
    {

        [Test]
        public void boolToWordReturned1()
        {
            Assert.AreEqual("Yes", BoolWord.boolToWord(true));
            Console.WriteLine("Expected Yes");
        }

        [Test]
        public void boolToWordReturned2()
        {
            Assert.AreEqual("No", BoolWord.boolToWord(false));
            Console.WriteLine("Expected No");
        }

        [Test]
        public void boolToWordReturned3()
        {
            Assert.AreEqual("Yes", BoolWord.boolToWord(true));
            Console.WriteLine("Expected Yes");
        }
    }
}
