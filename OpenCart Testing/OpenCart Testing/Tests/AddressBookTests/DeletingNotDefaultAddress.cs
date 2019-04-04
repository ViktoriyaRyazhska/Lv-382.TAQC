using NUnit.Framework;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.LoginData;
using System.Threading;

namespace OpenCart_Testing.Tests
{
    class DeletingNotDefaultAddress : TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForAddressBookTests.json");

        [Test]
        public void CheckDeletingOfNotDefaultAddress()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(myUser).GotoAddressBookPage().SetFirstDefault();

            Thread.Sleep(1000); //FOR PRESENTATION ONLY
            SuccessfullyUpdatedAddressPage updatedPage = page.DeleteSecondAddress();

            Thread.Sleep(1000); //FOR PRESENTATION ONLY
            Assert.AreEqual(updatedPage.GetDeletedAddressMessageText(), SuccessfullyUpdatedAddressPage.DELETINGNOTDEFAULT);
        }
    }
}
