using NUnit.Framework;
using RestTestProject.Data;


namespace RestTestProject.Tests.UserTests
{
    [TestFixture]
    class LockUserTest : BaseTestRunner
    {
        private static readonly object[] UserToLockData =
        {
            new object[] { UserRepository.Get().NonExistentAdmin() },
            new object[] { UserRepository.Get().ExistingUser() }
        };

        [SetUp]
        public void BeforeTest()
        {
            adminService.CreateUser(UserRepository.Get().NonExistentAdmin());
        }

        [Test, TestCaseSource("UserToLockData")]
        public void LockingUserTest(IUser userToLock)
        {
            Assert.IsTrue(adminService.LockUser(userToLock));
            Assert.AreEqual(guestService.UnsuccessfulUserLogin(userToLock), UserRepository.USER_LOCKED_ERROR);
        }
    }
}
