using OpenQA.Selenium;

namespace OpenCart_Testing.Extentions
{
    public class ApplicationSources
    {
        public string BrowserName { get; set; }
        public IWebDriver Driver { get; set; }
        public long ImplicitTimeOut { get; set; }
        public string BaseUrl { get; set; }

        public ApplicationSources(string browserName, IWebDriver driver,
            string baseUrl, long implicitTimeOut)
        {
            BrowserName = browserName;
            Driver = driver;
            BaseUrl = baseUrl;
            ImplicitTimeOut = implicitTimeOut;
        }
    }
}
