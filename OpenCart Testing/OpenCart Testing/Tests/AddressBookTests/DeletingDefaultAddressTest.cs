using NUnit.Framework;
using OpenCart_Testing.Extentions;
using OpenCart_Testing.Pages.AddressBookPages;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    class DeletingDefaultAddressTest: TestRunner
    {
        //[SetUp]
        //public void TestSetUp()
        //{
        //    application = Application.Get(ApplicationSourcesRepository.ApplicationSourceFromJson("Chrome.json"));
        //}

        [Test]
        public void CheckDeletingOfDefaultAddress()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage()
                .SetFirstDefault();

            SuccessfullyUpdatedAddressPage updatedPage = page.DeleteFirstAddress();
           
            Assert.AreEqual(updatedPage.GetNotDeletedAddressMessageText(), SuccessfullyUpdatedAddressPage.DELETINGDEFAULT);
        }
    }
}
