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
            new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().NewReviewFromJson("TooShortNameData.json")).SetName("ReviewTooShortName")
        };

        [Test]
        [TestCaseSource("ReviewTooShortNameData")]
        public void CreateWithEmptyFieldName(Review invalid)
        {
            ProductPage Iphone = LoadApplication()
                .GetProductPageByName(product.Name);
            Assert.AreEqual("Warning: Review Name must be between 3 and 25 characters!", CreateMessage);
        }
    }
}
