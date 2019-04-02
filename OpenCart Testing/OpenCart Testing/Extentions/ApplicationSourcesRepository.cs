using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace OpenCart_Testing.Extentions
{
    public sealed class ApplicationSourcesRepository
    {
        private static string baseUrl = "http://192.168.19.133/opencart/upload/";
        public static ApplicationSources GetFirefoxApplication()
        {
            return new ApplicationSources("FireFox", 
              baseUrl,
              5L);
        }

        public static ApplicationSources GetChromeApplication()
        {
            return new ApplicationSources("Chrome",
                baseUrl,
                5L);
        }
    }
}
