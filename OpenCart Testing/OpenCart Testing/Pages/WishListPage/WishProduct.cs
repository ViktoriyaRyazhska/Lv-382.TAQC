using OpenQA.Selenium;
using System.Collections.Generic;
using OpenCart_Testing.Pages.UIMapping.MWishPoduct;
using OpenCart_Testing.Pages.UIMapping.MWishListPage;
using OpenCart_Testing.TestData.WishListData;

namespace OpenCart_Testing.Pages.WishPage
{
    public class WishProduct
    {
        private IWebElement wishItem;
        private IWebElement Image => wishItem.FindElement(MWishProduct.locatorImg);
        private IWebElement ProductName => wishItem.FindElement(MWishProduct.locatorProductName);
        private IWebElement Model => wishItem.FindElement(MWishProduct.locatorModel);
        private IWebElement Stock => wishItem.FindElement(MWishProduct.locatorStock);
        private IWebElement UnitPrice => wishItem.FindElement(MWishProduct.locatorUnitPrice);
        private IWebElement AddToCart => wishItem.FindElement(MWishProduct.locatorAddToCart);
        private IWebElement Remove => wishItem.FindElement(MWishProduct.locatorRemove);
        private IWebElement ModifiedMessage => wishItem.FindElement(MWishListPage.locatorModifiedListMessage);

        public WishProduct(IWebElement productLayout)
        {
            this.wishItem = productLayout;
        }

        private void ClickOnImg()
        {
            Image.Click();
        }

        private void ClickOnProductName()
        {
           ProductName.Click();
        }

        private string GetProductNameText()
        {
            return ProductName.Text;
        }

        public string ProductNameText => GetProductNameText();
        private string GetModelText()
        {
            return Model.Text;
        }

        private string GetStockText()
        {
            return Stock.Text;
        }

        private string GetUnitPriceText()
        {
            return UnitPrice.Text;
        }

        private void ClickOnAddToCart()
        {
            AddToCart.Click();
        }

        public void ClickOnRemove()
        {
            Remove.Click();
        }

        public void ClickOnRemove(IList<WishListItem> items)
        {
            foreach (WishListItem item in items)
            {
                Remove.Click();
            }
        }

        public string GetModifiedListMessage()
        {
            ClickOnRemove();
            return ModifiedMessage.Text;
        }
    }
}
