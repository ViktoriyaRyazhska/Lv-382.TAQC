using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;
using RestTestProject.Tools;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class BaseTestRunner
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

        [TearDown]
        public void AfterTest()
        {
            LoggerTool.GetLogger();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        { 
            GuestService.ResetService();
        }
    }
}
