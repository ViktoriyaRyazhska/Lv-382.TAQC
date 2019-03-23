using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    public static class MARightMenuPart
    {

        public static By locatorMyAccount => By.XPath("//div[@class='list-group']/a[contains(@href, 'account/account')]");
    }
}
