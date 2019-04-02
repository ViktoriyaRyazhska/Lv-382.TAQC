using NUnit.Framework;
using OpenCart_Testing.Pages.ChangePasswordPages;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.TestData.LoginData;
using OpenCart_Testing.TestData.ChangePassData;
using OpenCart_Testing.TestData;
using System.Threading;


namespace OpenCart_Testing.Tests.ChangePasswordTests
{
    [TestFixture]
    class ChangePasswordTests : TestRunner
    {
        public static object[] PositiveTestUserLoginData =
        {
           new TestCaseData(LoginDataRespository.Get().GetUserLoginData("UserData_PasswordChangingPositiveTest.json"))
        };

        [Test]
        [TestCaseSource("PositiveTestUserLoginData")]
        public void ChangePasswordPositiveTest(User userData)
        {
            ChangePasswordPage page = 
                LoadApplication()
                .ClickLoginUserButton()
                .LoginUser(userData)
                .GotoChangePasswordPage();
            SuccessfulPassChangeAccountPage message = page.SuccessfulChangePassword();
            Assert.AreEqual(message.GetSuccessfulPassChangeMessage(), SuccessfulPassChangeAccountPage.PassChengedMessage);
            Thread.Sleep(3000);
        }

        //public static object[] NegativeTestUserLoginData =
        //{
        //   new TestCaseData(LoginDataRespository.Get().GetUserLoginData("UserData_PasswordChangingPositiveTest.json"))
        //};

        //public void ChangePasswordNegativeTest(User userData)
        //{
        //    ChangePasswordPage page =
        //        LoadApplication()
        //        .ClickLoginUserButton()
        //        .LoginUser(userData)
        //        .GotoChangePasswordPage();
        //    UnsuccessfulPasswordChangePage message = page.UnsuccessfulChangePassword();
        //    Assert.AreEqual(message.GetSuccessfulPassChangeMessage(), SuccessfulPassChangeAccountPage.PassChengedMessage);
        //    Thread.Sleep(3000);
        //}

    }
}
