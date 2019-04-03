using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping.MUpdatedHomePage
{
    public static class MUpdatedHomePage
    {
        public static By locatorMessageForNotLogged => By.CssSelector("div.alert.alert-success a[href*='/login']");
        public static By locatorMessageSuccessAddingToWishList => By.CssSelector(".alert.alert-success");
    }
}
