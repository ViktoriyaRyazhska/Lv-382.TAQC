using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping.MUpdatedHomePage
{
    public static class MUpdatedHomePage
    {
        public static By locatorMessageForNotLogged => By.CssSelector("div.alert.alert-success a[href*='/login']");
        public static By locatorMessageSuccessAddingToWishList => By.CssSelector(".alert.alert-success");

    }
}
