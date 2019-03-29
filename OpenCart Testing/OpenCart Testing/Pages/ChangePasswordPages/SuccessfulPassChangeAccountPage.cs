using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenCart_Testing.Pages.UIMapping;

namespace OpenCart_Testing.Pages.ChangePasswordPages
{
    public class SuccessfulPassChangeAccountPage : ChangePasswordPage
    {
        private IWebElement SuccessfulPassChangeMessage => driver.FindElement(MSuccessfulPassChangeAccountPage.locatorSuccessfulPassChangeMessage);
        public const string PassChengedMessage = "Success: Your password has been successfully updated.";
        public SuccessfulPassChangeAccountPage(IWebDriver driver) : base(driver)
        {}

        public string GetSuccessfulPassChangeMessage()
        {
            return SuccessfulPassChangeMessage.Text;
        }
    }
}
