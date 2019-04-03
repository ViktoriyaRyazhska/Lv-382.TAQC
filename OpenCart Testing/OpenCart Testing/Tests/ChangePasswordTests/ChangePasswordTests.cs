using NUnit.Framework;
using OpenCart_Testing.Pages.ChangePasswordPages;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.TestData;
using OpenCart_Testing.TestData.LoginData;
using OpenCart_Testing.TestData.ChangePassData;
using System.Threading;


namespace OpenCart_Testing.Tests.ChangePasswordTests
{
    [TestFixture]
    class ChangePasswordTests : TestRunner
    {

        public static object[] PositiveTestUserLoginData =
        {
           new TestCaseData(LoginDataRespository.Get().GetUserLoginData("UserDataForPasswordChange.json"), LoginDataRespository.Get().GetChangePasswordData("TestPasswordsForChanging_CorrectConfirmation.json") )
        };

        [Test]
        [TestCaseSource("PositiveTestUserLoginData")]
        public void ChangePasswordPositiveTest(User userData, ChangePasswordData passData)
        {
            ///Going to change password page
            ChangePasswordPage page = 
                LoadApplication()
                .ClickLoginUserButton()
                .LoginUser(userData)
                .GotoChangePasswordPage();
            ///Changing password and checking the message
            Assert.AreEqual(page.SuccessfulChangePassword(passData.NewPassword, passData.ConfirmedPassword).GetSuccessfulPassChangeMessage(), 
                            SuccessfulPassChangeAccountPage.PassChengedMessage);
            ///Check for no password reset
            page.ClickLogout();
            page.ClickLoginUserButton().LoginUser(new User(userData.Email, passData.NewPassword));
            Assert.AreEqual(page.GetEditAccountText(), "Edit Account"); // Куди це втикнути?

            //Thread.Sleep(3000);
        }


        public static object[] NegativeTestUserLoginData =
        {
           new TestCaseData(LoginDataRespository.Get().GetUserLoginData("UserDataForPasswordChange.json"),LoginDataRespository.Get().GetChangePasswordData("TestPasswordsForChanging_WrongConfirmation.json"))
        };

        [Test]
        [TestCaseSource("NegativeTestUserLoginData")]
        public void ChangePasswordNegativeTest(User userData, ChangePasswordData passData)
        {
            ///Going to change password page
            ChangePasswordPage page =
                LoadApplication()
                .ClickLoginUserButton()
                .LoginUser(userData)
                .GotoChangePasswordPage();
            ///Changing password with wrong confirmation and checking the message
            Assert.AreEqual(page.UnsuccessfulChangePassword(passData.NewPassword, passData.ConfirmedPassword).GetUnsuccessfulPassChangeMessage(), 
                            UnsuccessfulPasswordChangePage.PassChengedMessage);
            ///Check for no password reset
            page.ClickLogout();
            page.ClickLoginUserButton().LoginUser(userData);
            Assert.AreEqual(page.GetEditAccountText(), "Edit Account"); // Куди це втикнути?
            //Thread.Sleep(3000);
        }
    }
}
