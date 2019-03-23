using NUnit.Framework;
using OpenCart_Testing.Pages.ProductPages;
using OpenCart_Testing.TestData;

namespace OpenCart_Testing.Tests.ReviewTabTests
{
    [TestFixture]
    class ReviewFormTests : TestRunner
    {
        //[Test, TestCaseSource(typeof(ReviewsRepository), "InvalidReviews")]
        //public void CreateWithEmptyFieldName(Review invalid)
        //{
        //    string CreateMessage = LoadApplication()
        //        .GetProductPageByName(invalid.ProductName)a
        //        .OpenProductReviews()
        //        .ReviewAddForm
        //        .CreateReview(invalid.Name, invalid.Text, invalid.Rating);
        //    Assert.AreEqual("Warning: Review Name must be between 3 and 25 characters!", CreateMessage);
        //}
    }
}
