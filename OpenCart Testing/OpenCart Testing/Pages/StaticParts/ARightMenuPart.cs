using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.StaticParts
{
    public abstract class ARightMenuPart: ABreadCrumbsPart
    {
        public ARightMenuPart(IWebDriver driver) : base(driver)
        {
        }

        public new IWebElement MyAccount
        { get { return driver.FindElement(MARightMenuPart.locatorMyAccount); } }
        public IWebElement EditAccount
        { get { return driver.FindElement(MARightMenuPart.locatorEditAccount); } }
        public IWebElement Password
        { get { return driver.FindElement(MARightMenuPart.locatorPassword); } }
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
        public IWebElement Logout
        { get { return driver.FindElement(MARightMenuPart.locatorLogout); } }


    }
}
