using OpenQA.Selenium;
using System.Collections.Generic;
using OpenCart_Testing.UIMapping.MATopPart;
using OpenCart_Testing.Pages.LoginPages;
using System.Threading;
using OpenCart_Testing.TestData;
using OpenCart_Testing.Pages.WishPage;

namespace OpenCart_Testing.Pages
{
    public abstract class ATopPart
    {
        protected const string TAG_ATTRIBUTE_VALUE = "value";
        protected const string TAG_ATTRIBUTE_SRC = "src";
        
        protected IWebDriver driver;
        
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
        
        protected IList<IWebElement> TopMenu;

        public ATopPart(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected string GetCurrencyText()
        {
            return Currency.Text;
        }

        protected void ClickCurrency()
        {
            Currency.Click();
        }

        protected string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }

        protected string GetWishListText()
        {
            return WishList.Text;
        }

        protected string GetShoppingCartText()
        {
            return ShoppingCart.Text;
        }

        protected void ClickShoppingCart()
        {
            ShoppingCart.Click();
        }

        protected string GetCheckOutText()
        {
            return CheckOut.Text;
        }

        protected void ClickCheckOut()
        {
            CheckOut.Click();
        }

        protected void ClickLogo()
        {
            Logo.Click();
        }

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

        protected void ClickSearchButton()
        {
            SearchButton.Click();
        }

        protected string GetCartButtonText()
        {
            return CartButton.Text;
        }

        protected void ClickCartButton()
        {
            CartButton.Click();
        }

        protected void MakeSearch(string searchText)
        {
            ClickSearchField();
            ClearSearchField();
            SetSearchField(searchText);
            ClickSearchButton();
        }

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

        public WishListPage ClickWishList()
        {
            WishList.Click();
            Thread.Sleep(1000);
            return new WishListPage(driver);
        }
    }
}

