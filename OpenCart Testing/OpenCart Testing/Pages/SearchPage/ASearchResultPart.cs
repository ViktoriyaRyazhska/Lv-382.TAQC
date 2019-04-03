using OpenQA.Selenium;

namespace OpenCart_Testing.Pages
{
    public class ASearchResultPart : ABreadCrumbsPart
    {
        private ProductComponentsContainer productComponentsContainer;

        public ASearchResultPart(IWebDriver driver) : base(driver)
        {
            productComponentsContainer = new ProductComponentsContainer(driver);
        }

        public ProductComponentsContainer GetProductComponentsContainer()
        {
            return productComponentsContainer;
        }
    }
}
