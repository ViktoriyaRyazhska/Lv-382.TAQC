using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Pages
{
    public abstract class ATopPart
    {
        protected IWebDriver driver;
        //
        public IWebElement Currency
        { get { return driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")); } }
        public IWebElement MyAccount
        { get { return driver.FindElement(By.CssSelector("*****")); } }
        public IWebElement WishList
        { get { return driver.FindElement(By.CssSelector("*****")); } }
        public IWebElement ShoppingCart
        { get { return driver.FindElement(By.CssSelector("*****")); }}
        public IWebElement Checkout
        { get { return driver.FindElement(By.CssSelector("*****")); } }
        public IWebElement Logo
        { get { return driver.FindElement(By.CssSelector("*****")); } }
        public IWebElement SearchField
        { get { return driver.FindElement(By.CssSelector("*****")); } }
        public IWebElement SearchButton
        { get { return driver.FindElement(By.CssSelector("*****")); } }
        public IWebElement CartButton
        { get { return driver.FindElement(By.CssSelector("*****")); } }
        //
        public IList<IWebElement> TopMenu;

        public ATopPart(IWebDriver driver)
        {
            this.driver = driver;
        }

        // PageObject

        // Currency
        // MyAccount
        // WishList
        // ShoppingCart
        // Checkout
        // Logo
        // SearchField
        // SearchButton
        // CartButton
        // TopMenu

        // Functional

        // Business Logic
    }
}
