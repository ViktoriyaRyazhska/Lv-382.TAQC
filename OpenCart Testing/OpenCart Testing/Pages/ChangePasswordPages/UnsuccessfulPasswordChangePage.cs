using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.ChangePasswordPages
{
    public class UnsuccessfulPasswordChangePage : ChangePasswordPage
    {
        private IWebElement UnsuccessfulPassChangeMessage => driver.FindElement(MUnsuccessfulPassChangePage.locatorUnsuccessfulPassChangeMessage);
        public const string PassChengedMessage = "Password confirmation does not match password!";
        public UnsuccessfulPasswordChangePage(IWebDriver driver) : base(driver)
        {
        }
        public string GetUnsuccessfulPassChangeMessage()
        {
            return UnsuccessfulPassChangeMessage.Text;
        }
    }
}
