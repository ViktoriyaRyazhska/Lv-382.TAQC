using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class RemoveFirstLast
    {
        public static string Remove_char(string s)
        {
          // return s.Substring(1, s.Length - 2);
            s = s.Remove(0, 1);
            return  s.Remove(s.Length - 1, 1);
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void Test1()
        {
            StringAssert.AreEqualIgnoringCase("loquen", RemoveFirstLast.Remove_char("eloquent"));
            StringAssert.AreEqualIgnoringCase("ountr", RemoveFirstLast.Remove_char("country"));
            StringAssert.AreEqualIgnoringCase("erso", RemoveFirstLast.Remove_char("person"));
            StringAssert.AreEqualIgnoringCase("lac", RemoveFirstLast.Remove_char("place"));
            StringAssert.AreEqualIgnoringCase("", RemoveFirstLast.Remove_char("ok"));
        }
    }
}
