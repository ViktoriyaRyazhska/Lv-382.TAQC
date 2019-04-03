namespace OpenCart_Testing.Extentions
{
    public class ApplicationSources
    {
        public string BrowserName { get; set; }
        public string BaseUrl { get; set; }
        public long ImplicitTimeOut { get; set; }

        public ApplicationSources(string browserName, string baseUrl, long implicitTimeOut)
        {
            BrowserName = browserName;
            BaseUrl = baseUrl;
            ImplicitTimeOut = implicitTimeOut;
        }
    }
}
