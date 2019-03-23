using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.StaticParts
{
    public abstract class ARightMenuPart: ABreadCrumbsPart
    {
        public ARightMenuPart(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MyAccount
        { get { return driver.FindElement(MARightMenuPart.locatorMyAccount); } }
    }
}
