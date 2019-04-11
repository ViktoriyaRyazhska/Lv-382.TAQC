using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Resources;
using RestTestProject.Services;
using NUnit.Framework.Interfaces;
using RestTestProject.Data;
using RestTestProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class LifeTimeTest
    {
        private GuestService guestService;
        //private AdminService userService;
        private AdminService adminService;

        // DataProvider
        private static readonly object[] Admins =
        {
            new object[] { UserRepository.Get().Admin() }
        };

        // DataProvider
        private static readonly object[] TokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
        }

        //[SetUp, TestCaseSource("Admins")]
        [SetUp]
        //public void SetUp(IUser adminUser)
        public void SetUp()
        {
            //adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // TODO Save to Log File
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                // Clear Cache
            }
            //
            // Return to Previous State
            if ((adminService != null) && (adminService.IsLoggined()))
            {
                Lifetime currentTokenlifetime = LifetimeRepository.GetDefault();
                bool responseStatus = adminService.UpdateTokenlifetime(currentTokenlifetime);
            }
            //
            // TODO for User
            if ((adminService != null) && (adminService.IsLoggined()))
            {
                guestService = adminService.Logout();
            }
        }

        [Test, TestCaseSource("TokenLifeTimes")]
        public void CheckTimeChange(Lifetime newTokenlifetime)
        {
            // Steps
            bool responseStatus = adminService.UpdateTokenlifetime(newTokenlifetime);
            //
            // Check
            Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //
            Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Long Time Error");
        }

        //private static readonly object[] AdminUsers =
        //{
        //    //new object[] { UserRepository.Get().Registered() },
        //    new object[] { UserRepository.Get().Admin(), LifetimeRepository.GetLongTime() }
        //};

        //[Test, TestCaseSource("AdminUsers")]
        public void ExamineTime(IUser adminUser, Lifetime newTokenlifetime)
        {
            GuestService guestService = new GuestService();
            Lifetime currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Current Time Error");
            //
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            bool responseStatus = adminService.UpdateTokenlifetime(newTokenlifetime);
            Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //
            currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Long Time Error");
            //
            guestService = adminService.Logout();
            Assert.IsEmpty(adminUser.Token, "Logout Error"); // TODO
            //
            // Return to Previous State
            currentTokenlifetime.Time = LifetimeRepository.DEFAULT_TOKEN_LIFETIME;
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            responseStatus = adminService.UpdateTokenlifetime(currentTokenlifetime);
            //Console.WriteLine("true.ToString() = " + true.ToString());
            Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //
            guestService = adminService.Logout();
            currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Current Time Error");
            string changedLifetime = new GuestService().SuccessfulAdminLogin(UserRepository.Get().Admin()).UpdateTokenlifetime(new Lifetime("800000"));
            Assert.AreEqual("800000", changedLifetime, "Time Error");
        }

    }
}
