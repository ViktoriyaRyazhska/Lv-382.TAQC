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
    public class ItemManagingTests
    {
        private GuestService guestService;
        private UserService userService;
        private AdminService adminService;

        [SetUp]
        public void BeforeTest()
        {
            adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
            userService = new GuestService().SuccessfulUserLogin(UserRepository.Get().ExistingUser());
            //estService = new GuestService();
        }

        private static readonly object[] ItemData =
        {
            new object[] { ItemRepository.GetThird() }
        };

        [Test, TestCaseSource(nameof(ItemData))]
        public void AddItemTest(ItemTemplate item)
        {
            ItemTemplate existItem = item;
            userService.AddItem(existItem);
            ItemTemplate itemResult = userService.GetItem(existItem);
            Assert.AreEqual(existItem.Item, itemResult.Item);
        }

        [Test, TestCaseSource(nameof(ItemData))]
        public void UpdateItemTest(ItemTemplate item)
        {
            ItemTemplate forUpdateItem = item;
            userService.UpdateItem(forUpdateItem);
            ItemTemplate itemResult = userService.GetItem(forUpdateItem);
            Assert.AreEqual(forUpdateItem.Item, itemResult.Item);
        }

        [Test, TestCaseSource(nameof(ItemData))]
        public void DeleteItemTest(ItemTemplate item)
        {
            ItemTemplate forDeleteItem = item;
            userService.DeleteItem(forDeleteItem);
            ItemTemplate itemResult = userService.GetItem(forDeleteItem);
            Assert.AreNotEqual(forDeleteItem.Item, itemResult.Item);
        }

        [Test]
        public void GetAllItemsTest()
        {
            List<string> list = userService.GetAllItems();
            //Assert.AreEqual(ItemRepository.GetAllItems(), list, "Items are not equal");
            foreach (string element in list)
            {
                Console.WriteLine(element);
                Console.WriteLine("----------------");
            }
        }

        //[Test]
        //public void GetAllItemsTest1()
        //{
        //    AdminService adminService = guestService
        //        .SuccessfulAdminLogin(adminUser);
        //    UserService userService = guestService
        //        .SuccessfulUserLogin(simpleUser);
        //    //Assert.AreEqual(userService.GetAllItems().content, adminService.GetUserItems().content);
        //    List<string> list = userService.GetAllItems();
        //    //Assert.AreEqual(ItemRepository.GetAllItems(), list, "Items are not equal");

        //    //foreach (var element in list)
        //    //{
        //    //    Console.WriteLine(element.content);
        //    //}

        //}

        //[Test]

        public void GetAllItemsIndexesTest()
        {
            //AdminService adminService = guestService
            //    .SuccessfulAdminLogin(adminUser);
            //UserService userService = guestService
            //    .SuccessfulUserLogin(simpleUser);

            //Assert.AreEqual(userService.GetAllItems().content, adminService.GetUserItems().content);
            List<string> list = userService.GetAllItems();
            Assert.AreEqual(ItemRepository.GetAllItems(), list, "Item isn`t deleted");
            foreach (var element in list)
            {
                //Console.WriteLine(element.content);
            }
            ////Preconditions
            //Assert.AreEqual("True", userService.AddItem(testItem).content, "TestItem isn`t created");
            ////Steps
            //Assert.IsTrue(adminService.GetUserItems().content.Contains(userService.GetAllItemsIndexes().content));
            ////Postconditions
            ////Console.WriteLine(userService.GetAllItemsIndexes());
            //Assert.AreEqual("True", userService.DeleteItem().content, "Item isn`t deleted");
            //Assert.AreNotEqual(testItem, userService.GetUserItem().content, "Item should be deleted, delete function work incorrect");
        }

        //[Test]
        //public void GetUserItemTest()
        //{
        //    Console.WriteLine(adminService.GetUserItem());
        //}

        //[Test, TestCaseSource("NewItem")]
        //public void GetUserItemsTest(string testItem)
        //{
        //    //Preconditions
        //    Assert.AreEqual("True", userService.AddItem(testItem).content, "TestItem isn`t created");
        //    //Steps
        //    Assert.AreEqual(userService.GetAllItems().content, adminService.GetUserItems().content);
        //    //Console.WriteLine(adminService.GetUserItems());
        //    //Postconditions
        //    Assert.AreEqual("True", userService.DeleteItem().content, "Item isn`t deleted");
        //    Assert.AreNotEqual(testItem, userService.GetUserItem().content, "Item should be deleted, delete function work incorrect");
        //    //Console.WriteLine(adminService.GetUserItems());
        //}
    }
}

