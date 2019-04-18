using NUnit.Framework;
using OpenCartTestProject.Data;
using OpenCartTestProject.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Tests
{
    [TestFixture]
    public class EasyTest
    {
        // DataProvider
        private static readonly object[] ExternalUsers =
        {
            new object[] { UserRepository.Get().Registered() },
        };

        // DataProvider
        private static readonly object[] CSVUsers =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv());

        // DataProvider
        private static readonly object[] ExcelUsers =
            ListUtils.ToMultiArray(UserRepository.Get().FromExcel());

        //[Test, TestCaseSource(nameof(ExternalUsers))]
        //[Test, TestCaseSource(nameof(CSVUsers))]
        //[Test, TestCaseSource(nameof(ExcelUsers))]
        [Test, TestCaseSource("ExcelUsers")]
        public void CheckSearch(IUser user)
        {
            Console.WriteLine("Input User: " + user);
        }
    }
}
