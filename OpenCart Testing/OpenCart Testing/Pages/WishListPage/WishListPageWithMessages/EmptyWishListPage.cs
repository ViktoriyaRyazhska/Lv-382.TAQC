using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.WishPage
{
    public class EmptyWishListPage : WishListPage
    {
       // protected IWebElement emptyMessage => driver.FindElement(MWishListPage.locatorEmptyListMessage);
        public EmptyWishListPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement GetEmptyMessage()
        {
            return emptyMessage;
        }
    }
}
