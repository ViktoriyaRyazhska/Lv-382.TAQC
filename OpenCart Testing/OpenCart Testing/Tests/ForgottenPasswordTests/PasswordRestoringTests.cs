using NUnit.Framework;
using OpenCart_Testing.Pages.ForgottenPasswordPages;
using OpenCart_Testing.Pages.UkrnetPage;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace OpenCart_Testing.Tests.ForgottenPasswordTests
{
    [TestFixture]
    class PasswordRestoringTests : TestRunner
    {
        [Test]
        public void PasswordRestoringPositiveTest()
        {
            ForgottenPasswordPage page = LoadApplication().ClickLoginUserButton().GotoForgottenPasswordPage();
            page.SendRecoveryLetter("mokhnii_official@ukr.net");
            page.GotoUkrnetMail()
                .LoginUkrnetUser("mokhnii_official", "X7p8cXKNTgH3Wem")
                .ClickUnread()
                .GotoNewRecoveryLetter()
                .ClickRestoreLink().RestorePassword("X7p8cXKNTgH3Wem", "X7p8cXKNTgH3Wem");
            Thread.Sleep(2000);
        }

    }
}
