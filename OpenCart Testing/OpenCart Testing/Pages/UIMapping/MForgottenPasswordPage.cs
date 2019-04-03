using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MForgottenPasswordPage
    {
        public static By locatorEmailInputField => By.XPath("//input[@id = 'input-email']");
        public static By locatorContinueButton => By.XPath("//input[@class = 'btn btn-primary']");
        public static By locatorBackButton => By.XPath("//div[@class = 'pull-left']/a");
    }
}
