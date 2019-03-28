using NUnit.Framework;
using OpenCart_Testing.Pages.AddressBookPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests
{
    class DeletingNotDefaultAddress: TestRunner
    {
        [Test]
        public void CheckDeletingOfNotDefaultAddress()
        {
            AddressBookPage page = LoadApplication()
                .ClickLoginUserButton().LoginUser(REGISTERED).GotoAddressBookPage()
                .SetFirstDefault();
            Console.WriteLine(page.GetAddressComponentsContainer().GetCount());
            page.GetAddressComponentsContainer().Print();
            
            //page.GetAddressComponentsContainer().DeleteByName("Vasil");

            //SuccessfullyDeletedAddressPage deletedPage = page.DeleteSecondAddress();

            //Assert.AreEqual(deletedPage.GetDeletedAddressMessageText(), SuccessfullyDeletedAddressPage.DELETINGNOTDEFAULT);
        }
    }
}
