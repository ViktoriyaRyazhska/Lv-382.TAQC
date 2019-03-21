using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.UIMapping.MReviewComponent
{
    static class MReviewComponent
    {
        public static By locatorAuthor => By.CssSelector("td[style]");
        public static By locatorDate => By.CssSelector("td.text-right");
        public static By locatorText => By.Id("wishlist-total");
        public static By locatorRating => By.CssSelector("fa fa-star fa-stack-2x p");
    }
}
