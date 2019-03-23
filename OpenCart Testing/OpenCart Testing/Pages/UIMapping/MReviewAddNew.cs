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
        public static By locatorCreateMessage => By.CssSelector(".alert");
        public static By locatorReviewName => By.CssSelector("#input-name");
        public static By locatorReviewText => By.CssSelector("#input-review");
        public static By locatorRating => By.CssSelector("input[name*='rating']");
        public static By locatorCreateButton => By.CssSelector("#button-review");
    }
}
