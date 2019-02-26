using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    static class CamelCaseMethod
    {
        public static string CamelCase(this string str)
        {
            string[] result = str.Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = char.ToUpper(result[i][0]) + result[i]?.Substring(1);
            }

            return string.Join("", result);
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("TestCase", "test case".CamelCase());
            Assert.AreEqual("CamelCaseMethod", "camel case method".CamelCase());
            Assert.AreEqual("SayHello", "say hello".CamelCase());
            Assert.AreEqual("CamelCaseWord", " camel case word".CamelCase());
            Assert.AreEqual("", "".CamelCase());
        }
    }
}
