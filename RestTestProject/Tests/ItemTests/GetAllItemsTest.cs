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
    public class GetAllItemsTest
    {
        string userData = string.Empty;
        string adminData = string.Empty;
        protected IUserService userService;
        protected IAdminService adminService;
        IUser simpleUser = UserRepository.Get().ExistingUser();

        [OneTimeSetUp]
        public void BeforeTest()
        {
            userService = new GuestService().SuccessfulUserLogin(simpleUser);
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
        }

        private static readonly object[] AddItemsData =
        {
            new object[] { ItemRepository.GetFirst() },
            new object[] { ItemRepository.GetSecond() },
            new object[] { ItemRepository.GetThird() }
        };

        [Test, TestCaseSource("AddItemsData")]
        public void GetAllItemsAsUser(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            userData += addItem;
            //Steps
            Assert.IsTrue(userService.GetAllItems().Contains(userData));
            Assert.AreEqual(userService.GetAllItems(), userData);
        }

        [Test, TestCaseSource("AddItemsData")]
        public void GetAllItemsAsAdmin(ItemTemplate addItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            adminData += addItem;
            //Steps
            Assert.IsTrue(adminService.GetAllItems().Contains(adminData));
            Assert.AreEqual(adminService.GetAllItems(), adminData);
        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            GuestService.ResetService();
        }

    }
}
