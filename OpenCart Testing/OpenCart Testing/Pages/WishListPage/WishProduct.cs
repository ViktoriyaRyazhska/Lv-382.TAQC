using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.Pages.UIMapping.MWishPoduct;
using OpenCart_Testing.Pages.UIMapping.MWishListPage;

namespace OpenCart_Testing.Pages.WishListPage
{
    public class WishProduct
    {
        private IWebElement revievItem;
        private IWebElement Image => revievItem.FindElement(MWishProduct.locatorImg);
        private IWebElement ProductName => revievItem.FindElement(MWishProduct.locatorProductName);
        private IWebElement Model => revievItem.FindElement(MWishProduct.locatorModel);
        private IWebElement Stock => revievItem.FindElement(MWishProduct.locatorStock);
        private IWebElement UnitPrice => revievItem.FindElement(MWishProduct.locatorUnitPrice);
        private IWebElement AddToCart => revievItem.FindElement(MWishProduct.locatorAddToCart);
        private IWebElement Remove => revievItem.FindElement(MWishProduct.locatorRemove);
        private IWebElement ModifiedMessage => revievItem.FindElement(MWishListPage.locatorModifiedListMessage);

        public WishProduct(IWebElement productLayout)
        {
            this.revievItem = productLayout;
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

        public string GetModifiedListMessage()
        {
            ClickOnRemove();
            return ModifiedMessage.Text;
        }

        public override bool Equals(object obj)
        {
            WishProduct compare = obj as WishProduct;
            return (this.GetProductNameText() == compare.GetProductNameText())
                && (this.GetModelText() == compare.GetModelText())
                && (this.GetStockText() == compare.GetStockText())
                && (this.GetUnitPriceText() == compare.GetUnitPriceText());
        }
    }
}
