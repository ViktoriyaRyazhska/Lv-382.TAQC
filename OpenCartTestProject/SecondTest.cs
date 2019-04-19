using NUnit.Framework;
using OpenCartTestProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject
{
    [TestFixture]
    public class SecondTest
    {
        // DataProvider
        private static readonly object[] Users =
        {
            new object[] { UserRepository.Get().Registered() },
        };

        //[Category("RunOnlyThis")]
        [Test, TestCaseSource("Users"), Order(1)]
        public void CheckLogin(IUser user)
        {
            Console.WriteLine("CheckLogin() Input User: " + user.Password);
        }

        // DataProvider
        private static readonly object[] UsersPassword =
        {
            new object[] { UserRepository.Get().Registered(), "abc" },
        };

        [Test, TestCaseSource("UsersPassword"), Order(1)]
        public void CheckChangePassword(IUser user, string password)
        {
            Console.WriteLine("CheckChangePassword() Input User: " + user.Password);
        }

        // DataProvider
        private static readonly object[] UsersNewPassword =
        {
            new object[] { UserRepository.Get().Registered("abc") },
        };

        [Test, TestCaseSource("UsersNewPassword"), Order(3)]
        public void CheckLoginNewPassword(IUser user)
        {
            Console.WriteLine("CheckLoginNewPassword() Input User: " + user.Password);
            CheckLogin(user);
        }

    }
}
