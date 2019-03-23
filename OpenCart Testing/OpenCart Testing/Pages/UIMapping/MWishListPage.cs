using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping.MWishListPage
{
    class MWishListPage
    {
        public static By locatorContinue => By.CssSelector("a.btn.btn-primary");
        public static By locatorElements => By.CssSelector(".table-responsive tbody"); 
        public static By locatorWishItem => By.CssSelector(".table-responsive tbody tr");
        public static By locatorEmptyListMessage => By.CssSelector("div[class = 'col-sm-9']>p");
        public static By locatorModifiedListMessage => By.CssSelector("div.alert.alert-success");
    }
}
