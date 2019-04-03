using OpenQA.Selenium;

namespace OpenCart_Testing.UIMapping.MProductComponentsContainer
{
    public static class MProductComponentsContainer
    {
        public static By locatorEmptyListMessage => By.CssSelector("#button-search + h2 + p");
        public static By locatorProductComponent => By.CssSelector(".product-layout");       
    }
}
