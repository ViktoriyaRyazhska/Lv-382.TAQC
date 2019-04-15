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

        //[Test, TestCaseSource("UnsuccessfulUser")]
        //public void UnsuccessfulLoginUser(IUser user)
        //{
        //    GuestService guestService = new GuestService();
        //    string unsuccessfulMessage = guestService.UnsuccessfulLogin(user);
        //    Assert.AreEqual(unsuccessfulMessage, "ERROR, user not found");
        //}


        [Test]
        public void GetCoolDownTime()
        {
            GuestService guestService = new GuestService();
            CoolDowntime currentCoolDownlifetime = guestService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.DEFAULT_COOLDOWNTIME,
                        currentCoolDownlifetime.Time, "Current Time Error");
        }

        private static readonly object[] AdminUsers =
        {
            new object[] { UserRepository.Get().Admin(), CoolDowntimeRepository.GetLongTime() }
        };

        [Test, TestCaseSource("AdminUsers")]
        public void ChangeCooldownTime(IUser adminUser, CoolDowntime newCooldowntime)
        {
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            bool responseStatus = adminService.UpdateCoolDowntime(newCooldowntime);
            Assert.IsTrue(responseStatus, "Update CoolDown Time Error");
        }

        private static readonly object[] Admin =
        {
            new object[] { UserRepository.Get().Admin() }
        };

        [Test, TestCaseSource("Admin")]
        public void GetLoginedAdmins(IUser adminUser)
        {
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            Console.WriteLine(adminService.GetLoginedAdmins());
        }

        private static readonly object[] Admin1 =
        {
            new object[] { UserRepository.Get().Admin() }
        };

        [Test, TestCaseSource("Admin1")]
        public void GetLoginedUsers(IUser adminUser)
        {
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            Console.WriteLine(adminService.GetLoginedUsers());
        }

        private static readonly object[] Admin2 =
        {
            new object[] { UserRepository.Get().Admin() }
        };

        [Test, TestCaseSource("Admin2")]
        public void GetAliveTockens(IUser adminUser)
        {
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            Console.WriteLine(adminService.GetLoginedUsers());
        }
    }
}

