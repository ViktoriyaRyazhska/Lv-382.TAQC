using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.StaticParts
{
    public abstract class ARightLogoutPart: ARightMenuPart
    {
        public ARightLogoutPart(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Login
        { get { return driver.FindElement(MARightLogoutPart.locatorLogin); } }
        public IWebElement Register
        { get { return driver.FindElement(MARightLogoutPart.locatorRegister); } }
        public IWebElement ForgottenPassword
        { get { return driver.FindElement(MARightLogoutPart.locatorForgottenPassword); } }

        public string GetLoginText()
        {
            return Login.Text;
        }

        public void ClickLogin()
        {
            Login.Click();
        }

        public string GetRegisterText()
        {
            return Register.Text;
        }

        public void ClickRegister()
        {
            Register.Click();
        }

        public string GetForgottenPasswordText()
        {
            return ForgottenPassword.Text;
        }

        public void ClickForgottenPassword()
        {
            ForgottenPassword.Click();
        }
    }
}
