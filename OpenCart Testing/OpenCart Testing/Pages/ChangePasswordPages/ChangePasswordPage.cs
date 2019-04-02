using OpenCart_Testing.Pages.StaticParts;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Threading;


namespace OpenCart_Testing.Pages.ChangePasswordPages
{
    public class ChangePasswordPage : ARightLoginPart
    {
        private IWebElement ChangePassPageHeader => driver.FindElement(MChangePasswordPage.locatorChangePassHeader);
        private IWebElement ChangePassContinueButton => driver.FindElement(MChangePasswordPage.locatorPassContinueButton);
        private IWebElement NewPasswordField => driver.FindElement(MChangePasswordPage.locatorNewPasswordField);
        private IWebElement ConfirmNewPasswordField => driver.FindElement(MChangePasswordPage.locatorConfirmNewPasswordField);

        private string newPassword = Environment.GetEnvironmentVariable("NewPassword");
        private string passwordConfirmation = Environment.GetEnvironmentVariable("NewPassword");


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

        public void SetNewPassword()
        {
            NewPasswordField.ClearAndSendKeys(newPassword);
        }

        public void ConfirmNewPassword()
        {
            ConfirmNewPasswordField.ClearAndSendKeys(passwordConfirmation);
        }

        public SuccessfulPassChangeAccountPage SuccessfulChangePassword()
        {
            SetNewPassword();
            ConfirmNewPassword();
            ClickChangePassContinueButton();
            return new SuccessfulPassChangeAccountPage(driver);
        }
    }
}
