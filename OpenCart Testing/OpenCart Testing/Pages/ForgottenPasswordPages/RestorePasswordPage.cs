using OpenCart_Testing.Pages.LoginPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenCart_Testing.Pages.UkrnetPage;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.ForgottenPasswordPages
{
    public class RestorePasswordPage : NewLetterPage
    {
        private IWebElement NewPasswordField => driver.FindElement(MChangePasswordPage.locatorNewPasswordField);
        private IWebElement ConfirmNewPasswordField => driver.FindElement(MChangePasswordPage.locatorConfirmNewPasswordField);

        public RestorePasswordPage(IWebDriver driver) : base(driver)
        {
        }

        public void SetNewPassword(string newPassword)
        {
            NewPasswordField.ClearAndSendKeys(newPassword);
        }

        public void ConfirmNewPassword(string passwordConfirmation)
        {
            ConfirmNewPasswordField.SendKeys(passwordConfirmation + Keys.Enter);
        }

        public LoginPage RestorePassword(string newPassword, string passwordConfirmation)
        {
            SetNewPassword(newPassword);
            ConfirmNewPassword(passwordConfirmation);
            return new LoginPage(driver);
        }

    }
}
