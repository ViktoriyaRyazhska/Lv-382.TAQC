using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.StaticParts
{
    public abstract class ARightMenuPart : ABreadCrumbsPart
    {
        public ARightMenuPart(IWebDriver driver) : base(driver)
        {
        }

        public new IWebElement MyAccount
        { get { return driver.FindElement(MARightMenuPart.locatorMyAccount); } }
        public IWebElement AddressBook
        { get { return driver.FindElement(MARightMenuPart.locatorAddressBook); } }
        public new IWebElement WishList
        { get { return driver.FindElement(MARightMenuPart.locatorWishList); } }
        public IWebElement OrderHistory
        { get { return driver.FindElement(MARightMenuPart.locatorOrderHistory); } }
        public IWebElement Downloads
        { get { return driver.FindElement(MARightMenuPart.locatorDownloads); } }
        public IWebElement RecurringPayments
        { get { return driver.FindElement(MARightMenuPart.locatorRecurringPayments); } }
        public IWebElement RewardPoints
        { get { return driver.FindElement(MARightMenuPart.locatorRewardPoints); } }
        public IWebElement Returns
        { get { return driver.FindElement(MARightMenuPart.locatorReturns); } }
        public IWebElement Transactions
        { get { return driver.FindElement(MARightMenuPart.locatorTransactions); } }
        public IWebElement Newsletter
        { get { return driver.FindElement(MARightMenuPart.locatorNewsletter); } }

        public new string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public new void ClickMyAccount()
        {
            MyAccount.Click();
        }

        public string GetAddressBookText()
        {
            return AddressBook.Text;
        }

        public void ClickAddressBook()
        {
            AddressBook.Click();
        }

        public new string GetWishListText()
        {
            return WishList.Text;
        }

        public new void ClickWishList()
        {
            WishList.Click();
        }

        public string GetOrderHistoryText()
        {
            return OrderHistory.Text;
        }

        public void ClickOrderHistory()
        {
            OrderHistory.Click();
        }

        public string GetDownloadsText()
        {
            return Downloads.Text;
        }

        public void ClickDownloads()
        {
            Downloads.Click();
        }

        public string GetRecurringPaymentsText()
        {
            return RecurringPayments.Text;
        }

        public void ClickRecurringPayments()
        {
            RecurringPayments.Click();
        }

        public string GetRewardPointsText()
        {
            return RewardPoints.Text;
        }

        public void ClickRewardPoints()
        {
            RewardPoints.Click();
        }

        public string GetReturnsText()
        {
            return Returns.Text;
        }

        public void ClickReturns()
        {
            Returns.Click();
        }

        public string GetTransactionsText()
        {
            return Transactions.Text;
        }

        public void ClickTransactions()
        {
            Transactions.Click();
        }

        public string GetNewsletterText()
        {
            return Newsletter.Text;
        }

        public void ClickNewsletter()
        {
            Newsletter.Click();
        }
        
        public AddressBookPage GotoAddressBookPage()
        {
            ClickAddressBook();
            return new AddressBookPage(driver);
        }
    }
}
