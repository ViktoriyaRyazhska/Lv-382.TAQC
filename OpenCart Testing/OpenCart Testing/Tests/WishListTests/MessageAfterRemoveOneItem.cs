using NUnit.Framework;
using OpenCart_Testing.Pages.WishPage;
using OpenCart_Testing.TestData.WishListData;
using System.Collections.Generic;
using OpenCart_Testing.TestData;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.TestData.LoginData;
using System.Threading;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class MessageAfterRemoveOneItem : TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForWishListTests.json");
        private UpdatedWishListPage updatedPage;

        public static object[] ReviewAddingToWishList =
        {
            new TestCaseData(WishListItemsRepository.Get().WishListItemsFromJson("ItemsFromHomePage.json"), ActionMessageRepository.Get().ActionMessageFromJson("RemovingOneItemMessage.json"))
        };

        [Test, TestCaseSource("ReviewAddingToWishList")]
        public void CheckMessageAfterRemoveOneItem(List<WishListItem> names, ActionMessage expectedMessage)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(myUser).GotoHomePage()
                .getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(names);
            WishListPage wishlist = LoadApplication().ClickWishList();
            wishlist.ClickOnRemoveOne();
            updatedPage = new UpdatedWishListPage(application.Driver);
            Assert.AreEqual(expectedMessage.Message, updatedPage.GetUpdatedMessage().Text);
        }

        [TearDown]
        public void AfterTest()
        {
            if (updatedPage != null)
            {
                updatedPage.ClickOnRemoveAll();
            }
        }
    }
}

