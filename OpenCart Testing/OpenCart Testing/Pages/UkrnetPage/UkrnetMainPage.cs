using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UkrnetPage
{
    public class UkrnetMainPage : AUkrnetLeftMenuPart
    {
        public UkrnetMainPage(IWebDriver driver) : base(driver)
        {
        }

        public void CLickDraft()
        {
            Draft.Click();
        }

        public void CLickDeleted()
        {
            Deleted.Click();
        }

        public void CLickSent()
        {
            Sent.Click();
        }

        public void CLickSpam()
        {
            Spam.Click();
        }

        public void CLickMarked()
        {
            Marked.Click();
        }

        public UnreadPage ClickUnread()
        {
            Unread.Click();
            return new UnreadPage(driver);
        }

    }
}
