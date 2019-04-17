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

        [Test, TestCaseSource(nameof(AddItemData))]
        public void AddItemTest(ItemTemplate item)
        {
            ItemTemplate existItem = item;
            userService.AddItem(existItem);
            ItemTemplate itemResult = userService.GetItem(existItem);
            Assert.AreEqual(existItem.Item, itemResult.Item);
        }


        private static readonly object[] UpdateItemData =
        {
            new object[] { ItemRepository.GetThird(), ItemRepository.GetForUpdate() }
        };

        [Test, TestCaseSource(nameof(UpdateItemData))]
        public void UpdateItemTest(ItemTemplate addItem, ItemTemplate updateItem)
        {
            //Preconditions
            ItemTemplate existItem = addItem;
            userService.AddItem(existItem);
            ItemTemplate itemResult = userService.GetItem(existItem);
            Assert.AreEqual(existItem.Item, itemResult.Item);
            //Steps
            ItemTemplate forUpdateItem = updateItem;
            userService.UpdateItem(forUpdateItem);
            ItemTemplate updatedItem = userService.GetItem(forUpdateItem);
            Assert.AreEqual(forUpdateItem.Item, updatedItem.Item);
        }

        [Test, TestCaseSource(nameof(AddItemData))]
        public void DeleteItemTest(ItemTemplate addItem)
        {
            //Preconditions
            ItemTemplate existItem = addItem;
            userService.AddItem(existItem);
            ItemTemplate itemResult = userService.GetItem(existItem);
            Assert.AreEqual(existItem.Item, itemResult.Item);
            //Steps
            ItemTemplate forDeleteItem = addItem;
            userService.DeleteItem(forDeleteItem);
            ItemTemplate deletedItem = userService.GetItem(forDeleteItem);
            Assert.AreNotEqual(forDeleteItem.Item, deletedItem.Item);
        }


        private static readonly object[] AddItemsData =
        {
            new object[] { ItemRepository.GetFirst(), ItemRepository.GetSecond(), ItemRepository.GetThird() }
        };

        [Test, TestCaseSource(nameof(AddItemsData))]
        public void GetAllItemsTest(ItemTemplate addFirstItem, ItemTemplate addSecondItem, ItemTemplate addThirdItem)
        {
            //Preconditions
            ItemTemplate firstItem = addFirstItem;
            userService.AddItem(firstItem);
            ItemTemplate secondItem = addSecondItem;
            userService.AddItem(secondItem);
            ItemTemplate thirdItem = addThirdItem;
            userService.AddItem(thirdItem);
            //Steps
            List<string> list = userService.GetAllItems();
            //Assert.AreEqual(ItemRepository.GetAllItems(), list, "Items are not equal");
            foreach (string element in list)
            {
                Console.WriteLine(element);
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

        [Test, TestCaseSource(nameof(AddItemsData))]
        public void GetAllItemsIndexesTest(ItemTemplate addFirstItem, ItemTemplate addSecondItem, ItemTemplate addThirdItem)
        {
            //Preconditions
            ItemTemplate firstItem = addFirstItem;
            userService.AddItem(firstItem);
            ItemTemplate secondItem = addSecondItem;
            userService.AddItem(secondItem);
            ItemTemplate thirdItem = addThirdItem;
            userService.AddItem(thirdItem);
            //Steps
            List<string> list = userService.GetAllItemsIndexes();
            ////Assert.AreEqual(ItemRepository., list, "Item isn`t deleted");
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }

            ////Console.WriteLine(userService.GetAllItemsIndexes());
            //Assert.AreEqual("True", userService.DeleteItem().content, "Item isn`t deleted");
            //Assert.AreNotEqual(testItem, userService.GetUserItem().content, "Item should be deleted, delete function work incorrect");
        }

        [Test, TestCaseSource(nameof(AddItemsData))]
        public void GetUserItemTest(ItemTemplate addUserItem)
        {
            //Preconditions
            ItemTemplate userItem = addUserItem;
            userService.AddItem(userItem);
            //Steps
            ItemTemplate resultItem = adminService.GetUserItem(addUserItem, simpleUser);
            Assert.AreEqual(userItem.Item, resultItem.Item);
            Console.WriteLine(resultItem.ToString());
        }

        [Test, TestCaseSource(nameof(AddItemsData))]
        public void GetUserItemsTest(ItemTemplate addFirstItem, ItemTemplate addSecondItem, ItemTemplate addThirdItem)
        {
            //Preconditions
            ItemTemplate firstItem = addFirstItem;
            userService.AddItem(firstItem);
            ItemTemplate secondItem = addSecondItem;
            userService.AddItem(secondItem);
            ItemTemplate thirdItem = addThirdItem;
            userService.AddItem(thirdItem);
            //Steps
            List<string> list = adminService.GetUserItems(simpleUser);
            foreach (string element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}

