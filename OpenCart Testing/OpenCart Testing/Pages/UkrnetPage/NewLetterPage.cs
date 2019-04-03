using OpenCart_Testing.Pages.ForgottenPasswordPages;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace OpenCart_Testing.Pages.UkrnetPage
{
    public class NewLetterPage : AUkrnetLeftMenuPart
    {
        public IWebElement RestoreLink => driver.FindElement(MUkrnetElemntsPart.locatorRestoreLink);

        public NewLetterPage(IWebDriver driver) : base(driver)
        {
        }

        public RestorePasswordPage ClickRestoreLink()
        {
            RestoreLink.Click();
            ///Switch current tab
            ReadOnlyCollection<string> handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[1]);
            
            return new RestorePasswordPage(driver);
        }
    }
}
