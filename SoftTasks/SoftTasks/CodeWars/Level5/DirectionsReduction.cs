using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level5
{
    class DirectionsReduction
    {
        static Dictionary<string, string> Oposite = new Dictionary<string, string>()
        {
            { "SOUTH","NORTH" },
            { "NORTH","SOUTH" },
            { "EAST","WEST" },
            { "WEST","EAST" }
        };

        public static string[] dirReduc(String[] arr) 
        {
            List<string> dirs = new List<string>();

            int current = 0;
            dirs.Add(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                dirs.Add(arr[i]);
                if (Oposite[dirs[current++]] == dirs[current])
                {
                    dirs.RemoveAt(current--);
                    dirs.RemoveAt(current--);
                    if (dirs.Count == 0)
                    {
                        current = 0;
                        dirs.Add(arr[++i]);
                    }
                }
            }
            return dirs.ToArray();
        }
    }



[TestFixture]
    public class DirReductionTests
    {

        [Test]
        public void Test1()
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b = new string[] { "WEST" };
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }
        [Test]
        public void Test2()
        {
            string[] a = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            string[] b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }
    }

}
