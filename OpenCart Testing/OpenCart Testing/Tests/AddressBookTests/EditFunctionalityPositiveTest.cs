using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using OpenCart_Testing.Pages;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.Pages.AddressBookPages;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    class EditFunctionalityPositiveTest: TestRunner
    {
        internal class CheckingAddressBookEditFunctionalityForTextboxes : IEnumerable<ITestCaseData>
        {

            public IEnumerator<ITestCaseData> GetEnumerator()
            {
                yield return new TestCaseData("Sasha").SetName("CheckAddressBookEditFunctionalityWithValidFirstname");
                //yield return new TestCaseData("Yarmoliuk", "Lastname").SetName("CheckAddressBookEditFunctionalityWithValidLastname");
                //yield return new TestCaseData("5th Avenue", "Address1").SetName("CheckAddressBookEditFunctionalityWithValidAddress1");
                //yield return new TestCaseData("New York", "City").SetName("CheckAddressBookEditFunctionalityWithValidCity");
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        [Test, TestCaseSource(typeof(CheckingAddressBookEditFunctionalityForTextboxes))]
        public void CheckAddressBookEditFunctionalityWithValidFirstname(string data)
        {
            HomePage page = LoadApplication();
            page.ClickMyAccount();
            AddressBookPage addressBookPage = new AddressBookPage(driver);
            addressBookPage.ClickAddressBook();
            addressBookPage.EditFirstAddress();
            EditAddressPage editAddressPage = new EditAddressPage(driver);
            editAddressPage.SetFirstname(data);
            editAddressPage.ClickContinue();
            addressBookPage = new AddressBookPage(driver);
            Assert.IsTrue(addressBookPage.getAddressComponentsContainer().GetFirstAddress()
                .GetAddressDescription().Contains(data));
        }
    }
}
