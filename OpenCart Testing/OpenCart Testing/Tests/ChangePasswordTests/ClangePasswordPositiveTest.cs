using NUnit.Framework;
using OpenCart_Testing.Pages.ChangePasswordPages;
using System.Threading;
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
            SuccessfulPassChangeAccountPage message = page.SuccessfulChangePassword();
            Assert.AreEqual(message.GetSuccessfulPassChangeMessage(), SuccessfulPassChangeAccountPage.PassChengedMessage);
            Thread.Sleep(3000);
        }
    }
}
