using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace OpenCart_Testing.Extentions
{
    public sealed class ApplicationSourcesRepository
    {
        private static string baseUrl = "http://192.168.183.131/opencart/upload/";

        public static ApplicationSources GetFirefoxApplication()
        {
            return new ApplicationSources("FireFox", new FirefoxDriver(),
              baseUrl,
              5L);
        }

        public static ApplicationSources GetChromeApplication()
        {
            return new ApplicationSources("Chrome",
                new ChromeDriver(),
                baseUrl,
                5L);
        }
    }
}
