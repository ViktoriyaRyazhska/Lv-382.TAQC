using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenCart_Testing.UIMapping.MProductComponentsContainer;
using OpenCart_Testing.TestData.WishListData;
using OpenQA.Selenium.Support.UI;
using OpenCart_Testing.Pages.UIMapping.MUpdatedHomePage;

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
                    throw new Exception("Message not Found.");
                }
                return driver.FindElement(MProductComponentsContainer.locatorEmptyListMessage);
            }
        }
        
        public string GetEmptyListMessange()
        {
            return EmptyListMessage.Text;
        }

        private IList<ProductComponent> productComponents;

        public ProductComponentsContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }

        private void InitElements()
        {
            productComponents = new List<ProductComponent>();
            foreach (IWebElement current in driver.FindElements(MProductComponentsContainer.locatorProductComponent))
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
                productComponentNames.Add(current.GetNameText().ToLower());
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

        public void ClickProductComponentAddToWishButtonByName(IList<WishListItem> items)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            foreach (WishListItem item in items)
            {
                GetProductComponentByName(item.Name).ClickAddToWishButton();
                IWebElement myDynamicElement = wait.Until(driver => driver.FindElement(MUpdatedHomePage.locatorMessageSuccessAddingToWishList));
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
         
    public int GetProductComponentsCount()
        {
            return GetProductComponents().Count;
        }

        public void AddItemsToWishListByNames(string[] names)
        {
            foreach (string Name in names)
            {
                ClickProductComponentAddToWishButtonByName(Name);
            }
        }

        public HomePage HomePage
        {
            get => default(HomePage);
            set
            {
            }
        }
    }
}
