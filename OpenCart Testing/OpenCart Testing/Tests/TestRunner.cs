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
        public Application application;

        protected User REGISTERED = new User(Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL"), 
            Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD"));
     
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            application = Application.Get(ApplicationSourcesRepository.Default());
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
