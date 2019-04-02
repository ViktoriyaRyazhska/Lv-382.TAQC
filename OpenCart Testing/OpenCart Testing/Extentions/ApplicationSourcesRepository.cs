using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace OpenCart_Testing.Extentions
{
    public sealed class ApplicationSourcesRepository
    {
<<<<<<< HEAD
        private static string baseUrl = "http://192.168.79.130/opencart/upload/";
        
=======
        private static string baseUrl = "http://192.168.19.133/opencart/upload/";
>>>>>>> aefe4e38b610897a70632dc0ae5acc9417dca282
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
