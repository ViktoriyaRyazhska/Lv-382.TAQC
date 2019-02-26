using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    class BuildPileOfCubes
    {
        public static long findNb(long m)
        {
            long sum = 1;
            long count = 1;

            while (sum < m)
            {
                count++;
                sum += (long)Math.Pow(count, 3);
            }
            if (sum == m) return count;
            return -1;
        }

    }

    [TestFixture]
    public class BuildPileOfCubesTests
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(2022, BuildPileOfCubes.findNb(4183059834009));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(-1, BuildPileOfCubes.findNb(24723578342962));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(4824, BuildPileOfCubes.findNb(135440716410000));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual(3568, BuildPileOfCubes.findNb(40539911473216));

        }
    }

}
