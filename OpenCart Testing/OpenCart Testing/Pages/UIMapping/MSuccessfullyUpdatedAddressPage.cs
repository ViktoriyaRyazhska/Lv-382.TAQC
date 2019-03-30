using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    public class MSuccessfullyUpdatedAddressPage
    {
        public static By locatorDeletedAddressMessage => By.XPath("//div[@class='alert alert-success']");
        public static By locatorNotDeletedAddressMessage => By.XPath("//div[@class='alert alert-warning']");
        public static By locatorNewAddressAddedMessage => By.XPath("//div[@class='alert alert-success']");
    }
}
