using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests.ItemTests
{
    [TestFixture]
    public class GetUserItemTest : ItemTestRunner
    {
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

    }
}
