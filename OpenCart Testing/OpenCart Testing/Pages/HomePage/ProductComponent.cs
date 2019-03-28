using OpenQA.Selenium;
using OpenCart_Testing.UIMapping.MProductComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OpenCart_Testing.Pages
{
    public class ProductComponent
    {
        private IWebElement productLayout;
        //     
        private IWebElement Name => productLayout.FindElement(MProductComponent.locatorName);
        private IWebElement PartialDescription => productLayout.FindElement(MProductComponent.locatorPartialDescription);
        private IWebElement Price => productLayout.FindElement(MProductComponent.locatorPrice);
        private IWebElement AddToCartButton => productLayout.FindElement(MProductComponent.locatorAddToCartButton);
        private IWebElement AddToWishButton => productLayout.FindElement(MProductComponent.locatorAddToWishButton);
        private IWebElement AddToCompareButton => productLayout.FindElement(MProductComponent.locatorAddToCompareButton);

        public ProductComponent(IWebElement productLayout)
        {
            this.productLayout = productLayout;
        }

        // Page Object

        //Name
        public string GetNameText()
        {
            return Name.Text;
        }

        public void ClickName()
        {
            Name.Click();
        }

        //PartialDescription
        public string GetPartialDescriptionText()
        {
            return PartialDescription.Text;
        }

        //Price
        public string GetPriceText()
        {
            return Price.Text;
        }

        //AddToCartButton
        public string GetAddToCartButtonText()
        {
            return AddToCartButton.Text;
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
        }

        //AddToWishButton
        public void ClickAddToWishButton()
        {
            AddToWishButton.Click();
        }

        //AddToCompareButton
        public void ClickAddToCompareButton()
        {
            AddToCompareButton.Click();
        }

        // Functional

        // Business Logic
    }
}
