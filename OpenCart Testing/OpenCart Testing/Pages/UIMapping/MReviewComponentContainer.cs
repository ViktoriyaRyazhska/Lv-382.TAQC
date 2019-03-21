using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.UIMapping.MReviewComponentContainer
{
    public static class MReviewComponentContainer
    {
        public static By locatorReviewComponent => By.CssSelector("table.table.table-striped.table-bordered");
        public static By locatorReviewEmptyList => By.CssSelector("#review p");

    }
}
