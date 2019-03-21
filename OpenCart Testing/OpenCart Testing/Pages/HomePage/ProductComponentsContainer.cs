﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages
{
    public class ProductComponentsContainer
    {
        public const string PRODUCT_NOT_FOUND = "There is no product that matches the search criteria.";
        private const string PRODUCT_COMPONENT_CSSSELECTOR = ".product-layout";

        private IWebDriver driver;
        //
        public IWebElement EmptyListMessage
        {
            get
            {
                if (GetProductComponentsCount() > 0)
                {
                    // TODO Develop Custom Exception 
                    throw new Exception("Message not Found.");
                }
                return driver.FindElement(By.CssSelector("#button-search + h2 + p"));
            }
        }
        //
        private IList<ProductComponent> productComponents;

        public ProductComponentsContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }

        private void InitElements()
        {
            productComponents = new List<ProductComponent>();
            foreach (IWebElement current in driver.FindElements(By.CssSelector(PRODUCT_COMPONENT_CSSSELECTOR)))
            {
                productComponents.Add(new ProductComponent(current));
            }
        }

        // Page Object
        public IList<ProductComponent> GetProductComponents()
        {
            return productComponents;
        }

        // Functional

        public IList<string> GetProductComponentNames()
        {
            IList<string> productComponentNames = new List<string>();
            foreach (ProductComponent current in GetProductComponents())
            {
                productComponentNames.Add(current.GetNameText());
            }
            return productComponentNames;
        }

        public ProductComponent GetProductComponentByName(string productName)
        {
            ProductComponent result = null;
            foreach (ProductComponent current in GetProductComponents())
            {
                if (current.GetNameText().ToLower()
                        .Equals(productName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("ProductName: " + productName + " not Found.");
            }
            return result;
        }
        public void ProductComponentByNameClick(string name)
        {
            GetProductComponentByName(name).ClickName();
        }
        public string GetProductComponentPriceByName(string productName)
        {
            return GetProductComponentByName(productName).GetPriceText();
        }

        public string GetProductComponentDescriptionByName(string productName)
        {
            return GetProductComponentByName(productName).GetPartialDescriptionText();
        }

        public void ClickProductComponentAddToCartButtonByName(string productName)
        {
            GetProductComponentByName(productName).ClickAddToCartButton();
        }

        public void ClickProductComponentAddToWishButtonByName(string productName)
        {
            GetProductComponentByName(productName).ClickAddToWishButton();
        }

        public int GetProductComponentsCount()
        {
            return GetProductComponents().Count;
        }

        // Business Logic

        //public string GetProductComponentPriceByProduct(Product product)
        //{
        //    return GetProductComponentPriceByName(product.getName());
        //}

        //public String GetProductComponentDescriptionByProduct(Product product)
        //{
        //    return GetProductComponentDescriptionByName(product.getName());
        //}
    }
}
