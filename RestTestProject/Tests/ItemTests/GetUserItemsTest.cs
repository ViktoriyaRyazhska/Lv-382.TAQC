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
    public class GetUserItemsTest
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
            Assert.AreEqual(addItem.Item, adminService.GetUserItem(addItem, simpleUser).Item);
        }

        [Test, TestCaseSource("AddItemsData")]
        public void GetUserItems(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            //Steps
            //Console.WriteLine(addItem.Index.ToString() + " " + "\t" + addItem.Item.ToString());
            //Console.WriteLine(adminService.GetUserItems(simpleUser).ToString());
            Assert.IsTrue(adminService.GetUserItems(simpleUser).Contains(addItem.Index.ToString() + " " + "\t" + addItem.Item.ToString()));
        }

        [OneTimeTearDown]
        public void AfterTest()
        {
            GuestService.ResetService();
        }
    }
}
