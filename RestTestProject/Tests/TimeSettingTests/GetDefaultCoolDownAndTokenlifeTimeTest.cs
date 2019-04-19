using NUnit.Framework;
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
    public class GetDefaultCoolDownAndTokenlifeTimeTest
    {
        private GuestService guestService;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }

        [Test]
        public void GetDefaultCoolDownTime()
        {
            CoolDowntime currentCoolDownlifetime = guestService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.GetDefault().Time,
                        currentCoolDownlifetime.Time, "Current Time Error");
        }

        [Test]
        public void GetDefaultTokenLifeTime()
        {
            Lifetime currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.GetDefault().Time,
                        currentTokenlifetime.Time, "Current Time Error");
        }
    }
}
