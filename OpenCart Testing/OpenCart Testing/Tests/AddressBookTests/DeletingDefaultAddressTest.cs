
using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests.AddressBookTests
{
    class DeletingDefaultAddressTest: TestRunner
    {
        [Test]
        public void CheckDeletingOfDefaultAddress()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage()
                .SetFirstDefault();

            SuccessfullyDeletedAddressPage deletedPage = page.DeleteSecondAddress();

            //Console.WriteLine(deletedPage.GetAddressComponentsContainer().Count());

            //Assert.AreEqual(deletedPage.GetDeletedAddressMessageText(), SuccessfullyDeletedAddressPage.EXPECTEDMESSAGE);
        }

    }
}
