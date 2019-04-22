using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestTestProject.Data;
using RestTestProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private GuestService guestService;
        private UserService userService;
        private AdminService adminService;

        private static readonly object[] Users =
        {
            new object[] { UserRepository.Get().ExistingUser(),  UserRepository.Get().ExistingAdmin() },
            new object[] {UserRepository.Get().ExistingSecondUser(), UserRepository.Get().ExistingAdmin() }
        };

        private static readonly object[] AdminUser =
        {
            new object[] { UserRepository.Get().ExistingAdmin() },
        };

        private static readonly object[] NonExistentUser =
        {
            new object[] { UserRepository.Get().NonExistentUser() },
        };

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }

        [TearDown]
        public void TearDown()
        {
            //if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            //{
            //    Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
            //}

            //if ((adminService != null) && (adminService.IsLoggined()))
            //{
            //    guestService = adminService.Logout();
            //}

            //if ((userService != null) && (userService.IsLoggined()))
            //{
            //    guestService = userService.Logout();
            //}
            GuestService.ResetService();
        }
        [Test, TestCaseSource("Users")]
        public void CheckUserIsLogged(IUser user, IUser adminUser)
        {
            IAdminService adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(guestService.SuccessfulUserLogin(user).IsLoggined());
            //Assert.IsTrue(guestService.SuccessfulUserLogin(user).IsLoggined());
            Assert.IsTrue(adminService.GetLoginedUsers().Contains(user.Name));
            Assert.IsTrue(adminService.GetAliveTockens().Contains(user.Token));
        }

        [Test, TestCaseSource("AdminUser")]
        public void CheckAdminUserIsLogged(IUser adminUser)
        {
            IAdminService adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLoggined());
            //Assert.IsTrue(guestService.SuccessfulAdminLogin(adminUser).IsLoggined());
            Assert.IsTrue(adminService.GetLoginedAdmins().Contains(adminUser.Name));
            Assert.IsTrue(adminService.GetAliveTockens().Contains(adminUser.Token));
        }

        [Test, TestCaseSource("NonExistentUser")]
        public void UnsuccessfulLogin(IUser user)
        {
            Assert.AreEqual(UserRepository.USER_NOT_FOUND_ERROR, guestService.UnsuccessfulUserLogin(user));
        }
    }
}

