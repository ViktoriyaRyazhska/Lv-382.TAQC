using NUnit.Framework;
using OpenCart_Testing.Pages.WishPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Threading;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.TestData.LoginData;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class MessageForEmptyList : TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForWishListTests.json");
        public static object[] ReviewAddingToWishList =
        {
            new TestCaseData(ActionMessageRepository.Get().ActionMessageFromJson("RemovingAllMessage.json"))
        };

        [Test, TestCaseSource("ReviewAddingToWishList")]
        public void CheckMessageForEmptyList(ActionMessage expectedMessage)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(myUser).GotoHomePage();
            WishListPage wishlist = LoadApplication().ClickWishList();
            EmptyWishListPage empty = new EmptyWishListPage(application.Driver);
            Assert.AreEqual(expectedMessage.GetMessage(), empty.GetEmptyMessage().Text);
        }
    }
}
