using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MAddressBookPage
    {
        public static By locatorAddressPageHeader => By.XPath("//div[@id='content']/h2");
        public static By locatorNewAddressButton => By.XPath("//a[@class='btn btn-primary']");
    }
}
