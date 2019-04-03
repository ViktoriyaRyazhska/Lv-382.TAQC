using OpenQA.Selenium;
using OpenCart_Testing.Pages.LoginPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenCart_Testing.Pages.UkrnetPage;

namespace OpenCart_Testing.Pages.ForgottenPasswordPages
{
    public class ForgottenPasswordPage : LoginPage
    {
        private IWebElement RecoveryEmailField => driver.FindElement(MForgottenPasswordPage.locatorEmailInputField);
        private IWebElement RecoveryContinueButton => driver.FindElement(MForgottenPasswordPage.locatorContinueButton);
        private IWebElement RecoveryBackButton => driver.FindElement(MForgottenPasswordPage.locatorBackButton);

        public ForgottenPasswordPage(IWebDriver driver) : base(driver)
        { }

        public void SendRecoveryLetter(string userEmail)
        {
            RecoveryEmailField.ClearAndSendKeys(userEmail);
            RecoveryContinueButton.Click();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        //public UkrnetLoginPage GotoUkrnetMail()
        //{
        //    return new UkrnetLoginPage(driver);
        //}
    }
}
