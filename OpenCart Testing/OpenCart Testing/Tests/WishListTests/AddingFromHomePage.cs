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
    class AddingFromHomePage : TestRunner
    {
        public static object[] RevievAddingToWishList =
        {
            new TestCaseData(WishListItemsRepository.Get().WishListItemsFromJson("ItemsFromHomePage.json"))
        };

        [Test, TestCaseSource("RevievAddingToWishList")]
        public void CheckAddingFromHomePage(IList<WishListItem> names)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(REGISTERED).GotoHomePage()
                .getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(names);
            HomePage page = LoadApplication();
            WishListPage wishlist = page.ClickWishList();
            Thread.Sleep(1000);
            CollectionAssert.AreEqual(names, wishlist.GetWishProductContainer().GetWishListItemsNames());
        }
    }
}
