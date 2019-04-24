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
    public class GetAllItemsIndexesTest
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
        public void GetAllItemsIndexesAsUser(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            userData += addItem.GetIndex();
            //Steps
            Assert.IsTrue(userService.GetAllItemsIndexes().Contains(userData));
            Assert.AreEqual(userService.GetAllItemsIndexes(), userData);
        }

        [Test, TestCaseSource("AddItemsData")]
        public void GetAllItemsIndexesAsAdmin(ItemTemplate addItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            adminData += addItem.GetIndex();
            //Steps
            Assert.IsTrue(adminService.GetAllItemsIndexes().Contains(adminData));
            Assert.AreEqual(adminService.GetAllItemsIndexes(), adminData);
        }

        [OneTimeTearDown]
        public void AfterTest()
        {
            GuestService.ResetService();
        }

    }
}
