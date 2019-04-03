using NUnit.Framework;
using OpenCart_Testing.Pages.WishPage;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Threading;
using System.Collections.Generic;
using OpenCart_Testing.TestData.WishListData;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.TestData.LoginData;

namespace OpenCart_Testing.Tests.WishListTests
{
    [TestFixture]
    class AddingFromHomePage : TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForWishListTests.json");
        public static object[] RevievAddingToWishList =
        {
            new TestCaseData(WishListItemsRepository.Get().WishListItemsFromJson("ItemsFromHomePage.json"))
        };

        [Test, TestCaseSource("RevievAddingToWishList")]
        public void CheckAddingFromHomePage(IList<WishListItem> names)
        {
            LoadApplication().ClickLoginUserButton().LoginUser(myUser).GotoHomePage()
                .getProductComponentsContainer().ClickProductComponentAddToWishButtonByName(names);
            WishListPage wishlist = LoadApplication().ClickWishList();
            CollectionAssert.AreEqual(names, wishlist.GetWishProductContainer().GetWishListItemsNames());
        }
    }
}
