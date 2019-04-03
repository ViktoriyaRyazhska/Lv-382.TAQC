using NUnit.Framework;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.LoginData;

namespace OpenCart_Testing.Tests
{
    class DeletingNotDefaultAddress: TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForAddressBookTests.json");

        [Test]
        public void CheckDeletingOfNotDefaultAddress()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(myUser).GotoAddressBookPage();
            
            SuccessfullyUpdatedAddressPage updatedPage = page.DeleteSecondAddress();

            Assert.AreEqual(updatedPage.GetDeletedAddressMessageText(), SuccessfullyUpdatedAddressPage.DELETINGNOTDEFAULT);
        }
    }
}
