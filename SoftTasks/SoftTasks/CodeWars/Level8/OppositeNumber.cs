using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class OppositeNumber
    {
        public static int Opposite(int number)
        {
            return number * (-1);
        }
    }

    
    [TestFixture]
    public class TestOppositeNumber
    {
        [Test]
        public void Test_1()
        {
            Assert.AreEqual(-1, OppositeNumber.Opposite(1));
        }
    }
}
