using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;
using OpenCart_Testing.TestData.AddressBookData;
using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    class EditFunctionalityPositiveTest : TestRunner
    {
        private AddressBookPage page;

        private static readonly object[] ValidFirstnameData =
            ListUtils.ToMultiArray(AddressRepository.AddressFirstnameFromJson("ValidFirstname.json"));

        [Test, TestCaseSource(nameof(ValidFirstnameData))]
        public void CheckAddressBookEditFunctionalityWithValidFirstname(string data)
        {
            page = LoadApplication()
               .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage()
               .EditFirstAddress().SetOnlyFirstname(data);

            Assert.IsTrue(page.GetAddressComponentsContainer().GetFirstAddress()
                .GetAddressDescription().Contains(data));
        }

        [TearDown]
        public void TestTearDown()
        {
            if (page != null)
            {
                page.LogoutUser();
            }
        }
    }
}
