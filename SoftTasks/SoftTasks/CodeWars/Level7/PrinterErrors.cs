using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class PrinterErrors
    {
        public static string PrinterError(String s)
        {
            int errors = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > 'a' || s[i] > 'm') errors++;
            }
            return $"{errors}/{s.Length}";
        }
    }

[TestFixture]
    public static class PrinterTests
    {

        [Test]
        public static void test1()
        {
            Console.WriteLine("Testing PrinterError");
            string s = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
            Assert.AreEqual("3/56", PrinterErrors.PrinterError(s));
        }
    }

}
