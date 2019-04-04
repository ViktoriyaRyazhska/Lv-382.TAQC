using NUnit.Framework;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.AddressBookData;
using OpenCart_Testing.TestData.LoginData;
using OpenCart_Testing.Tools;
using System.Threading;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    public class AddNewAddressTest : TestRunner
    {
        private User myUser = LoginDataRespository.Get().GetUserLoginData("UserForAddressBookTests.json");
        private SuccessfullyUpdatedAddressPage updatedPage;

        private static readonly object[] ValidAddressData =
            ListUtils.ToMultiArray(AddressRepository.NewAddressArrayFromJson("ValidAddress.json"));

        [Test, TestCaseSource(nameof(ValidAddressData))]
        public void CheckAddingValidAddress(Address address)
        {
            AddressBookPage page = LoadApplication()
               .ClickLoginUserButton().LoginUser(myUser).GotoAddressBookPage();

            Thread.Sleep(1000); //FOR PRESENTATION ONLY
            updatedPage = page.AddNewAddress().FillAddressAndContinue(address);

            Thread.Sleep(1000); //FOR PRESENTATION ONLY
            Assert.Multiple(() =>
            {
                Assert.AreEqual(page.GetAddressComponentsContainer().GetCount(), updatedPage.GetAddressComponentsContainer().GetCount()-1);
                Assert.AreEqual(updatedPage.GetNewAddressAddedMessageText(), SuccessfullyUpdatedAddressPage.NEWADDRESSADDED);
                Assert.That(updatedPage.GetAddressComponentsContainer().GetLastAddress().GetAddressDescription().Contains(address.Firstname));
            });
        }

        [TearDown]
        public void TestTearDown()
        {
            if (updatedPage != null)
            {
                updatedPage.DeleteLastAddress();
            }
        }
    }
}