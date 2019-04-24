using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Tests.ItemTests
{
    [TestFixture]
    public class GetUserItemTest
    {
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
        public void GetUserItem(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            //Steps
            Assert.AreNotEqual(addItem.Item, adminService.GetUserItem(addItem, simpleUser).Item);
        }

        [OneTimeTearDown]
        public void AfterTest()
        {
            GuestService.ResetService();
        }

    }
}
