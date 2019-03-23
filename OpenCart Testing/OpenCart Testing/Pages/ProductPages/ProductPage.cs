using OpenQA.Selenium;
using OpenCart_Testing.UIMapping.MProductPage;
using System.Threading;

namespace OpenCart_Testing.Pages.ProductPages
{
    public class ProductPage : ABreadCrumbsPart
    {
        private DescriptionTab description;
        private ReviewsTab reviews;
        private IWebElement Description => driver.FindElement(MProductPage.locatorDescription);
        private IWebElement Reviews => driver.FindElement(MProductPage.locatorReviews);
        public ProductPage(IWebDriver driver) : base(driver)
        {
            description = new DescriptionTab(driver);
            reviews = new ReviewsTab(driver);
        }
        public string GetDescriptionText()
        {
            return Description.Text;
        }

        private void ClicDescriptiont()
        {
            Description.Click();
        }
        public string GetReviewsText()
        {
            return Reviews.Text;
        }

        private void ClickReviews()
        {
            Reviews.ClickExtended();
        }

        public int GetReviewsCountAll()
        {
            return int.Parse(GetReviewsText().Split(new char[] { '(', ')' })[1]);
        }

        public DescriptionTab OpenProductDescription()
        {
            ClicDescriptiont();
            return description;
        }

        public ReviewsTab OpenProductReviews()
        {
            ClickReviews();
            return reviews;
        }


    }
}
