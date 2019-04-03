using NUnit.Framework;
using OpenCart_Testing.Extentions;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.LoginData;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    class DeletingDefaultAddressTest: TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForAddressBookTests.json");

        [OneTimeSetUp]
        public override void BeforeAllMethods()
        {             
            application = Application.Get(ApplicationSourcesRepository.ApplicationSourceFromJson("Firefox.json"));
        }

        [Test]
        public void CheckDeletingOfDefaultAddress()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(myUser).GotoAddressBookPage()
                .SetFirstDefault();

            SuccessfullyUpdatedAddressPage updatedPage = page.DeleteFirstAddress();
           
            Assert.AreEqual(updatedPage.GetNotDeletedAddressMessageText(), SuccessfullyUpdatedAddressPage.DELETINGDEFAULT);
        }
    }
}
