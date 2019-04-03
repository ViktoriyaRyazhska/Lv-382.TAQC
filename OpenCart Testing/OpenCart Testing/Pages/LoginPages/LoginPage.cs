using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.ForgottenPasswordPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.LoginPages
{
    public class LoginPage: ABreadCrumbsPart
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Email => driver.FindElement(MLoginPage.locatorEmailTextbox);
        public IWebElement Password => driver.FindElement(MLoginPage.locatorPasswordTextbox);
        public IWebElement LoginUserButton => driver.FindElement(MLoginPage.locatorLoginButton);
        public IWebElement ForgottenPasswordLink => driver.FindElement(MLoginPage.locatorForgottenPasswordLink);

        public void SetEmail(string email)
        {
            Email.ClearAndSendKeys(email);
        }

        public void SetPassword(string password)
        {
            Password.ClearAndSendKeys(password);
        }

        public new void ClickLoginButton()
        {
            LoginUserButton.Click();
        }

        public AccountPage LoginUser(User user)
        {
            SetEmail(user.Email);
            SetPassword(user.Password);
            ClickLoginButton();
            return new AccountPage(driver);
        }

        public ForgottenPasswordPage GotoForgottenPasswordPage()
        {
            ForgottenPasswordLink.Click();
            return new ForgottenPasswordPage(driver);
        }
    }
}
