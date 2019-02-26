using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    class ReverseOrRotate
    {

        public static string RevRot(string strng, int sz)
        {
            if (sz == 0) return "";
            string[] chunks = new string[strng.Length / sz];
            long sum;

            for (int i = 0; i < chunks.Length; i++)
            {
                chunks[i] = strng.Substring(i * sz, sz);
                sum = chunks[i].Sum(c => (long)Math.Pow(c - '0', 3));
                if (sum % 2 == 0)
                {
                    chunks[i] = new string(chunks[i].Reverse().ToArray());
                }
                else
                {
                    chunks[i] = chunks[i].Substring(1) + chunks[i][0];
                }
            }
            return string.Join("", chunks);
        }

    }


    [TestFixture]
    public static class ReverseOrRotateTests
    {

        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Testing ReverseOrRotate");
            testing(ReverseOrRotate.GetReverseOrRotate("1234", 0), "");
            testing(ReverseOrRotate.GetReverseOrRotate("", 0), "");
            testing(ReverseOrRotate.GetReverseOrRotate("1234", 5), "");
            String s = "733049910872815764";
            testing(ReverseOrRotate.GetReverseOrRotate(s, 5), "330479108928157");

        }
    }
}
