using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Resources;
using RestTestProject.Services;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using RestTestProject.Entity;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class ItemManagingTests : TestRunner
    {
        IUser simpleUser = UserRepository.Get().ExistingUser();

        [SetUp]
        public void BeforeTests()
        {
            userService = new GuestService().SuccessfulUserLogin(simpleUser);
        }


        private static readonly object[] AddItemData =
        {
            new object[] { ItemRepository.GetFirst() }
        };

        [Test, TestCaseSource("AddItemData")]
        public void AddItemAsUserTest(ItemTemplate existItem)
        {
            //Preconditions
            Assert.IsNull(userService.GetItem(existItem).Item);
            //Steps
            Assert.IsTrue(userService.AddItem(existItem));
            Assert.AreEqual(existItem.Item, userService.GetItem(existItem).Item);
        }

        [Test, TestCaseSource("AddItemData")]
        public void AddItemAsAdminTest(ItemTemplate existItem)
        {
            //Preconditions
            Assert.IsNull(adminService.GetItem(existItem).Item);
            //Steps
            Assert.IsTrue(adminService.AddItem(existItem));
            Assert.AreEqual(existItem.Item, adminService.GetItem(existItem).Item);
        }


        //[Test, TestCaseSource("AddItemData")]
        //public void GetItemAsUserTest(ItemTemplate existItem)
        //{
        //    //Preconditions
        //    Assert.IsNull(userService.GetItem(existItem).Item);
        //    //Steps
        //    Assert.IsTrue(userService.AddItem(existItem));
        //    Assert.AreEqual(existItem.Item, userService.GetItem(existItem).Item);
        //}

        //[Test, TestCaseSource("AddItemData")]
        //public void GetItemAsAdminTest(ItemTemplate existItem)
        //{
        //    //Preconditions
        //    Assert.IsNull(adminService.GetItem(existItem).Item);
        //    //Steps
        //    Assert.IsTrue(adminService.AddItem(existItem));
        //    Assert.AreEqual(existItem.Item, adminService.GetItem(existItem).Item);
        //}


        private static readonly object[] UpdateItemData =
        {
            new object[] { ItemRepository.GetThird(), ItemRepository.GetForUpdate() }
        };

        [Test, TestCaseSource("UpdateItemData")]
        public void UpdateItemAsUserTest(ItemTemplate addItem, ItemTemplate updateItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            //Steps
            Assert.IsTrue(userService.UpdateItem(updateItem));
            Assert.AreEqual(updateItem.Item, userService.GetItem(updateItem).Item);
        }

        [Test, TestCaseSource("UpdateItemData")]
        public void UpdateItemAsAdminTest(ItemTemplate addItem, ItemTemplate updateItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            //Steps
            Assert.IsTrue(adminService.UpdateItem(updateItem));
            Assert.AreEqual(updateItem.Item, adminService.GetItem(updateItem).Item);
        }


        [Test, TestCaseSource("AddItemData")]
        public void DeleteItemAsUserTest(ItemTemplate addItem)
        {
            //Preconditions
            userService.AddItem(addItem);
            //Steps
            Assert.IsTrue(userService.DeleteItem(addItem));
            Assert.IsNull(userService.GetItem(addItem).Item);
        }

        [Test, TestCaseSource("AddItemData")]
        public void DeleteItemAsAdminTest(ItemTemplate addItem)
        {
            //Preconditions
            adminService.AddItem(addItem);
            //Steps
            Assert.IsTrue(adminService.DeleteItem(addItem));
            Assert.IsNull(adminService.GetItem(addItem).Item);
        }


        //private static readonly object[] AddItemsData =
        //{
        //    new object[] { ItemRepository.GetFirst() },
        //    new object[] { ItemRepository.GetSecond() },
        //    new object[] { ItemRepository.GetThird() }
        //};

        ////[Test, TestCaseSource("AddItemsData")]
        //public void GetAllItemsTest(ItemTemplate addItem)
        //{
        //    //Preconditions
            
        //    Console.WriteLine(userService.AddItem(addItem));
        //    //Steps
        //    List<string> list = userService.GetAllItems();
        //    //Assert.AreEqual(ItemRepository.GetAllItems(), userService.GetAllItems(), "Items are not equal");
        //    //Console.WriteLine(userService.GetAllItems().ToString());
        //    //foreach (string element in list)
        //    //{
        //    //    Console.WriteLine(element);
        //    //}
        //}


        ////[Test, TestCaseSource("AddItemsData")]
        //public void GetAllItemsIndexesTest(ItemTemplate addItem)
        //{
        //    //Preconditions
        //    userService.AddItem(addItem);
        //    //Steps
        //    //List<string> list = userService.GetAllItemsIndexes();
        //    //Assert.AreEqual(ItemRepository.GetAllItems(), userService.GetAllItemsIndexes());
        //    ////Assert.AreEqual(ItemRepository., list);
        //    //foreach (var element in list)
        //    //{
        //    //    Console.WriteLine(element);
        //    //}
        //}


        //[Test, TestCaseSource("AddItemData")]
        //public void GetUserItemTest(ItemTemplate addItem)
        //{
        //    //Preconditions
        //    userService.AddItem(addItem);
        //    //Steps
        //    Assert.AreEqual(addItem.Item, adminService.GetUserItem(addItem, simpleUser).Item);
        //}


        //[Test, TestCaseSource("AddItemsData")]
        //public void GetUserItemsTest(ItemTemplate addItem)
        //{
        //    //Preconditions
        //    userService.AddItem(addItem);
        //    //Steps
        //    Console.WriteLine(addItem.Index.ToString() + " " + "\t" + addItem.Item.ToString());
        //    Console.WriteLine(adminService.GetUserItems(simpleUser).ToString());
        //    Assert.IsTrue(adminService.GetUserItems(simpleUser).Contains(addItem.Index.ToString() + " "+ "\t" + addItem.Item.ToString()));
        //}
    }
}

