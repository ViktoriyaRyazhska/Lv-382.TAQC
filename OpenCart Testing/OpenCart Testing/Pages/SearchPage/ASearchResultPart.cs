using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages
{
    public class ASearchResultPart : ABreadCrumbsPart
    {
        private ProductComponentsContainer productComponentsContainer;

        public ASearchResultPart(IWebDriver driver) : base(driver)
        {
            productComponentsContainer = new ProductComponentsContainer(driver);
        }

        // Page Object
        public ProductComponentsContainer GetProductComponentsContainer()
        {
            return productComponentsContainer;
        }

        // Functional

        // Business Logic
    }
}
