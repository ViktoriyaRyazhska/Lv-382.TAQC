using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestsData;

namespace OpenCart_Testing
{

    [TestFixture]
    public class ReviewListTests : TestRunner
    {
        public static object[] ReviewEmptyListData =
        {
            new TestCaseData(ProductRepository.Get().GetIphone(), ReviewsRepository.Get().GetReviewEmptyListMessage()).SetName("ReviewEmptyListText")
        };



        [Test]
        [TestCaseSource("ReviewEmptyListData"), Order(1)]
        public void ReviewsTest_EmptyListText(Product product, string emptyListMessage)
        {
            ProductPage Iphone = LoadApplication()
                .GetProductPageByName(product.Name);
            Assert.AreEqual(emptyListMessage, Iphone.OpenProductReviews().ReviewsList.GetReviewEmptyListText());
        }

        //[Test, Order(1)]
        //public void ReviewsCount()
        //{
        //    ProductPage Iphone = LoadApplication()
        //        .GetProductPageByName("iPhone");
        //    Assert.AreEqual(11, Iphone.GetReviewsCountAll());
        //}
    }
}
