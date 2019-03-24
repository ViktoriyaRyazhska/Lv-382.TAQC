using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.ProductPages;
using OpenCart_Testing.TestsData;

namespace OpenCart_Testing.Tests.ReviewTabTests
{
    [TestFixture]
    class ReviewFormTests : TestRunner
    {

        public static object[] ReviewTooShortNameData =
        {
            new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortNameData.json"), ActionMessageRepository.Get().TooShortNameReviewMessage()).SetName("ReviewTooShortName")
        };

        [Test]
        [TestCaseSource("ReviewTooShortNameData")]
        public void CreateWithEmptyFieldName(Product product, IReview review, ActionMessages actionMessages)
        {
            ProductPage Iphone = LoadApplication()
                .GetProductPageByName(product.Name);
            Assert.AreEqual(actionMessages.GetMessage(), Iphone.OpenProductReviews().ReviewAddForm.CreateReview(review));
        }
    }
}
