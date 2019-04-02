﻿using System;
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
//<<<<<<< HEAD
>>>>>>> aefe4e38b610897a70632dc0ae5acc9417dca282
        protected IWebDriver driver;
        //protected const int spanTime = 2;
        //protected const int sleepTime = 2000;


<<<<<<< HEAD
        //protected string baseUrl = "http://192.168.79.130/opencart/upload/";

        //protected string baseUrl = "http://taqc-opencart.epizy.com/";

=======
//        protected string baseUrl = "http://192.168.79.130/opencart/upload/";

//        //protected string baseUrl = "http://taqc-opencart.epizy.com/";
//=======
        public Application application;
//>>>>>>> 77e6f13dfa426c14d6b3c0063604263cef9e0956
        protected User REGISTERED = new User(Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL"), 
            Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD"));
=======
        protected IWebDriver driver;
>>>>>>> aefe4e38b610897a70632dc0ae5acc9417dca282
        public Application application;

        protected User REGISTERED = new User(Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL"), Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD"));
>>>>>>> 2cf541f963f656a263f22d6ec43afb110bf8d2be
        
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
