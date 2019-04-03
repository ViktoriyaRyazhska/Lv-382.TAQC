﻿using NUnit.Framework;
using OpenCart_Testing.Pages.WishPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Threading;
using System.Collections.Generic;
using OpenCart_Testing.TestData.WishListData;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.TestData.LoginData;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class RemovingAllFromWishList : TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForWishListTests.json");
        public static object[] ReviewAddingToWishList =
        {
            new TestCaseData(WishListItemsRepository.Get().WishListItemsFromJson("ItemsFromHomePage.json"))
        };

        [Test, TestCaseSource("ReviewAddingToWishList")]
        public void CheckRemovingAllFromWishList(List<WishListItem> names)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(myUser).GotoHomePage()
                .getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(names);
            WishListPage wishlist = LoadApplication().ClickWishList();
            wishlist.ClickOnRemoveAll();
            Assert.AreEqual(0, wishlist.GetWishProductContainer().GetWishedItemCount());
        }
    }
}
