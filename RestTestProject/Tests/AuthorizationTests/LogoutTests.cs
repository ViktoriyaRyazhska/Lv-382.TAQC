using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class LogoutTests : TestRunner
    {      
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {           
            userService = guestService.SuccessfulUserLogin(UserRepository.Get().ExistingUser());
        }

        [Test]
        public void CheckUserIsLogout()
        {
            userService.Logout();
            Assert.IsFalse(userService.IsLoggined(), "Logout User Error");
        }

        [Test]
        public void CheckAdminUserIsLogout()
        {
            adminService.Logout();
            Assert.IsFalse(adminService.IsLoggined(), "Logout AdminUser Error");
        }
    }
}
