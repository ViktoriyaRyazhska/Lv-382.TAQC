using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests
{
    [TestFixture]
    class DeleteUserTest : TestRunner
    { 
        private static readonly object[] DeletedUserData =
        {
            new object[] { UserRepository.Get().ExistingUser() }
        };

        [Test, TestCaseSource("DeletedUserData")]
        public void DeletingUserTest(IUser userForDelete)
        {
            Assert.IsTrue(adminService.DeleteUser(userForDelete));
            Assert.AreEqual(guestService.UnsuccessfulUserLogin(userForDelete), USER_NOT_FOUND_ERROR);
        }

    }
}
