using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.WishListPage
{
    public class WishListPage : ABreadCrumbsPart
    {
        private WishProductContainer WishProductContainer;
        private IWebElement Continue => driver.FindElement(MWishListPage.locatorContinue);       
        public WishListPage(IWebDriver driver) : base(driver)
        {
            WishProductContainer = new WishProductContainer(driver);
        }

        public WishProductContainer GetWishProductContainer()
        {
            return WishProductContainer;
        }
    }
}
