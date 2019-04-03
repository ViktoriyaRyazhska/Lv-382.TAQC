using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.WishPage
{
    public class WishListPage : ABreadCrumbsPart
    {
        private WishProductContainer ProductContainer;
        private WishProduct Product;
        private IWebElement Continue => driver.FindElement(MWishListPage.locatorContinue);
        protected IWebElement emptyMessage;
        public WishListPage(IWebDriver driver) : base(driver)
        {
            RefreshContainer();
            //ProductContainer = new WishProductContainer(driver.FindElement(By.CssSelector(".table.table-bordered.table-hover tbody")));
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
                emptyMessage = driver.FindElement(MWishListPage.locatorEmptyListMessage);
            }
        }

        public WishProduct ClickOnRemoveAll()
        {
            for (int i = 0; i <= ProductContainer.GetWishedItemCount() + 1; i++)
            {
                ProductContainer.GetWishedItems()[0].ClickOnRemove();
                ProductContainer.GetWishedItems().RemoveAt(0);
                RefreshContainer();
            }
            return Product;
        }

        public void ClickOnRemoveOne()
        {
            ProductContainer.GetWishedItems()[0].ClickOnRemove();
            RefreshContainer();
        }

        public WishProduct GetWishProduct()
        {
            return Product;
        }

        public string GetEmptyMessage()
        {
            return emptyMessage.Text;
        }
    }
}
