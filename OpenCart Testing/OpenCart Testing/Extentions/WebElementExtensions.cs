using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing
{
    public static class WebElementExtensions
    {
        public static void ClearAndSendKeys(this IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }
        public static void ClickExtended(this IWebElement element)
        {
            Application.WaitBeforeClick();
            element.Click();
        }
    }
}
