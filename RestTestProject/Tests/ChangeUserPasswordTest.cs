using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    class ChangeUserPasswordTest
    {
        private AdminService adminService;
        private UserService userService;
        private GuestService guestService;

        [OneTimeSetUp]
        public void BeforeTest()
        {
            guestService = new GuestService();
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
        }

        private static readonly object[] ChangePasswordData =
        {
            new object[] { UserRepository.Get().ExistingUser(), UserRepository.Get().UserWithNewPassword() }
        };

        [Test, TestCaseSource("ChangePasswordData")]
        public void ChangingUserPasswordTest(IUser userForPasswordChanging, IUser userWithNewPassword)
        {
            Assert.IsTrue(guestService.SuccessfulUserLogin(userForPasswordChanging).ChangePassword(userWithNewPassword.Password));
            userService = guestService.SuccessfulUserLogin(userWithNewPassword);
            Assert.IsTrue(userService.IsLoggined());
            userService.ChangePassword(userForPasswordChanging.Password);
        }
    }
}
