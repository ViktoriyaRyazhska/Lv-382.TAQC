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
using System.Threading;
using OpenCart_Testing.Pages.LoginPages;
using OpenCart_Testing.Pages.AccountPages;

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
