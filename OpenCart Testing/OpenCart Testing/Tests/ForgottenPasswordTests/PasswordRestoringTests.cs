using NUnit.Framework;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Pages.ForgottenPasswordPages;
using OpenCart_Testing.Pages.UkrnetPage;
using OpenCart_Testing.TestData.ChangePassData;
using OpenCart_Testing.TestData.LoginData;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace OpenCart_Testing.Tests.ForgottenPasswordTests
{
    [TestFixture]
    class PasswordRestoringTests : TestRunner
    {
        public static object[] PasswordRestoringData =
        {
           new TestCaseData(LoginDataRespository.Get().GetUserLoginData("UserData_PasswordChangingPositiveTest.json"), LoginDataRespository.Get().GetChangePasswordData("TestPasswordsForChanging_CorrectConfirmation.json") )
        };

        [Test]
        [TestCaseSource("PasswordRestoringData")]
        public void PasswordRestoringPositiveTest(User restoreUser, ChangePasswordData passData)
        {
            ForgottenPasswordPage page = LoadApplication().ClickLoginUserButton().GotoForgottenPasswordPage();
            page.SendRecoveryLetter(restoreUser.Email);
            page.GotoUkrnetMail()
                .LoginUkrnetUser(restoreUser.Email, restoreUser.Password)
                .ClickUnread()
                .GotoNewRecoveryLetter()
                .ClickRestoreLink().RestorePassword(passData.NewPassword, passData.ConfirmedPassword).ClickLoginUserButton();
            Thread.Sleep(3000);

        }

    }
}
