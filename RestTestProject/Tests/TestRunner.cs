using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class TestRunner
    { 
        protected GuestService guestService;
        protected IUserService userService;
        protected IAdminService adminService;

        [OneTimeSetUp]
        public void BeforeTests()
        {
            guestService = new GuestService();
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
        }

        [OneTimeTearDown]
        public void AfterTest()
        {
            //GuestService.ResetService();
        }
    }
}
