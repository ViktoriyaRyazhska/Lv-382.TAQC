using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.WishPage
{
    public class EmptyWishListPage : WishListPage
    {
        public EmptyWishListPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement GetEmptyMessage()
        {
            return emptyMessage;
        }
    }
}
