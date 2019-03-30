using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    class DeletingDefaultAddressTest: TestRunner
    {
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
