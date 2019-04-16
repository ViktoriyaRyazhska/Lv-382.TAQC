using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    class DeleteUserTest
    {
        private AdminService adminService;
        private UserService userService;
        private GuestService guestService;

        [OneTimeSetUp]
        public void BeforeTest()
        {
            guestService = new GuestService();
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
        }

        private static readonly object[] DeletedUserData =
       {
            new object[] { UserRepository.Get().ExistingUser() }
        };

        [Test, TestCaseSource("DeletedUserData")]
        public void DeletingUserTest(IUser userForDelete)
        {
            Assert.IsTrue(adminService.DeleteUser(userForDelete));
            Assert.AreEqual(guestService.UnsuccessfulUserLogin(userForDelete), "ERROR, user not found");
            adminService.CreateUser(userForDelete);
        }

    }
}
