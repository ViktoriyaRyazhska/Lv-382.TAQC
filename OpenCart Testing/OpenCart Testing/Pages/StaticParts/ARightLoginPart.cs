using OpenCart_Testing.Pages.ChangePasswordPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;

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

        public ChangePasswordPage GotoChangePasswordPage()
        {
            ClickPassword();
            return new ChangePasswordPage(driver);
        }
    }
}
