using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.AddressBookData;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    public class AddNewAddressTest : TestRunner
    {
        private static readonly object[] ValidAddressData =
        {
            AddressRepository.NewAddressArrayFromJson("ValidAddress.json")[0],
            AddressRepository.NewAddressArrayFromJson("ValidAddress.json")[1],   
        };

        [Test, TestCaseSource("ValidAddressData")]
        public void CheckAddingValidAddress(Address address)
        {
            AddressBookPage page = LoadApplication()
               .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage();
            SuccessfullyUpdatedAddressPage updatedPage = page.AddNewAddress().FillAddressAndContinue(address);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(page.GetAddressComponentsContainer().GetCount(), updatedPage.GetAddressComponentsContainer().GetCount() - 1);
                Assert.AreEqual(updatedPage.GetNewAddressAddedMessageText(), SuccessfullyUpdatedAddressPage.NEWADDRESSADDED);
                Assert.That(updatedPage.GetAddressComponentsContainer().GetLastAddress().GetAddressDescription().Contains(address.Firstname));
            });

            updatedPage.DeleteLastAddress();
        }
    }
}
