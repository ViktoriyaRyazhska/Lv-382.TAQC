using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class UpdateCoolDownAndTokenifeTimeTest : TestRunner
    {
        private static readonly object[] TokenLifetime =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };

        private static readonly object[] CoolDowntime =
        {
            new object[] { CoolDowntimeRepository.GetLongTime() }
        };

        [SetUp]
        public void SetUp()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
        }

        [TearDown]
        public void TearDown()
        {
            if ((adminService != null) && (adminService.IsLoggined()))
            {
                Lifetime currentTokenlifetime = LifetimeRepository.GetDefault();
                bool responseStatus = adminService.UpdateTokenlifetime(currentTokenlifetime);
            }

            if ((adminService != null) && (adminService.IsLoggined()))
            {
                CoolDowntime currentCoolDowntime = CoolDowntimeRepository.GetDefault();
                bool responseStatus = adminService.UpdateCoolDowntime(currentCoolDowntime);
            }

            if ((adminService != null) && (adminService.IsLoggined()))
            {
                guestService = adminService.Logout();
            }
        }

        [Test, TestCaseSource("CoolDowntime")]
        public void ChangeCooldownTime(CoolDowntime newCoolDowntime)
        {
            bool responseStatus = adminService.UpdateCoolDowntime(newCoolDowntime);
            Assert.IsTrue(responseStatus, "Update Cool Down Time Error");

            CoolDowntime currentCoolDowntime = adminService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.GetLongTime().Time,
                        currentCoolDowntime.Time, "Long Cool Down Time Error");
        }

        [Test, TestCaseSource("TokenLifetime")]
        public void ChangeTokenLifetime(Lifetime newLifetime)
        {
            bool responseStatus = adminService.UpdateTokenlifetime(newLifetime);
            Assert.IsTrue(responseStatus, "Update Token Lifetime Error");

            Lifetime currentLifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.GetLongTime().Time,
                        currentLifetime.Time, "Long Token Lifetime Error");
        }
    }    
}
