using OpenCart_Testing.Pages.StaticParts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AccountPages
{
    public class AccountPage: ARightLoginPart
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
