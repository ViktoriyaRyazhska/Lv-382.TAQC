using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;

namespace OpenCart_Testing.Tests
{
    class DeletingNotDefaultAddress: TestRunner
    {
        [Test]
        public void CheckDeletingOfNotDefaultAddress()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage();
            
            SuccessfullyUpdatedAddressPage updatedPage = page.DeleteSecondAddress();

            Assert.AreEqual(updatedPage.GetDeletedAddressMessageText(), SuccessfullyUpdatedAddressPage.DELETINGNOTDEFAULT);
        }
    }
}
