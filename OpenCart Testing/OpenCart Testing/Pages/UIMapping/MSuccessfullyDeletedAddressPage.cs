using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    public class MSuccessfullyDeletedAddressPage
    {
        public static By locatorDeletedAddressMessage => By.XPath("//div[@class='alert alert-success']");
    }
}
