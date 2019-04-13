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
    public class UnsuccessfulLoginTest
    {
        private static readonly object[] UnsuccessfulUser =
        {
            new object[] { UserRepository.Get().UnsuccessfulUser() },
        };

        [Test, TestCaseSource("UnsuccessfulUser")]
        public void UnsuccessfulLoginUser(IUser user)
        {
            GuestService guestService = new GuestService();
            string unsuccessfulMessage = guestService.UnsuccessfulUserLogin(user);
            Assert.AreEqual(unsuccessfulMessage, "ERROR, user not found");
        }

        
        [Test]
        public void GetCoolDownTime()
        {
            GuestService guestService = new GuestService();
            CoolDowntime currentCoolDownlifetime = guestService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.DEFAULT_COOLDOWNTIME,
                        currentCoolDownlifetime.Time, "Current Time Error");           
        }

    }
}

