using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;
using System;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private static readonly object[] User =
           {
            new object[] { UserRepository.Get().ExistingUser() },
        };

        [Test, TestCaseSource("User")]
        public void CheckUserIsLogged(IUser user)
        {
            GuestService guestService = new GuestService();
           
            UserService userService = guestService
                .SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLoggined());

            guestService = userService.Logout();
            Assert.IsTrue(userService.IsLoggout(), "Logout Error"); // TODO          
        }

        private static readonly object[] AdminUser =
           {
            new object[] { UserRepository.Get().ExistingAdmin() },
        };

        [Test, TestCaseSource("AdminUser")]
        public void CheckAdminUserIsLogged(IUser adminUser)
        {
            GuestService guestService = new GuestService();

            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLoggined());

            guestService = adminService.Logout();
            Assert.IsTrue(adminService.IsLoggout(), "Logout Error"); // TODO          
        }

        private static readonly object[] UnsuccessfulUser =
        {
            new object[] { UserRepository.Get().NonExistentUser() },
        };

        [Test, TestCaseSource("UnsuccessfulUser")]
        public void UnsuccessfulLoginUser(IUser user)
        {
            GuestService guestService = new GuestService();
            string unsuccessfulMessage = guestService.UnsuccessfulUserLogin(user);
            Assert.AreEqual(unsuccessfulMessage, "ERROR, user not found");
        }

        [Test]
        public void GetDefaultCoolDownTime()
        {
            GuestService guestService = new GuestService();
            CoolDowntime currentCoolDownlifetime = guestService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.GetDefault().Time,
                        currentCoolDownlifetime.Time, "Current Time Error");
        }

        [Test]
        public void GetDefaultTokenLifeTime()
        {
            GuestService guestService = new GuestService();
            Lifetime currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.GetDefault().Time,
                        currentTokenlifetime.Time, "Current Time Error");
        }

        private static readonly object[] AdminUsers =
        {
            new object[] { UserRepository.Get().ExistingAdmin(), CoolDowntimeRepository.GetLongTime() }
        };

        [Test, TestCaseSource("AdminUsers")]
        public void ChangeCooldownTime(IUser adminUser, CoolDowntime newCooldowntime)
        {
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            bool responseStatus = adminService.UpdateCoolDowntime(newCooldowntime);
            Assert.IsTrue(responseStatus, "Update CoolDown Time Error");

            CoolDowntime currentCoolDownlifetime = adminService.GetCurrentCoolDowntime();
            Assert.AreEqual(CoolDowntimeRepository.GetLongTime().Time,
                        currentCoolDownlifetime.Time, "Long Time Error");

            currentCoolDownlifetime = CoolDowntimeRepository.GetDefault();
            responseStatus = adminService.UpdateCoolDowntime(currentCoolDownlifetime);
            guestService = adminService.Logout();
            Assert.IsFalse(adminService.IsLoggined());
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static readonly object[] Admin =
        {
            new object[] { UserRepository.Get().ExistingAdmin() }
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
            new object[] { UserRepository.Get().ExistingAdmin() }
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
            new object[] { UserRepository.Get().ExistingAdmin() }
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

