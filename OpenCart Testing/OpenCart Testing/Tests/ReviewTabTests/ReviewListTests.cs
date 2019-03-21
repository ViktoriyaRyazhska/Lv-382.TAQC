using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenCart_Testing.Pages.ProductPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCart_Testing
{

    [TestFixture]
    public class ReviewListTests : TestRunner
    {
        [Test, Order(1)]
        public void ReviewsTest_EmptyListText()
        {
            ReviewsTab IphoneReviews = LoadApplication()
                .GetProductPageByName("iPhone")
                .OpenProductReviews();
            Assert.AreEqual("There are no reviews for this product.", IphoneReviews.ReviewsList.GetReviewEmptyListText());
        }

    }
}
