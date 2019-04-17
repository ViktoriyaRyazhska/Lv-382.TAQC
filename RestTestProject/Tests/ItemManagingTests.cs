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
    class ItemManagingTests
    {
        [TestFixture]
        public class LifeTimeTest
        {
            //private UserService userService;
            //private AdminService adminService;

            //[SetUp]
            //public void SetUp()
            //{
            //    userService = new GuestService().SuccessfulUserLogin(UserRepository.Get().NewUser());
            //    adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().Admin());
            //}

            //[TearDown]
            //public void TearDown()
            //{
            //    if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            //    {
            //        // TODO Save to Log File
            //        Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
            //        // Clear Cache
            //    }

            //    if ((adminService != null) && (adminService.IsLoggined()))
            //    {
            //        adminService.Logout();
            //    }

            //    if ((userService != null) && (userService.IsLoggined()))
            //    {
            //        userService.Logout();
            //    }
            //}

            IUser adminUser = UserRepository.Get().ExistingAdmin();
            IUser user = UserRepository.Get().ExistingUser();
            GuestService guestService = new GuestService();

            [Test]
            public void AddItemTest()
            {
                AdminService adminService = guestService
                    .SuccessfulAdminLogin(adminUser);
                UserService userService = guestService
                    .SuccessfulUserLogin(user);
                ItemTemplate existItem = ItemRepository.GetForUpdate();
                //adminService.AddItem(existItem);
                userService.AddItem(existItem);
                ItemTemplate itemResult = userService.GetItem(existItem);
                Assert.AreEqual(existItem.Item, itemResult.Item);
            }

            [Test]
            public void UpdateItemTest()
            {
                AdminService adminService = guestService
                    .SuccessfulAdminLogin(adminUser);
                UserService userService = guestService
                    .SuccessfulUserLogin(user);
                ItemTemplate forUpdateItem = ItemRepository.GetForUpdate();
                //adminService.UpdateItem(forUpdateItem);
                userService.UpdateItem(forUpdateItem);
                ItemTemplate itemResult = userService.GetItem(forUpdateItem);
                Assert.AreEqual(forUpdateItem.Item, itemResult.Item);
            }

            [Test]
            public void DeleteItemTest()
            {
                AdminService adminService = guestService
                    .SuccessfulAdminLogin(adminUser);
                UserService userService = guestService
                    .SuccessfulUserLogin(user);
                ItemTemplate forDeleteItem = ItemRepository.GetForUpdate();
                //adminService.DeleteItem(forDeleteItem);
                userService.DeleteItem(forDeleteItem);
                ItemTemplate itemResult = userService.GetItem(forDeleteItem);
                Assert.AreNotEqual(forDeleteItem.Item, itemResult.Item);
            }

            [Test]
            public void GetAllItemsTest()
            {
                AdminService adminService = guestService
                    .SuccessfulAdminLogin(adminUser);
                UserService userService = guestService
                    .SuccessfulUserLogin(user);
                //Assert.AreEqual(userService.GetAllItems().content, adminService.GetUserItems().content);
                List<string> list = userService.GetAllItems();
                Assert.AreEqual(ItemRepository.GetAllItems(), list, "Items are not equal");
                //foreach (string element in list)
                //{
                //    Console.WriteLine(element);
                //    Console.WriteLine("----------------");
                //}
                //Console.WriteLine("///////////////////");
                //foreach (ItemTemplate element in ItemRepository.GetAllItems())
                //{
                //    Console.WriteLine(element);
                //}

            }

            //[Test]
            public void GetAllItemsIndexesTest()
            {
                AdminService adminService = guestService
                    .SuccessfulAdminLogin(adminUser);
                UserService userService = guestService
                    .SuccessfulUserLogin(user);
                //Assert.AreEqual(userService.GetAllItems().content, adminService.GetUserItems().content);
                List<string> list = userService.GetAllItems();
                //Assert.AreEqual(ItemRepository.GetAllItems(), list, "Item isn`t deleted");
                foreach (string element in list)
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
}
