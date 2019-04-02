using NUnit.Framework;
using OpenCart_Testing.Pages.WishListPage;
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
            HomePage page = LoadApplication();
            WishListPage wishlist = page.ClickWishList();
            Thread.Sleep(3000);
            Assert.AreEqual(expectedMessage.Message, wishlist.GetEmptyMessage());
        }
    }
}
