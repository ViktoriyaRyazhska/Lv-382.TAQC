using NUnit.Framework;
using OpenCart_Testing.Extentions;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.LoginData;
using System.Threading;

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

            Thread.Sleep(1000); //FOR PRESENTATION ONLY
            SuccessfullyUpdatedAddressPage updatedPage = page.DeleteFirstAddress();

            Thread.Sleep(1000); //FOR PRESENTATION ONLY
            Assert.AreEqual(updatedPage.GetNotDeletedAddressMessageText(), SuccessfullyUpdatedAddressPage.DELETINGDEFAULT);
        }
    }
}
