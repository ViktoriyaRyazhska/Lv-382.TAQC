using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests
{
    [TestFixture]
    class CreateUserTest : TestRunner
    {
        private static readonly object[] NewUserData =
        {
            new object[] { UserRepository.Get().NonExistentUser() }
        };

        [Test, TestCaseSource("NewUserData")]
        public void CreatingNewUserTest(IUser newUser)
        {
            Assert.IsTrue(adminService.CreateUser(newUser));
            userService = guestService.SuccessfulUserLogin(newUser);
            Assert.IsTrue(userService.IsLoggined());
        }
    }
}
