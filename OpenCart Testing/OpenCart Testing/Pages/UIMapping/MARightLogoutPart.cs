using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MARightLogoutPart
    {
        public static By locatorLogin => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/login')]");
        public static By locatorRegister => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/register')]");
        public static By locatorForgottenPassword => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/forgotten')]");
    }
}
