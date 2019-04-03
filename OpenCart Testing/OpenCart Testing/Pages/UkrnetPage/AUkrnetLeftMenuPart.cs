using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UkrnetPage
{
    public abstract class AUkrnetLeftMenuPart
    {
        protected IWebDriver driver;

        public AUkrnetLeftMenuPart(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement Inbox
        { get { return driver.FindElement(MUkrnetElemntsPart.locatorInbox); } }
        protected IWebElement Draft
        { get { return driver.FindElement(MUkrnetElemntsPart.locatorDrafts); } }
        protected IWebElement Deleted
        { get { return driver.FindElement(MUkrnetElemntsPart.locatorDeleted); } }
        protected IWebElement Sent
        { get { return driver.FindElement(MUkrnetElemntsPart.locatorSent); } }
        protected IWebElement Spam
        { get { return driver.FindElement(MUkrnetElemntsPart.locatorSpam); } }
        protected IWebElement Unread
        { get { return driver.FindElement(MUkrnetElemntsPart.locatorUnread); } }
        protected IWebElement Marked
        { get { return driver.FindElement(MUkrnetElemntsPart.locatorMarked); } }
    }
}
