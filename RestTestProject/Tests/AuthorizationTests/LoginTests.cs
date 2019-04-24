using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Tests;

namespace RestTestProject.AuthorizationTests.Tests
{
    [TestFixture]
    public class LoginTests : BaseTestRunner
    {       

        private static readonly object[] Users =
        {
            new object[] { UserRepository.Get().ExistingUser() }
        };

        [Test, TestCaseSource("Users")]
        public void CheckUserIsLogged(IUser user)
        {
            Assert.IsTrue(guestService.SuccessfulUserLogin(user).IsLoggined(), "Logging User Error");      
        }

        private static readonly object[] AdminUser =
        {
            new object[] { UserRepository.Get().ExistingAdmin() },
        };

        [Test, TestCaseSource("AdminUser")]
        public void CheckAdminUserIsLogged(IUser adminUser)
        {
            Assert.IsTrue(guestService.SuccessfulAdminLogin(adminUser).IsLoggined(), "Logging AdminUser Error");         
        }

        private static readonly object[] NonExistentUser =
        {
            new object[] { UserRepository.Get().NonExistentUser() },
        };

        [Test, TestCaseSource("NonExistentUser")]
        public void UnsuccessfulLogin(IUser user)
        {
            Assert.AreEqual(UserRepository.USER_NOT_FOUND_ERROR, guestService.UnsuccessfulUserLogin(user), "Logging NonExistentUser Error");
        }

        [TearDown]
        public void TearDown()
        {
            if ((adminService != null) && (adminService.IsLoggined()))
            {
                guestService = adminService.Logout();
            }

            if ((userService != null) && (userService.IsLoggined()))
            {
                guestService = userService.Logout();
            }
        }
    }
}

