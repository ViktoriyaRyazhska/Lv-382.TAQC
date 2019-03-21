using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.Pages.UIMapping.MReviewAddNew;

namespace OpenCart_Testing.Pages.ProductPages
{
    public class ReviewAddNew
    {
        private IWebDriver driver;

        private IWebElement ReviewCreateMessage => driver.FindElement(locatorCreateMessage);
        private IWebElement ReviewName => driver.FindElement();
        private IWebElement ReviewText => driver.FindElement();
        private IWebElement ReviewRating => driver.FindElement();
        private IWebElement ReviewCreateButton => driver.FindElement();

        public ReviewAddNew(IWebDriver driver)
        {
            this.driver = driver;

        }

        }
}
