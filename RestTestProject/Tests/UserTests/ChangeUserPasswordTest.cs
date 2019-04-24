using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests
{
    [TestFixture]
    class ChangeUserPasswordTest : BaseTestRunner
    {
        private static readonly object[] ChangePasswordData =
        {
            new object[] { UserRepository.Get().ExistingUser() },
            new object[] { UserRepository.Get().ExistingAdmin() }
        };

        [Test, TestCaseSource("ChangePasswordData")]
        public void ChangingUserPasswordTest(IUser userForPasswordChanging)
        {
            Assert.IsTrue(guestService.SuccessfulUserLogin(userForPasswordChanging).ChangePassword(userForPasswordChanging.NewPassword));
            userForPasswordChanging.SwitchPasswords();
            userService = guestService.SuccessfulUserLogin(userForPasswordChanging);
            Assert.IsTrue(userService.IsLoggined());
        }
    }
}
