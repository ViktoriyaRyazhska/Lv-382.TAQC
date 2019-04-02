using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;


namespace OpenCart_Testing.Pages.ChangePasswordPages
{
    public class ChangePasswordPage : AccountPage
    {
        private IWebElement ChangePassPageHeader => driver.FindElement(MChangePasswordPage.locatorChangePassHeader);
        private IWebElement ChangePassContinueButton => driver.FindElement(MChangePasswordPage.locatorPassContinueButton);
        private IWebElement NewPasswordField => driver.FindElement(MChangePasswordPage.locatorNewPasswordField);
        private IWebElement ConfirmNewPasswordField => driver.FindElement(MChangePasswordPage.locatorConfirmNewPasswordField);

        public ChangePasswordPage(IWebDriver driver) : base(driver)
        { }

        public string GetChangePassPageHeaderText()
        {
            return ChangePassPageHeader.Text;
        }

        public void ClickChangePassContinueButton()
        {
            ChangePassContinueButton.Click();
        }

        public void SetNewPassword(string newPassword)
        {
            NewPasswordField.ClearAndSendKeys(newPassword);
        }

        public void ConfirmNewPassword(string passwordConfirmation)
        {
            ConfirmNewPasswordField.ClearAndSendKeys(passwordConfirmation);
        }

        public SuccessfulPassChangeAccountPage SuccessfulChangePassword(string newPassword, string passwordConfirmation)
        {
            SetNewPassword(newPassword);
            ConfirmNewPassword(passwordConfirmation);
            ClickChangePassContinueButton();
            return new SuccessfulPassChangeAccountPage(driver);
        }

        public UnsuccessfulPasswordChangePage UnsuccessfulChangePassword(string newPassword, string passwordConfirmation)
        {
            SetNewPassword(newPassword);
            ConfirmNewPassword(passwordConfirmation);
            ClickChangePassContinueButton();
            return new UnsuccessfulPasswordChangePage(driver);
        }

    }
}
