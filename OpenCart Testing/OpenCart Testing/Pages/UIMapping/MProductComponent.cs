using OpenQA.Selenium;

namespace OpenCart_Testing.UIMapping.MProductComponent
{
    public static class MProductComponent
    {        
        public static By locatorName => By.CssSelector("h4 a");
        public static By locatorPartialDescription => By.CssSelector("h4 + p");
        public static By locatorPrice => By.CssSelector(".price");
        public static By locatorAddToCartButton => By.CssSelector(".fa.fa-shopping-cart");
        public static By locatorAddToWishButton => By.CssSelector(".fa.fa-heart");
        public static By locatorAddToCompareButton => By.CssSelector(".fa.fa-exchange");
    }
}
