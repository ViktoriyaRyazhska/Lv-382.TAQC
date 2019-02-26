using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    class AreTheyTheSame
    {
        public static bool comp(int[] a, int[] b)
        {
            if (a == null || b == null) return false;
            return compAB1(a, b) && compAB1(b, a);
        }

        public static bool compAB1(int[] a, int[] b)
        {
            List<int> set = new List<int>();
            foreach (var item in a)
            {
                set.Add(item);
                set.Add(item * item);
                set.Add((int)Math.Sqrt(item));
            }
            foreach (var item in b)
            {
                if (set.Contains(item))
                {
                    set.Remove(item);
                }
                else return false;
            }

            return true;
        }
    }

    [TestFixture]
    public class AreTheySameTests
    {

        [Test]
        public void Test1()
        {
            int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
            int[] b = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
            bool r = AreTheyTheSame.comp(a, b); // True
            Assert.AreEqual(true, r);
        }

        [Test]
        public void Test2()
        {
            int[] a = new int[] { 3 };
            int[] b = new int[] { 27 };
            bool r = AreTheyTheSame.comp(a, b); // True
            Assert.AreEqual(false, r);
        }
    }
}
