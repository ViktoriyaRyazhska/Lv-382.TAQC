using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.StaticParts
{
    public abstract class ARightLoginPart : ARightMenuPart
    {
        public ARightLoginPart(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement EditAccount
        { get { return driver.FindElement(MARightLoginPart.locatorEditAccount); } }
        public IWebElement Password
        { get { return driver.FindElement(MARightLoginPart.locatorPassword); } }
        public IWebElement Logout
        { get { return driver.FindElement(MARightLoginPart.locatorLogout); } }

        public string GetEditAccountText()
        {
            return EditAccount.Text;
        }

        public void ClickEditAccount()
        {
            EditAccount.Click();
        }

        public string GetPasswordText()
        {
            return Password.Text;
        }

        public void ClickPassword()
        {
            Password.Click();
        }

        public string GetLogoutText()
        {
            return Logout.Text;
        }

        public void ClickLogout()
        {
            Logout.Click();
        }


    }
}
