using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.TimeSettingTests.Tests
{
    [TestFixture]
    public class UpdateCoolDownAndTokenifeTimeTest : TestRunner
    {
        private static readonly object[] TokenLifetime_PositiveData =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };

        private static readonly object[] TokenLifetime_NegativeData =
        {           
            new object[] { LifetimeRepository.GetTimeWithSpace() },
            new object[] { LifetimeRepository.GetTimeWithSubtractionSign() }           
        };

        private static readonly object[] CoolDowntime_PositiveData =
        {
            new object[] { CoolDowntimeRepository.GetLongTime() }
        };

        private static readonly object[] CoolDowntime_NegativeData =
        {
            new object[] { CoolDowntimeRepository.GetTimeWithSpace() },
            new object[] { CoolDowntimeRepository.GetTimeWithSubtractionSign() }
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
            GuestService.ResetService();
        }

        [Test, TestCaseSource("CoolDowntime_PositiveData")]
        public void ChangeCooldownTime_Positive(CoolDowntime newCoolDowntime)
        {
            bool responseStatus = adminService.UpdateCoolDowntime(newCoolDowntime);
            Assert.IsTrue(responseStatus, "Update Cool Down Time Error");

            CoolDowntime currentCoolDowntime = adminService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.GetLongTime().Time,
                        currentCoolDowntime.Time, "Long Cool Down Time Error");
        }

        [Test, TestCaseSource("TokenLifetime_PositiveData")]
        public void ChangeTokenLifetime_Positive(Lifetime newLifetime)
        {
            bool responseStatus = adminService.UpdateTokenlifetime(newLifetime);
            Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            
            Lifetime currentLifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.GetLongTime().Time,
                        currentLifetime.Time, "Long Token Lifetime Error");
        }

        [Test, TestCaseSource("TokenLifetime_NegativeData")]
        public void ChangeTokenLifetime_Negative(Lifetime newLifetime)
        {
            bool responseStatus = adminService.UpdateTokenlifetime(newLifetime);
            Assert.IsFalse(responseStatus, "Update Token Lifetime With Negative Data Error");
        }

        [Test, TestCaseSource("CoolDowntime_NegativeData")]
        public void ChangeCooldownTime_Negative(CoolDowntime newCoolDowntime)
        {
            bool responseStatus = adminService.UpdateCoolDowntime(newCoolDowntime);
            Assert.IsFalse(responseStatus, "Update Cool Down Time With Negative Data Error");
        }
    }    
}
