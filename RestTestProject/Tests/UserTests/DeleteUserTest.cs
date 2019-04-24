using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests
{
    [TestFixture]
    class DeleteUserTest : BaseTestRunner
    { 
        private static readonly object[] DeletedUserData =
        {
            new object[] { UserRepository.Get().ExistingUser() }
        };

        [Test, TestCaseSource("DeletedUserData")]
        public void DeletingUserTest(IUser userForDelete)
        {
            Assert.IsTrue(adminService.DeleteUser(userForDelete));
            Assert.AreEqual(guestService.UnsuccessfulUserLogin(userForDelete), UserRepository.USER_NOT_FOUND_ERROR);
        }

    }
}
