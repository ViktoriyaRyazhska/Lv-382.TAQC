using OpenCart_Testing.Pages.StaticParts;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.AccountPages
{
    public class AccountPage: ARightLoginPart
    {
        public const string AccountIdentifier = "Edit Account";

        public AccountPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
