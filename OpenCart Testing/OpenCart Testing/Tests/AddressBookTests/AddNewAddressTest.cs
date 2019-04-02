using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.AddressBookData;
using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    public class AddNewAddressTest : TestRunner
    {
        private SuccessfullyUpdatedAddressPage updatedPage;

        private static readonly object[] ValidAddressData =
            ListUtils.ToMultiArray(AddressRepository.NewAddressArrayFromJson("ValidAddress.json"));

        [Test, TestCaseSource(nameof(ValidAddressData))]
        public void CheckAddingValidAddress(Address address)
        {
            AddressBookPage page = LoadApplication()
               .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage();

            updatedPage = page.AddNewAddress().FillAddressAndContinue(address);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(page.GetAddressComponentsContainer().GetCount(), updatedPage.GetAddressComponentsContainer().GetCount() - 1);
                Assert.AreEqual(updatedPage.GetNewAddressAddedMessageText(), SuccessfullyUpdatedAddressPage.NEWADDRESSADDED);
                Assert.That(updatedPage.GetAddressComponentsContainer().GetLastAddress().GetAddressDescription().Contains(address.Firstname));
            });
        }

        [OneTimeTearDown]
        private void AfterEachTest()
        {
            updatedPage.DeleteLastAddress();
        }
    }
}