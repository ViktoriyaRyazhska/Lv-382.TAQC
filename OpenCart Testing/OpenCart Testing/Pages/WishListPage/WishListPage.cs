using OpenCart_Testing.Pages.StaticParts;
using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenQA.Selenium;
using System;

namespace OpenCart_Testing.Pages.WishPage
{
    public class WishListPage : ARightLoginPart
    {
        private WishProduct Product;
        private WishProductContainer ProductContainer;
        private IWebElement Continue => driver.FindElement(MWishListPage.locatorContinue);
        protected IWebElement emptyMessage;

        public WishListPage(IWebDriver driver) : base(driver)
        {
            RefreshContainer();
        }

        public WishProductContainer GetWishProductContainer()
        {
            return ProductContainer;
        }

        public void RefreshContainer()
        {
            try
            {
                ProductContainer = new WishProductContainer(driver.FindElement(MWishListPage.locatorElements));
            }

            catch (Exception)
            {
                emptyMessage = driver.FindElement(MWishListPage.locatorEmptyListMessage);
            }
        }

        public WishProduct ClickOnRemoveAll()
        {
            int tempCount = ProductContainer.GetWishedItemCount();
            for (int i = 0; i < tempCount; i++)
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
    }
}
