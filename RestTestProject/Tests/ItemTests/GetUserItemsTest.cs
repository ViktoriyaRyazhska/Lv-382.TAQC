using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;


namespace RestTestProject.Tests
{
    [TestFixture]
    public class GetUserItemsTest : ItemTestRunner
    {
        string userData = string.Empty;

        private static readonly object[] AddItemsData =
        {
            new object[] { ItemRepository.GetFirst() },
            new object[] { ItemRepository.GetSecond() },
            new object[] { ItemRepository.GetThird() }
        };

        [Test, TestCaseSource("AddItemsData")]
        public void GetUserItems(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            userData += addItem;
            //Steps
            Assert.AreNotEqual(userData, adminService.GetUserItems(simpleUser));
        }

    }
}
