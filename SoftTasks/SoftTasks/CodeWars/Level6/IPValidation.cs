using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    class IPValidation
    {
        public static bool is_valid_IP(string ipAddres)
        {
            string[] parts = ipAddres.Split('.');
            if (parts.Length != 4|| ipAddres.Contains(" ")) return false;
            int num;

            for(int i=0;i< 4; i++)
            {
                if (parts[i].Length > 3 || parts[i].Length ==0|| (parts[i][0]=='0'&& parts[i].Length>0)
                    || !int.TryParse(parts[i], out num) || num > 255|| num<0) return false;
            }
            return true;
        }
    }

        [TestFixture]
        public class SolutionTest
        {
            [Test]
            public void TestCases()
            {
                Assert.AreEqual(true, IPValidation.is_valid_IP("0.0.0.0"));
                Assert.AreEqual(true, IPValidation.is_valid_IP("12.255.56.1"));
                Assert.AreEqual(true, IPValidation.is_valid_IP("137.255.156.100"));

                Assert.AreEqual(false, IPValidation.is_valid_IP(""));
                Assert.AreEqual(false, IPValidation.is_valid_IP("abc.def.ghi.jkl"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("123.456.789.0"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("12.34.56"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("12.34.56.00"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("12.34.56.7.8"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("12.34.256.78"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("1234.34.56"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("pr12.34.56.78"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("12.34.56.78sf"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("12.34.56 .1"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("12.34.56.-1"));
                Assert.AreEqual(false, IPValidation.is_valid_IP("123.045.067.089"));
            }
    }
}
