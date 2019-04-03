using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.WishPage
{
    public class UpdatedWishListPage : WishListPage
    {
        protected IWebElement modifiedMessage => driver.FindElement(MWishListPage.locatorModifiedListMessage);
        public UpdatedWishListPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement GetUpdatedMessage()
        {
            return modifiedMessage;
        }
    }
}
