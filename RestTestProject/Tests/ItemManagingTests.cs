using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Resources;
using RestTestProject.Services;
using NUnit.Framework.Interfaces;
using System;

namespace RestTestProject.Tests
{
    class ItemManagingTests
    {
        [TestFixture]
        public class LifeTimeTest
        {
            private GuestService guestService;
            private UserService userService;
            private AdminService adminService;


            //// DataProvider
            //private static readonly object[] Admins =
            //{
            //    new object[] { UserRepository.Get().Admin() }
            //};

            //// DataProvider
            //private static readonly object[] TokenLifeTimes =
            //{
            //    new object[] { LifetimeRepository.GetLongTime() }
            //};


            [OneTimeSetUp]
            public void BeforeAllMethods()
            {
     
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
                adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().Admin());
                userService = new GuestService().SuccessfulUserLogin(UserRepository.Get().NewUser());
                //adminService.SuccessfulAdminLogin(UserRepository.Get().Admin());
                //userService.SuccessfulUserLogin(UserRepository.Get().NewUser());
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

                if ((adminService != null) && (adminService.IsLoggined()))
                {
                    adminService.Logout();
                }

                if ((userService != null) && (userService.IsLoggined()))
                {
                    userService.Logout();
                }
            }

            //[Test, TestCaseSource("TokenLifeTimes")]
            //public void CheckTimeChange(Lifetime newTokenlifetime)
            //{
            //    // Steps
            //    bool responseStatus = adminService.UpdateTokenlifetime(newTokenlifetime);
            //    //
            //    // Check
            //    Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //    //
            //    Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            //    Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
            //                currentTokenlifetime.Time, "Long Time Error");
            //}

            ////private static readonly object[] AdminUsers =
            ////{
            ////    //new object[] { UserRepository.Get().Registered() },
            ////    new object[] { UserRepository.Get().Admin(), LifetimeRepository.GetLongTime() }
            ////};

            ////[Test, TestCaseSource("AdminUsers")]
            //public void ExamineTime(IUser adminUser, Lifetime newTokenlifetime)
            //{
            //    GuestService guestService = new GuestService();
            //    Lifetime currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            //    Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
            //                currentTokenlifetime.Time, "Current Time Error");
            //    //
            //    AdminService adminService = guestService
            //        .SuccessfulAdminLogin(adminUser);
            //    bool responseStatus = adminService.UpdateTokenlifetime(newTokenlifetime);
            //    Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //    //
            //    currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            //    Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
            //                currentTokenlifetime.Time, "Long Time Error");
            //    //
            //    guestService = adminService.Logout();
            //    Assert.IsEmpty(adminUser.Token, "Logout Error"); // TODO
            //    //
            //    // Return to Previous State
            //    currentTokenlifetime.Time = LifetimeRepository.DEFAULT_TOKEN_LIFETIME;
            //    adminService = guestService.SuccessfulAdminLogin(adminUser);
            //    responseStatus = adminService.UpdateTokenlifetime(currentTokenlifetime);
            //    //Console.WriteLine("true.ToString() = " + true.ToString());
            //    Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //    //
            //    guestService = adminService.Logout();
            //    currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            //    Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
            //                currentTokenlifetime.Time, "Current Time Error");

            //[Test, TestCaseSource("AdminUsers")]
            //public void ExamineTime(IUser adminUser, Lifetime newTokenlifetime)
            //{
            //    GuestService guestService = new GuestService();
            //    Lifetime currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            //    Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
            //                currentTokenlifetime.Time, "Current Time Error");
            //    //
            //    AdminService adminService = guestService
            //        .SuccessfulAdminLogin(adminUser);
            //    bool responseStatus = adminService.UpdateTokenlifetime(newTokenlifetime);
            //    Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //    //
            //    currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            //    Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
            //                currentTokenlifetime.Time, "Long Time Error");
            //    //
            //    guestService = adminService.Logout();
            //    Assert.IsEmpty(adminUser.Token, "Logout Error"); // TODO
            //    //
            //    // Return to Previous State
            //    currentTokenlifetime.Time = LifetimeRepository.DEFAULT_TOKEN_LIFETIME;
            //    adminService = guestService.SuccessfulAdminLogin(adminUser);
            //    responseStatus = adminService.UpdateTokenlifetime(currentTokenlifetime);
            //    //Console.WriteLine("true.ToString() = " + true.ToString());
            //    Assert.IsTrue(responseStatus, "Update Token Lifetime Error");
            //    //
            //    guestService = adminService.Logout();
            //    currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            //    Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
            //                currentTokenlifetime.Time, "Current Time Error");
            //}
            //}
            ///Ihor`s FirstTest
            //{
            //string changedLifetime = new GuestService().SuccessfulAdminLogin(UserRepository.Get().Admin()).UpdateTokenlifetime(new Lifetime("800000"));
            //Assert.AreEqual("800000", changedLifetime, "Time Error");
            //}

            //  <<<SERHII

            private static readonly object[] NewItem =
            {
                new string[] { "abracadabra" }
            };

            [Test, TestCaseSource("NewItem")]
            public void AddUserItemTest(string newItem)
            { 
                Assert.AreEqual(userService.AddUserItem(newItem).content, "True");
            }

            
            //  SERHII>>>
        }
    }
}
