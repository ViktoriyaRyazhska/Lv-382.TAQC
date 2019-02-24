using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class CountingSheep
    {
        public static int GetCountSheeps(bool[] sheeps)
        {
            int count = 0;
            foreach (bool value in sheeps)
            {
                if (value) count++;

            }
            return count;
        }
    }

    [TestFixture]
    public class CountSheepsTests
    {

        [Test]
        public void SampleTest()
        {
            var sheeps = new bool[] { true, false, true };

            Assert.AreEqual(2, CountingSheep.GetCountSheeps(sheeps));
        }
    }


    
}
