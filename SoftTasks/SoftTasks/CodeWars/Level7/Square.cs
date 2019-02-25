using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class Square
    {
        public static bool IsSquare(int n)
        {
            double sqr = Math.Sqrt(n);
            if (sqr == (int)sqr)
            {
                return true;
            }
            return false;
        }
    }

 

[TestFixture]
    public class Tests
    {
        [Test]
        public static void ShouldWorkForSomeExamples()
        {
            Assert.AreEqual(false, Square.IsSquare(-1), "negative numbers aren't square numbers");
            Assert.AreEqual(false, Square.IsSquare(3), "3 isn't a square number");
            Assert.AreEqual(true, Square.IsSquare(4), "4 is a square number");
            Assert.AreEqual(true, Square.IsSquare(25), "25 is a square number");
            Assert.AreEqual(false, Square.IsSquare(26), "26 isn't a square number");
        }
    }
}
