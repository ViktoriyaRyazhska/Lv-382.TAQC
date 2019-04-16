using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    class CreateUserTest
    {
        private AdminService adminService;
        private GuestService guestService;
        private UserService userService;

        [SetUp]
        public void BeforeTest()
        {
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
            guestService = new GuestService();
        }

        private static readonly object[] NewUserData =
        {
            new object[] { UserRepository.Get().NonExistentUser() }
        };

        [Test, TestCaseSource("NewUserData")]
        public void CreatingNewUserTest(IUser newUser)
        {
            //IUser newUser = UserRepository.Get().NonExistentUser();
            Assert.IsTrue(adminService.CreateUser(newUser));
            userService = guestService.SuccessfulUserLogin(newUser);
            Assert.IsTrue(userService.IsLoggined());
            adminService.DeleteUser(newUser);
        }
    }
}
