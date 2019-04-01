using NUnit.Framework;
using OpenCart_Testing.Pages.WishListPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Threading;
using System.Collections.Generic;
using OpenCart_Testing.TestData.WishListData;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class AddingForNotLoggedIn : TestRunner
    {

        //public static object[] RevievMessageNotLogged1 =
        //{
        //   new TestCaseData(ActionMessageRepository.Get().ActionMessageFromJson("NotLoggedUser"))

        //};

        //[TestCase("Your wish list is empty.", new string[] { "iPhone", "MacBook" })]
        //[Test]
        //public void CheckRemowingAll(string expectedMessage, string[] names)
        //{
        //    HomePage page = LoadApplication();
        //    page.getProductComponentsContainer().AddItemsToWishListByNames(names);
        //    page.ClickWishList();
        //    WishListPage wishlistPage = new WishListPage(driver);
        //    foreach (WishProduct product in wishlistPage.GetWishProductContainer().GetWishedItems())
        //    {
        //        product.ClickOnRemove();
        //    }
        //    string actualMessage = wishlistPage.GetWishProductContainer().GetEmptyListMessage();
        //    Assert.AreEqual(expectedMessage, actualMessage);
        //}

        public static object[] ReviewMessageNotLogged =
        {
           new TestCaseData(ActionMessageRepository.Get().ActionMessageFromJson("NotLoggedUser.json"), WishListItemsRepository.Get().WishListItemFromJson("ItemForNotLogged.json"))         
        };

        [Test, TestCaseSource("ReviewMessageNotLogged")]
        public void CheckAddForNotLoggedIn(ActionMessage expectedMessage, WishListItem name)
        {
            HomePage page = LoadApplication();
            page.getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(name.GetItemName());
            Thread.Sleep(3000);
            UpdatedHomePage updatedPage = new UpdatedHomePage(driver);
            string actualMessage = updatedPage.GetUpdatedMessage().Text;
            Assert.AreEqual(expectedMessage.Message, actualMessage);
        }

    }
}
