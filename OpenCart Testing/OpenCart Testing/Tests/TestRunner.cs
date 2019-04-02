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

=======
<<<<<<< HEAD

=======
<<<<<<< HEAD
//<<<<<<< HEAD
>>>>>>> aefe4e38b610897a70632dc0ae5acc9417dca282
>>>>>>> fe4e4dfa3c40fe53acd6c9d31e3544f0983cf804
        protected IWebDriver driver;
        //protected const int spanTime = 2;
        //protected const int sleepTime = 2000;

        //protected string baseUrl = "http://192.168.150.138/opencart/upload/";

<<<<<<< HEAD
//       //protected string baseUrl = "http://taqc-opencart.epizy.com/";
=======
<<<<<<< HEAD
        //protected string baseUrl = "http://192.168.79.130/opencart/upload/";

        //protected string baseUrl = "http://taqc-opencart.epizy.com/";

=======
//        protected string baseUrl = "http://192.168.79.130/opencart/upload/";
>>>>>>> fe4e4dfa3c40fe53acd6c9d31e3544f0983cf804

        public Application application;

        protected User REGISTERED = new User(Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL"), 
            Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD"));
<<<<<<< HEAD
=======
=======
        protected IWebDriver driver;
>>>>>>> aefe4e38b610897a70632dc0ae5acc9417dca282
        public Application application;
>>>>>>> fe4e4dfa3c40fe53acd6c9d31e3544f0983cf804

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //application = Application.Get(ApplicationSourcesRepository.GetFirefoxApplication());
            application = Application.Get(ApplicationSourcesRepository.GetChromeApplication());
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            application.Quit();
        }

        [SetUp]
        public void BeforeAllTests()
        {
            application.Load();
        }

        [TearDown]
        public void AfterAllTests()
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
