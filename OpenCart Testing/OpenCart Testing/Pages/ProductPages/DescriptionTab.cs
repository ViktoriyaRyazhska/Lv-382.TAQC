using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.UIMapping.MDescriptionComponent;

namespace OpenCart_Testing.Pages.ProductPages
{
    public class DescriptionTab
    {
        private IWebDriver driver;
        private IWebElement DescriptionText => driver.FindElement(MDescriptionComponent.locatorDescriptionText);
        public DescriptionTab(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string GetDescriptionText()
        {
            return DescriptionText.Text;
        }
    }
}
