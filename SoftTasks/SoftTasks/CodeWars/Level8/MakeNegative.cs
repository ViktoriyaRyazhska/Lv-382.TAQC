using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class MakeNegative
    {
        public static int GetNegative(int number)
        {
            if (number > 0) number *= -1;

            return number;
        }
    }


   

[TestFixture]
    public class TestsMakeNegative
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(-42, MakeNegative.GetNegative(42));
        }
    }
}
