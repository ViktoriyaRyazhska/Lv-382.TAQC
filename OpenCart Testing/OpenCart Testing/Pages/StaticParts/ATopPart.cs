using OpenQA.Selenium;
using System.Collections.Generic;
using OpenCart_Testing.UIMapping.MATopPart;
using OpenCart_Testing.Pages.LoginPages;
using System.Threading;

namespace OpenCart_Testing.Pages
{
    public abstract class ATopPart
    {
        protected const string TAG_ATTRIBUTE_VALUE = "value";
        protected const string TAG_ATTRIBUTE_SRC = "src";
        //
        protected IWebDriver driver;
        //
        protected IWebElement Currency
        { get { return driver.FindElement(MATopPart.locatorCurrency); } }
        protected IWebElement MyAccount
        { get { return driver.FindElement(MATopPart.locatorMyAccount); } }
        protected IWebElement WishList
        { get { return driver.FindElement(MATopPart.locatorWishList); } }
        protected IWebElement ShoppingCart
        { get { return driver.FindElement(MATopPart.locatorShoppingCart); } }
        protected IWebElement CheckOut
        { get { return driver.FindElement(MATopPart.locatorCheckOut); } }
        protected IWebElement Logo
        { get { return driver.FindElement(MATopPart.locatorLogo); } }
        protected IWebElement SearchField
        { get { return driver.FindElement(MATopPart.locatorSearchField); } }
        protected IWebElement SearchButton
        { get { return driver.FindElement(MATopPart.locatorSearchButton); } }
        protected IWebElement CartButton
        { get { return driver.FindElement(MATopPart.locatorCartButton); } }
        public IWebElement LoginButton
        { get { return driver.FindElement(MATopPart.locatorLoginButton); } }
        public IWebElement LogoutButton
        { get { return driver.FindElement(MATopPart.locatorLogoutButton); } }
        //
        protected IList<IWebElement> TopMenu;

        public ATopPart(IWebDriver driver)
        {
            this.driver = driver;
        }

        // PageObject

        // Currency
        protected string GetCurrencyText()
        {
            return Currency.Text;
        }

        protected void ClickCurrency()
        {
            Currency.Click();
        }

        // MyAccount
        protected string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }

        // WishList
        protected string GetWishListText()
        {
            return WishList.Text;
        }

        

        // ShoppingCart
        protected string GetShoppingCartText()
        {
            return ShoppingCart.Text;
        }

        protected void ClickShoppingCart()
        {
            ShoppingCart.Click();
        }

        // CheckOut
        protected string GetCheckOutText()
        {
            return CheckOut.Text;
        }

        protected void ClickCheckOut()
        {
            CheckOut.Click();
        }

        // Logo
        protected void ClickLogo()
        {
            Logo.Click();
        }

        // SearchField
        protected string GetSearchFieldText()
        {
            return SearchField.Text;
        }

        protected void SetSearchField(string text)
        {
            SearchField.SendKeys(text);
        }

        protected void ClearSearchField()
        {
            SearchField.Clear();
        }

        protected void ClickSearchField()
        {
            SearchField.Click();
        }

        // SearchButton
        protected void ClickSearchButton()
        {
            SearchButton.Click();
        }

        // CartButton
        protected string GetCartButtonText()
        {
            return CartButton.Text;
        }

        protected void ClickCartButton()
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

        public SearchCriteriaPage GoToSearchCriteriaPage()
        {
            ClickSearchButton();
            return new SearchCriteriaPage(driver);
        }

        public void ClickLoginButton()
        {
            ClickMyAccount();
            LoginButton.Click();
        }

        public LoginPage ClickLoginUserButton()
        {
            ClickMyAccount();
            LoginButton.Click();
            return new LoginPage(driver);
        }

        public void LogoutUser()
        {
            ClickMyAccount();
            LogoutButton.Click();
        }

        public WishListPage.WishListPage ClickWishList()
        {
            WishList.Click();
            return new WishListPage.WishListPage(driver);
        }
    }
}

