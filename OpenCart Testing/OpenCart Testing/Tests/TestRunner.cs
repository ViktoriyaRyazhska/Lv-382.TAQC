using System;
using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.AccountPages;
using OpenCart_Testing.Extentions;
using OpenQA.Selenium;

namespace OpenCart_Testing
{
    [TestFixture]
    public class TestRunner
    {
<<<<<<< HEAD
        protected IWebDriver driver;
        //protected const int spanTime = 2;
        //protected const int sleepTime = 2000;
=======

        protected IWebDriver driver;
>>>>>>> 4a7b0699615f6bb2e935558e8471f4e89f4d7f12

        public Application application;

        protected User REGISTERED = new User(Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL"), 
            Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD"));

        [OneTimeSetUp]
        public virtual void BeforeAllMethods()
        {
            application = Application.Get(ApplicationSourcesRepository.Default());
        }

        [OneTimeTearDown]
        public virtual void AfterAllMethods()
        {
            application.Quit();
        }

        [SetUp]
        public void BeforeAllTests()
        {
            application.Load();
        }

        [TearDown]
        public virtual void AfterAllTests()
        {
            application.DeleteCookies();
        }

        public HomePage LoadApplication()
        {
            application.Load();
            return new HomePage(application.Driver);
        }
    }
}
