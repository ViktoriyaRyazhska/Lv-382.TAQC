using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class TestRunner
    {
        public static Logger log = LogManager.GetCurrentClassLogger();
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
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Failed:
                    log.Error(TestContext.CurrentContext.Test.Name + TestStatus.Failed);
                    break;
                case TestStatus.Passed:
                    log.Info(TestContext.CurrentContext.Test.Name + TestStatus.Passed);
                    break;
                case TestStatus.Inconclusive:
                    log.Info(TestContext.CurrentContext.Test.Name + TestStatus.Inconclusive);
                    break;
            }
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        { 
            GuestService.ResetService();
        }
    }
}
