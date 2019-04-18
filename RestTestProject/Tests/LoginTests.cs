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

        private static readonly object[] User =
        {
            new object[] { UserRepository.Get().ExistingUser() },
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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {                
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);                
            }

            if ((adminService != null) && (adminService.IsLoggined()))
            {
                guestService = adminService.Logout();
            }
           
            if ((userService != null) && (userService.IsLoggined()))
            {
                guestService = userService.Logout();
            }
        }
        [Test, TestCaseSource("User")]
        public void CheckUserIsLogged(IUser user)
        {         
            Assert.IsTrue(guestService.SuccessfulUserLogin(user).IsLoggined());    
        }

        [Test, TestCaseSource("AdminUser")]
        public void CheckAdminUserIsLogged(IUser adminUser)
        {
            IAdminService adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLoggined());
            //Assert.IsTrue(guestService.SuccessfulAdminLogin(adminUser).IsLoggined());
            Assert.IsTrue(adminService.GetLoginedAdmins().content.Contains(adminUser.Name));
        }

        [Test, TestCaseSource("NonExistentUser")]
        public void UnsuccessfulLogin(IUser user)
        {
            Assert.AreEqual("ERROR, user not found", guestService.UnsuccessfulUserLogin(user));
        }
    }
}

