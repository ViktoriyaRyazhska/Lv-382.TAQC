using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class MovesinSquaredStrings
    {
        public delegate string Operation(string str);

        public static string VertMirror(string strng)
        {
            string[] Ver = strng.Split('\n');

            for (int i = 0; i < Ver.Length; i++)
            {
                Ver[i] = new string(Ver[i].Reverse().ToArray());
            }
            return string.Join("\n", Ver);
        }
        public static string HorMirror(string strng)
        {
            string[] Hor = strng.Split('\n');

            return string.Join("\n", Hor.Reverse());

        }
        public static string Oper(Operation fnc, string s)
        {
            return fnc(s);
        }
    }
     


[TestFixture]
    public static class OpstringsTests
    {
        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Fixed Tests VertMirror");
            testing(MovesinSquaredStrings.Oper(MovesinSquaredStrings.VertMirror, "hSgdHQ\nHnDMao\nClNNxX\niRvxxH\nbqTVvA\nwvSyRu"),
                "QHdgSh\noaMDnH\nXxNNlC\nHxxvRi\nAvVTqb\nuRySvw");
            testing(MovesinSquaredStrings.Oper(MovesinSquaredStrings.VertMirror, "IzOTWE\nkkbeCM\nWuzZxM\nvDddJw\njiJyHF\nPVHfSx"),
                "EWTOzI\nMCebkk\nMxZzuW\nwJddDv\nFHyJij\nxSfHVP");

            Console.WriteLine("Fixed Tests HorMirror");
            testing(MovesinSquaredStrings.Oper(MovesinSquaredStrings.HorMirror, "lVHt\nJVhv\nCSbg\nyeCt"), "yeCt\nCSbg\nJVhv\nlVHt");
            testing(MovesinSquaredStrings.Oper(MovesinSquaredStrings.HorMirror, "njMK\ndbrZ\nLPKo\ncEYz"), "cEYz\nLPKo\ndbrZ\nnjMK");

        }
    }
}
