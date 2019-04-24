using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests.ItemTests
{
    [TestFixture]
    public class GetAllItemsTest : ItemTestRunner
    {
        string userData = string.Empty;
        string adminData = string.Empty;

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
            Assert.AreEqual(userData, userService.GetAllItems());
        }

        [Test, TestCaseSource("AddItemsData")]
        public void GetAllItemsAsAdmin(ItemTemplate addItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            adminData += addItem;
            //Steps
            Assert.AreEqual(adminData, adminService.GetAllItems());
        }

    }
}
