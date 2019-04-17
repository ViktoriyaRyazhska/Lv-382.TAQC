using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class TestRunner
    {
        protected static string USER_NOT_FOUND_ERROR = "ERROR, user not found";
        protected AdminService adminService;
        protected GuestService guestService;
        protected UserService userService;

        [SetUp]
        public void BeforeTest()
        {
            guestService = new GuestService();
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
        }

        [TearDown]
        public void AfterTest()
        {
            GuestService.ResetService();
        }
    }
}
