using NUnit.Framework;
using RestTestProject.Data;

namespace RestTestProject.Tests.UserTests
{
    [TestFixture]
    class DeleteUserTest : TestRunner
    { 
        private static readonly object[] UserToDeleteData =
        {
            new object[] { UserRepository.Get().ExistingUser() }
        };

        [Test, TestCaseSource("UserToDeleteData")]
        public void DeletingUserTest(IUser userToDelete)
        {
            Assert.IsTrue(adminService.DeleteUser(userToDelete));
            Assert.AreEqual(guestService.UnsuccessfulUserLogin(userToDelete), UserRepository.USER_NOT_FOUND_ERROR);
        }

        private static readonly object[] AdminToDeleteData =
        {
            new object[] { UserRepository.Get().ExistingAdmin() }
        };

        [Test, TestCaseSource("AdminToDeleteData")]
        public void DeletingCurrentAdmin(IUser currentAdmin)
        {
            Assert.IsFalse(adminService.DeleteUser(currentAdmin));
        }

    }
}
