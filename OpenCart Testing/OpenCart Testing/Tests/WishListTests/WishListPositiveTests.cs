using NUnit.Framework;
using OpenCart_Testing.Pages.WishListPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class WishListPositiveTests : TestRunner
    {

        public static object[] RevievMessageNotLogged =
        {
            new TestCaseData( .GetIphone(), ReviewsRepository.Get().NewReviewFromJson("EmptyFieldName.json"), ActionMessageRepository.Get().ActionMessageFromJson("ReviewInvalidName.json")).SetName("EmptyFieldNameTest")
            
        };

        //[TestCase("Your wish list is empty.", new string[] { "iPhone","MacBook"})]
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


        // [TestCase("login", "iPhone")]
        [Test]
        public void CheckAddForNotLoggedIn(string expectedMessage, string name)
        {
            HomePage page = LoadApplication();
            page.getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(name);
            //Thread.Sleep(3000);
            UpdatedHomePage updatedPage = new UpdatedHomePage(driver);
            string actualMessage = updatedPage.GetUpdatedMessage().Text;
            Assert.AreEqual(expectedMessage, actualMessage);
        }


    }
}
