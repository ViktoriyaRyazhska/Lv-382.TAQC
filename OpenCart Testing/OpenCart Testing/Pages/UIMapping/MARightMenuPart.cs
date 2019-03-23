using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    public static class MARightMenuPart
    {
        public static By locatorMyAccount => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/account')]");
        public static By locatorEditAccount => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/edit')]");
        public static By locatorPassword => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/password')]");
        public static By locatorAddressBook => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/address')]");
        public static By locatorWishList => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/wishlist')]");
        public static By locatorOrderHistory => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/order')]");
        public static By locatorDownloads => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/download')]");
        public static By locatorRecurringPayments => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/recurring')]");
        public static By locatorRewardPoints => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/reward')]");
        public static By locatorReturns => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/return')]");
        public static By locatorTransactions => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/transaction')]");
        public static By locatorNewsletter => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/newsletter')]");
        public static By locatorLogout => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/logout')]");
    }
}
