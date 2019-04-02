using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.WishListPage
{
    public class EmptyWishListPage : WishListPage//: AWishListPage
    {
        protected IWebElement emptyMessage => driver.FindElement(MWishListPage.locatorEmptyListMessage);// withProdContainer.FindElement(MWishListPage.locatorEmptyListMessage);
        public EmptyWishListPage(IWebDriver driver) : base(driver)//(IWebElement withProdContainer) : base(withProdContainer)
        {
        }

        public IWebElement GetEmptyMessage()
        {
            return emptyMessage;
        }
    }
}
