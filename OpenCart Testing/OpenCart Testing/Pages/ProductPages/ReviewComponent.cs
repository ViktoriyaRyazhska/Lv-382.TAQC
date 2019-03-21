using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.UIMapping.MReviewComponent;

namespace OpenCart_Testing.Pages.ProductPages
{
    public class ReviewComponen
    {
        private IWebElement reviewLayout;
        //
        private IWebElement Author =>  reviewLayout.FindElement(MReviewComponent.locatorAuthor);
        private IWebElement Date => reviewLayout.FindElement(MReviewComponent.locatorDate);
        private IWebElement Body => reviewLayout.FindElement(MReviewComponent.locatorText);
        private IList<IWebElement> Rating => reviewLayout.FindElements(MReviewComponent.locatorRating);

        public ReviewComponen(IWebElement productLayout)
        {
            this.reviewLayout = productLayout;
        }
        public string GetAuthorName => GetAuthorText();

        // Page Object

        private string GetAuthorText()
        {
            return Author.Text;
        }

        private string GetDateText()
        {
            return Date.Text;
        }


        private string GetBodyText()
        {
            return Body.Text;
        }

        private string GetRatingValue()
        {
            return Rating.Count.ToString();
        }


        // Functional
        public override bool Equals(object obj)
        {
            ReviewComponen compare = obj as ReviewComponen;
            return ((this.GetAuthorText() == compare.GetAuthorText()) 
                && (this.GetDateText() == compare.GetDateText()) 
                && (this.GetBodyText() == compare.GetBodyText()) 
                && (this.GetRatingValue() == compare.GetRatingValue()));
        }

        // Business Logic
    }
}
