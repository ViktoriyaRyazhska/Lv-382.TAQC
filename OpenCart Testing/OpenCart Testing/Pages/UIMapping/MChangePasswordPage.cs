using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MChangePasswordPage
    {
        public static By locatorChangePassHeader => By.XPath("//div[@id='content']/h1");
        public static By locatorPassContinueButton => By.XPath("//input[@class = 'btn btn-primary']");
        public static By locatorPassBackButton => By.XPath("//a[@class='btn btn-default']");
        public static By locatorNewPasswordField => By.XPath("//input[@id='input-password']");
        public static By locatorConfirmNewPasswordField => By.XPath("//input[@id='input-confirm']");
    }
}
