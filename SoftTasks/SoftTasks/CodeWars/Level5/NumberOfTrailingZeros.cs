using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level5
{
    class NumberOfTrailingZeros
    {
        public static int TrailingZeros(int n)
        {
            int num = 5;
            int count = 0;
            while (n >= num)
            {
                count += n / num;
                num *= 5;
            }
            return count;
        }
    }

   

        [TestFixture]
        public class TrailingZeros
        {
            [Test]
            public void BasicTests()
            {
                Assert.AreEqual(1, NumberOfTrailingZeros.TrailingZeros(5));
                Assert.AreEqual(6, NumberOfTrailingZeros.TrailingZeros(25));
                Assert.AreEqual(131, NumberOfTrailingZeros.TrailingZeros(531));
            }
        }
    }

