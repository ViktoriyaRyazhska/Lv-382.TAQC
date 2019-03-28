using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    public class MLoginPage
    {
        public static By locatorEmailTextbox => By.Id("input-email");
        public static By locatorPasswordTextbox => By.Id("input-password");
        public static By locatorLoginButton => By.XPath("//input[@type ='submit']");
    }
}
