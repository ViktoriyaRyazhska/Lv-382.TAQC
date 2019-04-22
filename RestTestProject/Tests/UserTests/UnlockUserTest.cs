using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests.UserTests
{
    class UnlockUserTest : TestRunner
    {
        [SetUp]
        public void BeforeTest()
        {
            adminService.CreateUser(UserRepository.Get().NonExistentAdmin());
        }

        private static readonly object[] LockedUsers =
        {
            new object[] { UserRepository.Get().ExistingUser() },
            new object[] { UserRepository.Get().NonExistentAdmin() }
        };

        //private static IEnumerable<IUser[]> UserData()
        //{
        //    yield return new IUser[] { UserRepository.Get().NonExistentAdmin(), UserRepository.Get().ExistingUser() };
        //}

        //private static readonly object[] UserToLockData =
        //{
        //    //return yield object[] { UserRepository.Get().NonExistentAdmin() },
        //    new object[] { UserRepository.Get().ExistingUser() }
        //};

        [Test, TestCaseSource("LockedUsers")]
        public void UnlockingUsersTest(IUser lockedUser)
        {
            Assert.IsTrue(adminService.UnlockUser(lockedUser));
            userService = guestService.SuccessfulUserLogin(lockedUser);
            Assert.IsTrue(userService.IsLoggined());
        }
    }
}
