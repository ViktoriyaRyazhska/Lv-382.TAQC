using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.Pages.UIMapping.MReviewAddNew;
using System.Threading;
using OpenCart_Testing.TestsData;

namespace OpenCart_Testing.Pages.ProductPages
{
    public class ReviewAddNew
    {
        private IWebDriver driver;

        private const string EmptyField = "";

        private IWebElement ReviewCreateMessage => driver.FindElement(MReviewAddNew.locatorCreateMessage);
        private IWebElement ReviewName => driver.FindElement(MReviewAddNew.locatorReviewName);
        private IWebElement ReviewText => driver.FindElement(MReviewAddNew.locatorReviewText);
        private IList<IWebElement> ReviewRatings => driver.FindElements(MReviewAddNew.locatorRating);
        private IWebElement ReviewCreateButton => driver.FindElement(MReviewAddNew.locatorCreateButton);

        public ReviewAddNew(IWebDriver driver)
        {
            this.driver = driver;

        }
        private IWebElement FindRatingElement(int rating)
        {
            foreach(IWebElement retingValue in ReviewRatings)
            {
                if (retingValue.GetAttribute("value") == rating.ToString())
                {
                    return retingValue;
                }
            }
            throw new Exception("No such rating value");
        }
        private void SetReviewName(string name)
        {
            ReviewName.ClearAndSendKeys(name);
        }
        private void SetReviewText(string text)
        {
            ReviewText.ClearAndSendKeys(text);
        }
        private void SetReviewRating(int rating)
        {
            FindRatingElement(rating).Click();
        }
        private void ClickCreateButton()
        {
            ReviewCreateButton.Click();
        }
        private string GetCreateReviewMessage()
        {
            return ReviewCreateMessage.Text;
        }
        public string CreateReview(string name = EmptyField, string text = EmptyField, int rating = 0)
        {
            if(name != string.Empty) SetReviewName(name);
            if(text != string.Empty) SetReviewText(text);
            if(rating > 0) SetReviewRating(rating);
            ClickCreateButton();
            return GetCreateReviewMessage();
        }
        public string CreateReview(IReview reviewJson)
        {
            SetReviewName(reviewJson.Name);
            SetReviewText(reviewJson.Text);
            SetReviewRating(reviewJson.Rating);
            ClickCreateButton();
            return GetCreateReviewMessage();
        }
    }
}
