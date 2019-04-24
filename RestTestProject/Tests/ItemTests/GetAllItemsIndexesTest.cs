using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class GetAllItemsIndexesTest : ItemTestRunner
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
        public void GetAllItemsIndexesAsUser(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            userData += addItem.GetIndex();
            //Steps
            Assert.AreEqual(userData, userService.GetAllItemsIndexes());
        }

        [Test, TestCaseSource("AddItemsData")]
        public void GetAllItemsIndexesAsAdmin(ItemTemplate addItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            adminData += addItem.GetIndex();
            //Steps
            Assert.AreEqual(adminData, adminService.GetAllItemsIndexes());
        }

    }
}
