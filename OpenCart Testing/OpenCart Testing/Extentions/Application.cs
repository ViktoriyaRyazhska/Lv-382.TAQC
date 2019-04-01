using OpenCart_Testing.Extentions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace OpenCart_Testing
{
    public class Application
    {
        public IWebDriver Driver { get; private set; }
        public ApplicationSources applicationSources;

        private Application(ApplicationSources applicationSources)
        {
            this.applicationSources = applicationSources;
        }

        public static Application Get(ApplicationSources applicationSources)
        {
            Application instance = new Application(applicationSources);
            instance.Driver = instance.GetWebDriver();
            instance.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(applicationSources.ImplicitTimeOut);
            return instance;
        }

        public void Load()
        {
            Driver.Navigate().GoToUrl(applicationSources.BaseUrl);
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public void DeleteCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        private IWebDriver GetWebDriver()
        {
            if (applicationSources.BrowserName.ToLower().Equals("firefox"))
            {
                return GetFirefoxDriver();
            }
            else if (applicationSources.BrowserName.ToLower().Equals("chrome"))
            {
                return GetChromeDriver();
            }
            return GetChromeDriver();
        }

        private IWebDriver GetFirefoxDriver()
        {
            Driver = new FirefoxDriver();
            return Driver;
        }

        private IWebDriver GetChromeDriver()
        {
            Driver = new ChromeDriver();
            return Driver;
        }

        public static int SleepTimeClickMiliSeconds = 100;
        public static void WaitBeforeClick() =>
            Thread.Sleep(SleepTimeClickMiliSeconds);
    }
}
