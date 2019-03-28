using NUnit.Framework;
using OpenCart_Testing.Pages.ChangePasswordPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests.ChangePasswordTests
{
    class ChangePasswordTests : TestRunner
    {
        [Test]
        public void ChangePasswordPositiveTest()
        {
            ChangePasswordPage page = 
                LoadApplication()
                .ClickLoginUserButton()
                .LoginUser(REGISTERED)
                .GotoChangePasswordPage();

            page.ChangePassword();

        }
    }
}
