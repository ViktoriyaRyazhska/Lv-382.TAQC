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
//<<<<<<< HEAD:OpenCart Testing/OpenCart Testing/Tests/WishListTests/MessageForEmptyList.cs
//            Assert.AreEqual(expectedMessage.Message, wishlist.GetEmptyMessage());
//=======
//            EmptyWishListPage empty = new EmptyWishListPage(application.Driver);
//            //    Assert.AreEqual(expectedMessage, actualMessage);
//            Assert.AreEqual(expectedMessage.GetMessage(), empty.GetEmptyMessage().Text);
//>>>>>>> aefe4e38b610897a70632dc0ae5acc9417dca282:OpenCart Testing/OpenCart Testing/Tests/WishListTests/MessageAfterRemovingOneItem.cs
        }
    }
}
