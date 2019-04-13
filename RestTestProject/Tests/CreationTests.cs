using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    class CreationTests
    {
        private AdminService adminService;

        [SetUp]
        public void BeforeTest()
        {
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [TearDown]
        public void AfterTest()
        {

        }

        private static readonly object[] NewUserData =
        {
            new string[] { "TestUser", "qwerty", "false" }
        };

        [Test, TestCaseSource("NewUserData")]
        public void CreateNewUserTest(string newUserName, string newUserPassword, string newUserRights)
        {
            Assert.IsTrue(adminService.CreateUser(newUserName, newUserPassword, newUserRights));
            Assert.IsTrue(new GuestService().SuccessfulUserLogin(UserRepository.Get().LoginUser(newUserName, newUserPassword)).IsLoggined());

        }
    }
}
