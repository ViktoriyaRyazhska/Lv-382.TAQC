using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Extentions
{
    public sealed class ApplicationSourcesRepository
    {
        private static string directory = "ApplicationSources";
        public static ApplicationSources Default()
        {
            return new ApplicationSources("Chrome",
                "http://192.168.183.131/opencart/upload/",
                10L);
        }

        public static ApplicationSources ApplicationSourceFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<ApplicationSources>(directory, fileName) as ApplicationSources;
        }
    }
}
