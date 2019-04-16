﻿using NUnit.Framework;
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
            private UserService userService;
            private AdminService adminService;

            [SetUp]
            public void SetUp()
            {
                adminService = new GuestService().SuccessfulAdminLogin(UserRepository.Get().ExistingAdmin());
                userService = new GuestService().SuccessfulUserLogin(UserRepository.Get().ExistingUser());
            }

            [TearDown]
            public void TearDown()
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    // TODO Save to Log File
                    Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                    // Clear Cache
                }

                if ((adminService != null) && (adminService.IsLoggined()))
                {
                    adminService.Logout();
                }

                if ((userService != null) && (userService.IsLoggined()))
                {
                    userService.Logout();
                }
            }

            private static readonly object[] NewItem =
            {
                new string[] { ItemRepository.AGE }
            };

            [Test, TestCaseSource("NewItem")]
            public void AddItemTest(string newItem)
            {
                Assert.AreEqual("True", userService.AddItem(newItem).content);
                Assert.AreEqual(ItemRepository.AGE, userService.GetItem().content);
                //Console.WriteLine();
            }
            //[Test, TestCaseSource("NewItem")]
            //public void AddItemTest(string newItem)
            //{
            //    //Assert.AreEqual(userService.AddUserItem(newItem, "111").content, "True");
            //    //Assert.AreEqual(userService.GetUserItem().content, ItemRepository.AGE);
            //    Console.WriteLine(userService.AddItem(newItem).content);
            //}

            private static readonly object[] UpdateItem =
            {
                new string[] { ItemRepository.CITY }
            };

            [Test, TestCaseSource("UpdateItem")]
            public void UpdateItemTest(string updateItem)
            {
                Assert.AreEqual(userService.UpdateItem(updateItem).content, "True");
                Assert.AreEqual(ItemRepository.CITY, userService.GetItem().content);
                //Console.WriteLine();
            }

            [Test]
            public void DeleteItemTest()
            {

                Assert.AreEqual(userService.DeleteItem().content, "True");
                Assert.AreNotEqual(userService.GetUserItem().content, ItemRepository.CITY);
                //Console.WriteLine();
            }

            [Test]
            public void GetAllItemsTest()
            {
                //Assert.AreEqual(userService.GetAllItems().content, adminService.GetUserItems().content);
                List<SimpleEntity> list = userService.GetAllItems();
                foreach(var element in list)
                {
                    Console.WriteLine(element.content);
                }
  
            }

            [Test]
            public void GetAllItemsIndexesTest() //для кількох не паше
            {
                //Assert.IsTrue(adminService.GetUserItems().content.Contains(userService.GetAllItemsIndexes().content));
                Console.WriteLine(userService.GetAllItemsIndexes());
            }

            [Test]
            public void GetUserItemTest()
            {
                Console.WriteLine(adminService.GetUserItem());
            }

            [Test]
            public void GetUserItemsTest()
            {
                Console.WriteLine(adminService.GetUserItems());
            }
        }
    }
}
