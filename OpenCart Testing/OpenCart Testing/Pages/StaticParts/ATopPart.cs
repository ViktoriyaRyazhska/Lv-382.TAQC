using OpenQA.Selenium;
using System.Collections.Generic;
using OpenCart_Testing.UIMapping.MATopPart;

namespace OpenCart_Testing.Pages
{

    public abstract class ATopPart
    {
        protected const string TAG_ATTRIBUTE_VALUE = "value";
        protected const string TAG_ATTRIBUTE_SRC = "src";
        //
        protected IWebDriver driver;
        //
        public IWebElement Currency
        { get { return driver.FindElement(MATopPart.locatorCurrency); } }
        public IWebElement MyAccount
        { get { return driver.FindElement(MATopPart.locatorMyAccount); } }
        public IWebElement WishList
        { get { return driver.FindElement(MATopPart.locatorWishList); } }
        public IWebElement ShoppingCart
        { get { return driver.FindElement(MATopPart.locatorShoppingCart); } }
        public IWebElement CheckOut
        { get { return driver.FindElement(MATopPart.locatorCheckOut); } }
        public IWebElement Logo
        { get { return driver.FindElement(MATopPart.locatorLogo); } }
        public IWebElement SearchField
        { get { return driver.FindElement(MATopPart.locatorSearchField); } }
        public IWebElement SearchButton
        { get { return driver.FindElement(MATopPart.locatorSearchButton); } }
        public IWebElement CartButton
        { get { return driver.FindElement(MATopPart.locatorCartButton); } }
        //
        public IList<IWebElement> TopMenu;

        public ATopPart(IWebDriver driver)
        {
            this.driver = driver;
        }

        // PageObject

        // Currency
        public string GetCurrencyText()
        {
            return Currency.Text;
        }

        public void ClickCurrency()
        {
            Currency.Click();
        }

        // MyAccount
        public string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }

        // WishList
        public string GetWishListText()
        {
            return WishList.Text;
        }

        public void ClickWishList()
        {
            WishList.Click();
        }

        // ShoppingCart
        public string GetShoppingCartText()
        {
            return ShoppingCart.Text;
        }

        public void ClickShoppingCart()
        {
            ShoppingCart.Click();
        }

        // CheckOut
        public string GetCheckOutText()
        {
            return CheckOut.Text;
        }

        public void ClickCheckOut()
        {
            CheckOut.Click();
        }

        // Logo
        public void ClickLogo()
        {
            Logo.Click();
        }

        // SearchField
        public string GetSearchFieldText()
        {
            return SearchField.Text;
        }

        public void SetSearchField(string text)
        {
            SearchField.SendKeys(text);
        }

        public void ClearSearchField()
        {
            SearchField.Clear();
        }

        public void ClickSearchField()
        {
            SearchField.Click();
        }

        // SearchButton
        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        // CartButton
        public string GetCartButtonText()
        {
            return CartButton.Text;
        }

        public void ClickCartButton()
        {
            CartButton.Click();
        }

        // TopMenu

        // Functional
        protected void MakeSearch(string searchText)
        {
            ClickSearchField();
            ClearSearchField();
            SetSearchField(searchText);
            ClickSearchButton();
        }

        // Business Logic

        public HomePage GotoHomePage()
        {
            ClickLogo();
            return new HomePage(driver);
        }

        public SearchCriteriaPage SearchItems(string searchText)
        {
            MakeSearch(searchText);
            return new SearchCriteriaPage(driver);
        }

    }
}

