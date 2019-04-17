using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests
{
    [TestFixture]
    class ChangeUserPasswordTest : TestRunner
    {
        private static readonly object[] ChangePasswordData =
        {
            new object[] { UserRepository.Get().ExistingUser() }
        };

        [Test, TestCaseSource("ChangePasswordData")]
        public void ChangingUserPasswordTest(IUser userForPasswordChanging)
        {
            Assert.IsTrue(guestService.SuccessfulUserLogin(userForPasswordChanging).ChangePassword(userForPasswordChanging.NewPassword));
            userService = guestService.SuccessfulUserLogin(userForPasswordChanging.Name, userForPasswordChanging.NewPassword);
            Assert.IsTrue(userService.IsLoggined());
        }
    }
}
