using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Extentions
{
    public sealed class ApplicationSourcesRepository
    {
<<<<<<< HEAD
        private static string baseUrl = "http://192.168.85.129/opencart/upload/";
        public static ApplicationSources GetFirefoxApplication()
        {
            return new ApplicationSources("FireFox", 
              baseUrl,
              5L);
        }
=======
        private static string directory = "ApplicationSources";
>>>>>>> 4a7b0699615f6bb2e935558e8471f4e89f4d7f12

        public static ApplicationSources Default()
        {
            return new ApplicationSources("Chrome",
                "http://192.168.85.129/opencart/upload/",
                5L);
        }

        public static ApplicationSources ApplicationSourceFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<ApplicationSources>(directory, fileName) as ApplicationSources;
        }
    }
}
