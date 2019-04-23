using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTestProject
{
    [TestFixture]
    public class SmokeTest //: TestRunner
    {
        // DataProvider

        //[Test]
        public void CheckSearch()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.FindElement(By.Name("search")).Click();
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys("mac");
            //
            driver.FindElement(By.CssSelector("button.btn.btn-default.btn-lg")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            //driver.FindElement(By.Name("search1"));
        }

        //[Test] // Simple
        public void Firefox1()
        {
            IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(4000);
            driver.Quit();
        }

        //[Test] // Use Profile
        public void Firefox2()
        {
            FirefoxProfileManager profileManager = new FirefoxProfileManager();
            FirefoxProfile profile = profileManager.GetProfile("default");
            //IWebDriver driver = new FirefoxDriver(profile); // Deprecated
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //driver.Navigate().GoToUrl("https://192.168.195.249/Index#/Home");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(5000);
            driver.Quit();
        }

        //[Test]
        public void Firefox3()
        {
            FirefoxProfile profile = new FirefoxProfile();
            // TODO not working
            //profile.AcceptUntrustedCertificates = false;
            profile.AcceptUntrustedCertificates = true;
            profile.AssumeUntrustedCertificateIssuer = true;
            //
            //profile.SetPreference("app.update.enabled", false);
            //profile.SetPreference("app.update.auto", false);
            //
            FirefoxOptions options = new FirefoxOptions();
            //options.Profile = profile;
            options.AddAdditionalCapability("acceptInsecureCerts", true, true);
            IWebDriver driver = new FirefoxDriver(options);
            //IWebDriver driver = new FirefoxDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://192.168.195.249/Index#/Home");
            //driver.Navigate().GoToUrl("https://taqc-opencart.epizy.com/");
            //
            //driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(4000);
            driver.Quit();
        }

        //[Test] // Use Profile + UntrustedCertificates
        public void Firefox32()
        {
            FirefoxProfileManager profileManager = new FirefoxProfileManager();
            FirefoxProfile profile = profileManager.GetProfile("default");
            //IWebDriver driver = new FirefoxDriver(profile); // Deprecated
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://taqc-opencart.epizy.com/");
            //
            Thread.Sleep(4000);
            driver.Quit();
        }

        //[Test]
        public void Firefox4()
        {
            FirefoxProfile profile = new FirefoxProfile();
            //profile.AddExtension("D:\\selenium_ide-3.4.5-fx.xpi");
            profile.AddExtension("D:\\xpath_finder-0.9.7-fx.xpi");
            //profile.SetPreference("extensions.firebug.currentVersion", "2.0.19");
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(4000);
            //
            //driver.Quit();
        }

        //[Test]
        public void Firefox5()
        {
            FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = "calc.exe";
            // Start application with a debugging console. Windows only.
            options.AddArgument("-console");
            // Runs Firefox in headless mode. Available in Firefox 56+
            options.AddArgument("-headless");
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Thread.Sleep(1000);
            //
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/ScreenshotGoogle01.png", ScreenshotImageFormat.Png);
            //
            driver.Quit();
        }

        //[Test]
        public void Firefox6()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
            //options.BrowserExecutableLocation = "calc.exe";
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            //
            driver.Quit();
        }

        //[Test]
        public void Phantom1()
        {
            //PhantomJSDriver driver = new PhantomJSDriver();
            IWebDriver driver = new FirefoxDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Thread.Sleep(1000);
            //
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/ScreenshotGoogle02.png", ScreenshotImageFormat.Png);
            //
            driver.Quit();
        }

        //[Test]
        public void IE1()
        {
            IWebDriver driver = new InternetExplorerDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Thread.Sleep(4000);
            driver.Quit();
        }

        //[Test]
        public void IE2()
        {
            InternetExplorerOptions options = new InternetExplorerOptions()
            {
                //InitialBrowserUrl = baseURL,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnableNativeEvents = false
            };
            IWebDriver driver = new InternetExplorerDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test] // Simple, Temporary Profile
        public void Chrome1()
        {
            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome2()
        {   // Default Profile
            ChromeOptions options = new ChromeOptions();
            string homePath = Environment.GetEnvironmentVariable("HOMEPATH");
            Console.WriteLine("homePath = " + homePath);
            string userProfile = homePath + "\\AppData\\Local\\Google\\Chrome\\User Data";
            //string userProfile = homePath + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default"; // ERROR for Win
            Console.WriteLine("userProfile = " + userProfile);
            options.AddArguments("--user-data-dir=" + userProfile);
            IWebDriver driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(2000);
            //driver.Quit();
        }

        //[Test]
        public void Chrome3()
        {   // Add Arguments
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            //options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            //options.AddArguments("--headless");
            IWebDriver driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Thread.Sleep(2000);
            driver.Quit();
        }

        //[Test]
        public void Chrome4()
        {   // Executable Location
            ChromeOptions options = new ChromeOptions();
            //options.BinaryLocation = @"C:\Users\yharasym\Downloads\VideoTAQC\ChromiumPortable\ChromiumPortable.exe";
            //options.BinaryLocation = "calc.exe";
            //options.BinaryLocation = @"C:\Windows\notepad.exe";
            options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            IWebDriver driver = new ChromeDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(2000);
            driver.Quit();
        }

        [Test]
        public void Chrome5()
        {   // Headless
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            IWebDriver driver = new ChromeDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            Console.WriteLine("Title0= " + driver.Title);
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Thread.Sleep(1000);
            Console.WriteLine("Title1= " + driver.Title);
            //driver.FindElement(By.Name("q")).SendKeys("Cheese");
            //driver.FindElement(By.Name("q")).Submit();
            //Thread.Sleep(2000);
            //
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/ScreenshotGoogle12.png", ScreenshotImageFormat.Png);
            //
            Console.WriteLine("Title2= " + driver.Title);
            driver.Quit();
        }
    }
}
