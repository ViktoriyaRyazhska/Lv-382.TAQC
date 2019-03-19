using OpenCartTestProject.Data;
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
        protected const string TAG_ATTRIBUTE_VALUE = "value";
    	protected const string TAG_ATTRIBUTE_SRC = "src";
        //
        protected IWebDriver driver;
        //
        public IWebElement Currency
        { get { return driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")); } }
        public IWebElement MyAccount
        { get { return driver.FindElement(By.CssSelector(".list - inline > li > a.dropdown - toggle")); } }
        public IWebElement WishList
        { get { return driver.FindElement(By.Id("wishlist-total")); } }
        public IWebElement ShoppingCart
        { get { return driver.FindElement(By.CssSelector("a[title='Shopping Cart']")); }}
        public IWebElement Checkout
        { get { return driver.FindElement(By.CssSelector("a[title='Checkout']")); } }
        public IWebElement Logo
        { get { return driver.FindElement(By.CssSelector("#logo img")); } }
        public IWebElement SearchField
        { get { return driver.FindElement(By.Name("search")); } }
        public IWebElement SearchButton
        { get { return driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")); } }
        public IWebElement CartButton
        { get { return driver.FindElement(By.CssSelector("#cart > button")); } }
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

        // Checkout
        public string GetCheckoutText()
        {
            return Checkout.Text;
        }

	    public void ClickCheckout()
        {
            Checkout.Click();
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

        //public SearchCriteriaPage SearchItems(string searchText)
        public SearchCriteriaPage SearchItems(Product searchProduct)
        {
            MakeSearch(searchProduct.SearchKeyword);
            return new SearchCriteriaPage(driver);
        }

    }
}
