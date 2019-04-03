using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.ForgottenPasswordPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenCart_Testing.TestData.ChangePassData;
using OpenQA.Selenium;
using System.Threading;

namespace OpenCart_Testing.Pages.UkrnetPage
{
    public class UkrnetLoginPage
    {
        public IWebDriver driver;
        public IWebElement UkrnetUsername => driver.FindElement(MUkrnetLoginPage.locatorUkrnetUsername);
        public IWebElement UkrnetPassword => driver.FindElement(MUkrnetLoginPage.locatorUkrnetPassword);
        public IWebElement UkrnetLoginButton => driver.FindElement(MUkrnetLoginPage.locatorLoginButton);

        public UkrnetLoginPage (IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://mail.ukr.net");
        }

        public RestorePasswordPage ReadRestoreLetter(User restoreUser)
        {
            return LoginUkrnetUser(restoreUser.Email, restoreUser.Password).ClickUnread().GotoNewRecoveryLetter().ClickRestoreLink();
        }

        public UkrnetMainPage LoginUkrnetUser(string username, string userpassword)
        {
            UkrnetUsername.SendKeys(username);
            UkrnetPassword.SendKeys(userpassword);
            UkrnetLoginButton.Click();
            return new UkrnetMainPage(driver);
        }
        
    }
}
