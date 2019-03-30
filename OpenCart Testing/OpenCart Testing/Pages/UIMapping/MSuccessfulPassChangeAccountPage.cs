using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MSuccessfulPassChangeAccountPage
    {
        public static By locatorSuccessfulPassChangeMessage => By.XPath("//div[@class='alert alert-success']");
    }
}
