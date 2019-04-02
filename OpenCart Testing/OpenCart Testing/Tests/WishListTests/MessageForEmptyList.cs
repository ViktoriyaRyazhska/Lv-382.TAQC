using NUnit.Framework;
using OpenCart_Testing.Pages.WishPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Threading;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class MessageForEmptyList : TestRunner
    {
        public static object[] RevievAddingToWishList =
        {
            new TestCaseData(ActionMessageRepository.Get().ActionMessageFromJson("RemovingAllMessage.json"))
        };

        [Test, TestCaseSource("RevievAddingToWishList")]
        public void CheckAddingFromHomePage(ActionMessage expectedMessage)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(REGISTERED).GotoHomePage();
            WishListPage wishlist = LoadApplication().ClickWishList();
            EmptyWishListPage empty = new EmptyWishListPage(application.Driver);
            Assert.AreEqual(expectedMessage.GetMessage(), empty.GetEmptyMessage().Text);
        }
    }
}
