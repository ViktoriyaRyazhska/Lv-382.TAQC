using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MARightLoginPart
    {
        public static By locatorEditAccount => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/edit')]");
        public static By locatorPassword => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/password')]");
        public static By locatorLogout => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/logout')]");
    }
}
