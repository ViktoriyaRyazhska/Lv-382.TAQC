using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;
using System.Threading;

namespace RestTestProject.Tests
{
    [TestFixture]
    class UserTests
    {
        private AdminService adminService;
        private UserService userService;
        private GuestService guestService;

        [OneTimeSetUp]
        public void BeforeTest()
        {
            guestService = new GuestService();
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [TearDown]
        public void AfterTest()
        {
            
        }

        //----------------------------------------------------- Creation block -------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------
        private static readonly object[] NewUserData =
        {
            new object[] { UserRepository.Get().("TestUser", "qwerty"), false.ToString() }
        };

        [Test, TestCaseSource("NewUserData")]
        public void CreateNewUserTest(IUser newUser, string newUserRights)
        {
            Assert.IsTrue(adminService.CreateUser(newUser, newUserRights));
            Assert.IsTrue(guestService.SuccessfulUserLogin(newUser).IsLoggined());

        }
        //---------------------------------------------------- Deleting block --------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------
        [Test, TestCaseSource("NewUserData")]
        public void DeleteUserTest(IUser userForDelete, string someStr)
        {
            Assert.IsTrue(adminService.DeleteUser(userForDelete));
            Assert.AreEqual(guestService.UnsuccessfulUserLogin(userForDelete), "ERROR, user not found");
        }
        //------------------------------------------------- Change Password block ----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------

        private static readonly object[] ChangePasswordData =
        {
            new object[] { UserRepository.Get().NewUser(), "SomeNewPassword" }
        };

        [Test, TestCaseSource("ChangePasswordData")]
        public void ChangeUserPasswordTest(IUser userForPasswordChanging, string newUserPassword)
        {
            Assert.IsTrue(guestService.SuccessfulUserLogin(userForPasswordChanging).ChangePassword(newUserPassword));
            userService = guestService.SuccessfulUserLogin(UserRepository.Get().LoginUser(userForPasswordChanging.Name, newUserPassword));
            Assert.IsTrue(userService.IsLoggined());
            userService.ChangePassword(userForPasswordChanging.Password);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------


    }
}
