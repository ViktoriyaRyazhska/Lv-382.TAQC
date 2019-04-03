using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    public class MLoginPage
    {
        public static By locatorEmailTextbox => By.Id("input-email");
        public static By locatorPasswordTextbox => By.Id("input-password");
        public static By locatorLoginButton => By.XPath("//input[@type ='submit']");
        public static By locatorForgottenPasswordLink => By.XPath("//div[@class = 'form-group']/a");    
    }
}
