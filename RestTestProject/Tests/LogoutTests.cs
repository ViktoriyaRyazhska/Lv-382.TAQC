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
    public class LogoutTests
    {
        private GuestService guestService;
        private UserService userService;
        private AdminService adminService;

 
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
            userService = guestService.SuccessfulUserLogin(UserRepository.Get().ExistingUser());

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {                
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);               
            }          
        }

        [Test]
        public void CheckUserIsLogout()
        {
            userService.Logout();
            Assert.IsFalse(userService.IsLoggined());
        }

        [Test]
        public void CheckAdminUserIsLogout()
        {
            adminService.Logout();
            Assert.IsFalse(adminService.IsLoggined());
        }
    }
}
