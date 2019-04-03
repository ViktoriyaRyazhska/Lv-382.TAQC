using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCart_Testing.Pages.UkrnetPage
{
    public class UnreadPage : AUkrnetLeftMenuPart
    {
        public UnreadPage(IWebDriver driver) : base(driver)
        { }

        public void WaitAndClickNewLetter()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(600));
            IWebElement letter = wait.Until<IWebElement>(d => d.FindElement(MUkrnetElemntsPart.locatorNewLetter));
            letter.Click();
        }

        public NewLetterPage GotoNewRecoveryLetter()
        {
            WaitAndClickNewLetter();
            return new NewLetterPage(driver);
        }

    }
}
