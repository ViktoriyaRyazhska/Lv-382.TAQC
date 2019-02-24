using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class Reverse
    {
        public static List<int> ReverseList(List<int> list)
        {
            //List<int> newList = new List<int>();
            //foreach (var item in list)
            //{
            //    newList.Insert(0, item);

            //}
            //return newList;

            List<int> newList = new List<int>(list);
            newList.Reverse();

            return newList;
        }
    }

    [TestFixture]
    public class TestReverse
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData(new List<int> { 1, 2, 3, 4 }).Returns(new List<int> { 4, 3, 2, 1 });
                yield return new TestCaseData(new List<int> { 3, 1, 5, 4 }).Returns(new List<int> { 4, 5, 1, 3 });
                yield return new TestCaseData(new List<int> { 3, 6, 9, 2 }).Returns(new List<int> { 2, 9, 6, 3 });
            }
        }

        [Test, TestCaseSource("testCases")]
        public List<int> SampleTest(List<int> list) => Reverse.ReverseList(list);
    }
}
