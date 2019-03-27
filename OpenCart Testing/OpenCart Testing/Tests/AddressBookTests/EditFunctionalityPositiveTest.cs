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
        //[Test, TestCaseSource(typeof(CheckingAddressBookEditFunctionalityForTextboxes))]
        //private static readonly object[] ValidFirstname =
        //{
        //   "Sasha",
        //   "Oleksandra",
        //};

        //[Test, TestCaseSource("ValidFirstname")]
        [Test]
        public void CheckAddressBookEditFunctionalityWithValidFirstname()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage();

            page.EditFirstAddress().SetFirstname("Sasha");

            //AddressComponent address = page.GetAddressComponentsContainer().GetFirstAddress();
            //string str = address.GetAddressDescription();
            //Console.WriteLine(str);

            //Console.WriteLine(page.GetAddressComponentsContainer().GetFirstAddress()
            //    .GetAddressDescription());

            //Assert.IsTrue(page.getAddressComponentsContainer().GetFirstAddress()
            //    .GetAddressDescription().Contains("Sasha"));
        }
    }
}
