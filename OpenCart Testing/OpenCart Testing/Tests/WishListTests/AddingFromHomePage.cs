using NUnit.Framework;
using OpenCart_Testing.Pages.WishPage;
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
            WishListPage wishlist = LoadApplication().ClickWishList();
            CollectionAssert.AreEqual(names, wishlist.GetWishProductContainer().GetWishListItemsNames());
        }
    }
}
