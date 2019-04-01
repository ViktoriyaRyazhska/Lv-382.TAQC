using NUnit.Framework;
using OpenCart_Testing.Pages.WishListPage;
using OpenCart_Testing.Pages.WishListPage.EmptyWishListPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Threading;
using System.Collections.Generic;
using OpenCart_Testing.TestData.WishListData;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class MessageAfterRemovingOneItem : TestRunner
    {
        public static object[] RevievAddingToWishList =
        {
            new TestCaseData(ActionMessageRepository.Get().ActionMessageFromJson("RemovingAllMessage.json"))
        };

        [Test, TestCaseSource("RevievAddingToWishList")]
        public void CheckAddingFromHomePage(ActionMessage expectedMessage)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(REGISTERED).GotoHomePage();
            HomePage page = LoadApplication();
            WishListPage wishlist = page.ClickWishList();
            Thread.Sleep(3000);
            EmptyWishListPage empty = new EmptyWishListPage(driver);
            //    Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(expectedMessage.GetMessage(), empty.GetEmptyMessage().Text);
        }
    }
}
