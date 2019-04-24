using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests.UserTests
{
    class UnlockUserTest : BaseTestRunner
    {
        [SetUp]
        public void BeforeTest()
        {
            adminService.CreateUser(UserRepository.Get().NonExistentAdmin());
            adminService.LockUser(UserRepository.Get().NonExistentAdmin());
            adminService.LockUser(UserRepository.Get().ExistingUser());
        }

        private static readonly object[] LockedUsers =
        {
            new object[] { UserRepository.Get().ExistingUser() },
            new object[] { UserRepository.Get().NonExistentAdmin() }
        };

        [Test, TestCaseSource("LockedUsers")]
        public void UnlockingUsersTest(IUser lockedUser)
        {
            Assert.IsTrue(adminService.UnlockUser(lockedUser));
            userService = guestService.SuccessfulUserLogin(lockedUser);
            Assert.IsTrue(userService.IsLoggined());
        }
    }
}
