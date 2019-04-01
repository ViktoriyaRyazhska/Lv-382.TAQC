using NUnit.Framework;
using OpenCart_Testing.Pages.WishListPage;
using OpenCart_Testing.Pages.WishListPage.EmptyWishListPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Threading;
using NUnit.Framework;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class MessageAfterRemoveOneItem : TestRunner
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
            EmptyWishListPage empty = new EmptyWishListPage(application.Driver);
            //    Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(expectedMessage.GetMessage(), empty.GetEmptyMessage().Text);
        }
    }
}
