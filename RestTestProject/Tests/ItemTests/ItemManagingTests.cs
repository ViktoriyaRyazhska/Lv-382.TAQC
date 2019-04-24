using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

namespace RestTestProject.Tests
{

    [TestFixture]
    public class ItemManagingTests : ItemTestRunner
    {
        private static readonly object[] AddItemData =
        {
            new object[] { ItemRepository.GetFirst() }
        };

        [Test, TestCaseSource("AddItemData")]
        public void AddItemAsUser(ItemTemplate existItem)
        {
            //Preconditions
            Assert.IsNull(userService.GetItem(existItem).Item);
            //Steps
            Assert.IsTrue(userService.AddItem(existItem));
            Assert.AreEqual(existItem.Item, userService.GetItem(existItem).Item);
        }

        [Test, TestCaseSource("AddItemData")]
        public void AddItemAsAdmin(ItemTemplate existItem)
        {
            //Preconditions
            Assert.IsNull(adminService.GetItem(existItem).Item);
            //Steps
            Assert.IsTrue(adminService.AddItem(existItem));
            Assert.AreEqual(existItem.Item, adminService.GetItem(existItem).Item);
        }

        private static readonly object[] UpdateItemData =
        {
            new object[] { ItemRepository.GetThird(), ItemRepository.GetForUpdate() }
        };

        [Test, TestCaseSource("UpdateItemData")]
        public void UpdateItemAsUser(ItemTemplate addItem, ItemTemplate updateItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            //Steps
            Assert.IsTrue(userService.UpdateItem(updateItem));
            Assert.AreEqual(updateItem.Item, userService.GetItem(updateItem).Item);
        }

        [Test, TestCaseSource("UpdateItemData")]
        public void UpdateItemAsAdmin(ItemTemplate addItem, ItemTemplate updateItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            //Steps
            Assert.IsTrue(adminService.UpdateItem(updateItem));
            Assert.AreEqual(updateItem.Item, adminService.GetItem(updateItem).Item);
        }

        [Test, TestCaseSource("AddItemData")]
        public void DeleteItemAsUser(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            //Steps
            Assert.IsTrue(userService.DeleteItem(addItem));
            Assert.IsNull(userService.GetItem(addItem).Item);
        }

        [Test, TestCaseSource("AddItemData")]
        public void DeleteItemAsAdmin(ItemTemplate addItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            //Steps
            Assert.IsTrue(adminService.DeleteItem(addItem));
            Assert.IsNull(adminService.GetItem(addItem).Item);
        }

    }
}

