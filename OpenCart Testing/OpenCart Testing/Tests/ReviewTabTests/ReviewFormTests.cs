using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.ProductPages;
using OpenCart_Testing.TestData;

namespace OpenCart_Testing.Tests.ReviewTabTests
{
    [TestFixture]
    class ReviewFormTests : TestRunner
    {

        public static object[] ReviewNegativeData =
        {
            new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("EmptyFieldName.json"), ActionMessageRepository.Get().ActionMessageFromJson("ReviewInvalidName.json")).SetName("EmptyFieldNameTest")
            //new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortName.json"), ActionMessageRepository.Get().TooShortNameReviewMessage()).SetName("ReviewTooShortName"),
            //new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortName.json"), ActionMessageRepository.Get().TooShortNameReviewMessage()).SetName("ReviewTooShortName"),
            //new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortName.json"), ActionMessageRepository.Get().TooShortNameReviewMessage()).SetName("ReviewTooShortName"),
            //new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortName.json"), ActionMessageRepository.Get().TooShortNameReviewMessage()).SetName("ReviewTooShortName"),
            //new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortName.json"), ActionMessageRepository.Get().TooShortNameReviewMessage()).SetName("ReviewTooShortName"),
            //new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortName.json"), ActionMessageRepository.Get().TooShortNameReviewMessage()).SetName("ReviewTooShortName"),

        };

        [Test]
        [TestCaseSource("ReviewNegativeData")]
        public void CreateWithEmptyFieldName(Product product, IReview review, ActionMessage actionMessages)
        {
            ProductPage Iphone = LoadApplication()
                .GetProductPageByName(product.Name);
            Assert.AreEqual(actionMessages.Message, Iphone.OpenProductReviews().ReviewAddForm.CreateReview(review));
        }
    }
}
