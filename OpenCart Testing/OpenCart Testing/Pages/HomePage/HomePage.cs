using OpenQA.Selenium;

namespace OpenCart_Testing.Pages
{
    public class HomePage : ABreadCrumbsPart
    {
        public const string IPHONE6 = "iPhone6";

        public IWebElement Slideshow0
        { get { return driver.FindElement(By.Id("slideshow0")); } }

        private ProductComponentsContainer productComponentsContainer;

        public HomePage(IWebDriver driver) : base(driver)
        {
            productComponentsContainer = new ProductComponentsContainer(driver);
        }
        
        public IWebElement GetSlideshow0FirstImage()
        {
            return Slideshow0.FindElement(By.XPath(".//a/img"));
        }

        public string GetSlideshow0FirstImageAttributeText(string attribute)
        {
            return GetSlideshow0FirstImage().GetAttribute(attribute).Trim();
        }

        public string GetSlideshow0FirstImageAttributeSrcText()
        {
            return GetSlideshow0FirstImageAttributeText(TAG_ATTRIBUTE_SRC);
        }
        
        public ProductComponentsContainer getProductComponentsContainer()
        {
            return productComponentsContainer;
        }
        public ProductPage GetProductPageByName(string name)
        {
            productComponentsContainer.ProductComponentByNameClick(name);
            return new ProductPage(driver);
        }
    }
}
