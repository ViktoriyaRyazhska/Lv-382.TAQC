using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCart_Testing.UIMapping.MATopPart
{
    public static class MATopPart
    {
        public static By locatorCurrency => By.CssSelector(".btn.btn - link.dropdown - toggle");
        public static By locatorMyAccount => By.CssSelector(".list - inline > li > a.dropdown - toggle");
        public static By locatorWishList => By.Id("wishlist-total");
        public static By locatorShoppingCart => By.CssSelector("a[title='Shopping Cart']");
        public static By locatorCheckOut => By.CssSelector("a[title='Checkout']");
        public static By locatorLogo => By.CssSelector("#logo img");
        public static By locatorSearchField => By.Name("search");
        public static By locatorSearchButton => By.CssSelector(".btn.btn-default.btn-lg");
        public static By locatorCartButton => By.CssSelector("#cart > button");
    }
}
