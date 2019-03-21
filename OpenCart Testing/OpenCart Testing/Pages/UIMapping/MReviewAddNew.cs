using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping.MReviewAddNew
{
    static public class MReviewAddNew
    {
        public static By locatorCreateMessage => By.CssSelector("a[href*='tab-description']");
        public static By locatorReviewName => By.CssSelector("a[href*='tab-description']");
        public static By locatorReviewText => By.CssSelector("a[href*='tab-description']");
        public static By locatorRating => By.CssSelector("a[href*='tab-description']");
        public static By locatorCreateButton => By.CssSelector("a[href*='tab-description']");
    }
}
