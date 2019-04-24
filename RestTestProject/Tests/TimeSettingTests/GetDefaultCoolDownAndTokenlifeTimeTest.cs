using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Tests;

namespace RestTestProject.TimeSettingTests.Tests
{
    [TestFixture]
    public class GetDefaultCoolDownAndTokenlifeTimeTest : BaseTestRunner
    {       
        [Test]
        public void GetDefaultCoolDownTime()
        {
            CoolDowntime currentCoolDownlifetime = guestService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.GetDefault().Time,
                        currentCoolDownlifetime.Time, "Current Cool Down Time Error");
        }

        [Test]
        public void GetDefaultTokenLifeTime()
        {
            Lifetime currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.GetDefault().Time,
                        currentTokenlifetime.Time, "Current Token Lifetime Error");
        }
    }
}
