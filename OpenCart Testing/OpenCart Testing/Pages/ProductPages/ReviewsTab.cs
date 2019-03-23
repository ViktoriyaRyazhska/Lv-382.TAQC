using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.ProductPages
{
    public class ReviewsTab
    {
        private IWebDriver driver;
        public ReviewComponentsContainer ReviewsList { get; private set; }
        public ReviewAddNew ReviewAddForm { get; private set; }

        public ReviewsTab(IWebDriver driver)
        {
            this.driver = driver;
            initElements();
        }
        private void initElements()
        {
            ReviewsList = new ReviewComponentsContainer(driver);
            ReviewAddForm = new ReviewAddNew(driver);
        }
        

    }
}
