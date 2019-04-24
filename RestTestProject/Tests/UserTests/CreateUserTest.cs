using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests.UserTests
{
    [TestFixture]
    class CreateUserTest : BaseTestRunner
    {
        private static readonly object[] NewUserData =
        {
            new object[] { UserRepository.Get().NonExistentAdmin() },
            new object[] { UserRepository.Get().NonExistentUser() }
        };

        [Test, TestCaseSource("NewUserData")]
        public void CreatingNewUserTest(IUser newUser)
        {
            Assert.IsTrue(adminService.CreateUser(newUser));
            userService = guestService.SuccessfulUserLogin(newUser);
            Assert.IsTrue(userService.IsLoggined());
        }

        private static readonly object[] ExistingUserData =
        {
            new object[] { UserRepository.Get().ExistingUser() },
            new object[] { UserRepository.Get().ExistingAdmin() }
        };

        [Test, TestCaseSource("ExistingUserData")] 
        public void CreatingExistingUserTest(IUser existingUser)
        {
            Assert.IsFalse(adminService.CreateUser(existingUser));
        }
    }
}
