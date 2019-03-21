using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.UIMapping.MReviewComponentContainer;

namespace OpenCart_Testing.Pages.ProductPages
{
    public class ReviewComponentsContainer
    {
        private IWebDriver driver;

        private IList<ReviewComponen> reviewComponents;

        public ReviewComponentsContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }
        //
        private IWebElement EmptyListMessage => GetReviewComponentsCount() > 0? throw new Exception("List is not Empty") : driver.FindElement(MReviewComponentContainer.locatorReviewEmptyList);
        //

        private void InitElements()
        {
            reviewComponents = new List<ReviewComponen>();
            foreach (IWebElement current in driver.FindElements(MReviewComponentContainer.locatorReviewComponent))
            {
                reviewComponents.Add(new ReviewComponen(current));
            }
        }
        public IList<ReviewComponen> GetReviewComponents()
        {
            return reviewComponents;
        }
        public ReviewComponen GetReviewComponentByAuthor(string reviewAuthor)
        {
            ReviewComponen result = null;
            foreach (ReviewComponen current in GetReviewComponents())
            {
                if (current.GetAuthorName.Equals(reviewAuthor))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("ProductName: " + reviewAuthor + " not Found.");
            }
            return result;
        }
        public string GetReviewEmptyListText()
        {
            return EmptyListMessage.Text;
        }
        public int GetReviewComponentsCount()
        {
            return GetReviewComponents().Count;
        }

    }
}
