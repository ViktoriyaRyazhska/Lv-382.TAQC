using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.WishListPage
{
    public class WishListPage : ABreadCrumbsPart
    {
        private WishProductContainer ProductContainer;
        private WishProduct Product;
        private IWebElement Continue => driver.FindElement(MWishListPage.locatorContinue);
        public WishListPage(IWebDriver driver) : base(driver)
        {
            ProductContainer = new WishProductContainer(driver.FindElement(By.CssSelector(".table.table-bordered.table-hover tbody")));
        }

        public WishProductContainer GetWishProductContainer()
        {
            return ProductContainer;
        }

        public void RefreshContainer()
        {
            try
            {
                ProductContainer = new WishProductContainer(driver.FindElement(By.CssSelector(".table.table-bordered.table-hover tbody")));
            }
            catch (Exception)
            {

                
            }
            
        }

        public void ClickOnRemoveAll()
        {
            for (int i = 0; i <= ProductContainer.GetWishedItemCount() + 1; i++)
            {
                ProductContainer.GetWishedItems()[0].ClickOnRemove();
                ProductContainer.GetWishedItems().RemoveAt(0);
                Thread.Sleep(2000);
                RefreshContainer();
            }
        }

        public WishProduct GetWishProduct()
        {
            return Product;
        }
    }
}
