using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    class EditFunctionalityPositiveTest : TestRunner
    {
        private static readonly object[] ValidFirstname =
        {
           "Sasha",
           "Oleksandra",
        };

        [Test, TestCaseSource("ValidFirstname")]
        public void CheckAddressBookEditFunctionalityWithValidFirstname(string data)
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage()
                .EditFirstAddress().SetOnlyFirstname(data);

            Assert.IsTrue(page.GetAddressComponentsContainer().GetFirstAddress()
                .GetAddressDescription().Contains(data));

            page.LogoutUser();
        }
    }
}
