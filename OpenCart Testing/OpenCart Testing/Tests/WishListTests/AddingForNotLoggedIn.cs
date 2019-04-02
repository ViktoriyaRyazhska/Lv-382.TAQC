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

        public static object[] ReviewMessageNotLogged =
        {
           new TestCaseData(ActionMessageRepository.Get().ActionMessageFromJson("NotLoggedUser.json"), WishListItemsRepository.Get().WishListItemFromJson("ItemForNotLogged.json"))         
        };

        [Test, TestCaseSource("ReviewMessageNotLogged")]
        public void CheckAddForNotLoggedIn(ActionMessage expectedMessage, WishListItem name)
        {
            HomePage page = LoadApplication();
            page.getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(name.GetItemName());
            UpdatedHomePage updatedPage = new UpdatedHomePage(application.Driver);           
            Assert.AreEqual(expectedMessage.Message, updatedPage.GetUpdatedMessage().Text);
        }

    }
}
