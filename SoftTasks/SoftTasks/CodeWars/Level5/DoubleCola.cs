using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level5
{
    class DoubleCola
    {
        public static string WhoIsNext(string[] names, long n)
        {
            long pow = 1;
            while (names.Length * pow < n)
            {
                n -= names.Length * pow;
                pow *= 2;
            }
            return names[(n - 1) / pow];
        }
    }

    class TestDoubleCola
    {
        [Test]
        public void Test1()
        {
            string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            int n = 1;
            Assert.AreEqual("Sheldon", DoubleCola.WhoIsNext(names, n));
        }

        [Test]
        public void Test2()
        {
            string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            int n = 6;
            Assert.AreEqual("Sheldon", DoubleCola.WhoIsNext(names, n));
        }
    }
}
}
