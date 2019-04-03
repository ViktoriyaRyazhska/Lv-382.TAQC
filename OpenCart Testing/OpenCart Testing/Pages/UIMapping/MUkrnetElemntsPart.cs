using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MUkrnetElemntsPart
    {
        public static By locatorInbox => By.XPath("//section[@class = 'sidebar__list inbox']");
        public static By locatorDrafts => By.XPath("//a[@id = '10002']");
        public static By locatorSent => By.XPath("//a[@id = '10001']");
        public static By locatorSpam => By.XPath("//a[@id = '10003']"); 
        public static By locatorDeleted => By.XPath("//a[@id = '10004']");
        public static By locatorUnread => By.XPath("//a[@id = 'unread']"); 
        public static By locatorMarked => By.XPath("//a[@id = 'marked']");
        public static By locatorNewLetter => By.XPath("//a[@class = 'msglist__row_href']");
        public static By locatorRestoreLink => By.XPath("//a[@rel='noreferrer noopener']");
        public static By locatorWarningRestoreLink => By.XPath("//a[@rel='noreferrer noopener']");
    }
}
