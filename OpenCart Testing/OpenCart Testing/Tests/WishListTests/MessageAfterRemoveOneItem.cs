﻿using NUnit.Framework;
using OpenCart_Testing.Pages.WishListPage;
using OpenCart_Testing.Pages;
using System.Threading;
using OpenCart_Testing.TestData.WishListData;
using System.Collections.Generic;
using OpenCart_Testing.TestData;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class MessageAfterRemoveOneItem : TestRunner
    {
        public static object[] RevievAddingToWishList =
        {
            new TestCaseData(WishListItemsRepository.Get().WishListItemsFromJson("ItemsFromHomePage.json"), ActionMessageRepository.Get().ActionMessageFromJson("RemovingOneItemMessage.json"))
        };

        [Test, TestCaseSource("RevievAddingToWishList")]
        public void CheckAddingFromHomePage(List<WishListItem> names, ActionMessage expectedMessage)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(REGISTERED).GotoHomePage()
                .getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(names);
            HomePage page = LoadApplication();
            WishListPage wishlist = page.ClickWishList();
            wishlist.ClickOnRemoveOne();
            Thread.Sleep(3000);
            UpdatedWishListPage updatedPage = new UpdatedWishListPage(application.Driver);
            Assert.AreEqual(expectedMessage.Message, updatedPage.GetUpdatedMessage().Text);
        }
    }
}

