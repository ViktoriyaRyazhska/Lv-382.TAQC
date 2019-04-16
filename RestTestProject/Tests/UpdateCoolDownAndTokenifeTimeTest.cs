using NUnit.Framework;
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
    public class UpdateCoolDownAndTokenifeTimeTest
    {
        private GuestService guestService;
        private AdminService adminService;
            
        private static readonly object[] TokenLifetime =
        {
                new object[] { LifetimeRepository.GetLongTime() }
            };
        private static readonly object[] CoolDowntime =
       {
            new object[] { CoolDowntimeRepository.GetLongTime() }
        };

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }
      
        [SetUp]
        public void SetUp()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
            }

            if ((adminService != null) && (adminService.IsLoggined()))
            {
                Lifetime currentTokenlifetime = LifetimeRepository.GetDefault();
                bool responseStatus = adminService.UpdateTokenlifetime(currentTokenlifetime);
            }

            if ((adminService != null) && (adminService.IsLoggined()))
            {
                CoolDowntime currentCoolDownlifetime = CoolDowntimeRepository.GetDefault();
                bool responseStatus = adminService.UpdateCoolDowntime(currentCoolDownlifetime);
            }

            if ((adminService != null) && (adminService.IsLoggined()))
            {
                guestService = adminService.Logout();
            }
        }

        [Test, TestCaseSource("CoolDowntime")]
        public void ChangeCooldownTime(CoolDowntime newCooldowntime)
        {
            bool responseStatus = adminService.UpdateCoolDowntime(newCooldowntime);
            Assert.IsTrue(responseStatus, "Update CoolDown Time Error");

            CoolDowntime currentCoolDownlifetime = adminService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.GetLongTime().Time,
                        currentCoolDownlifetime.Time, "Long Time Error");
        }

        [Test, TestCaseSource("TokenLifetime")]
        public void ChangeTokenLifetime(Lifetime newLifetime)
        {
            bool responseStatus = adminService.UpdateTokenlifetime(newLifetime);
            Assert.IsTrue(responseStatus, "Update Life Time Error");

            Lifetime currentLifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.GetLongTime().Time,
                        currentLifetime.Time, "Long Time Error");
        }
    }    
}
