using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Extentions
{
    public sealed class ApplicationSourcesRepository
    {
        private static string directory = "ApplicationSources";
        public static ApplicationSources Default()
        {
            return new ApplicationSources("Chrome",
                "http://192.168.79.130/opencart/upload/",
=======
                "http://192.168.85.129/opencart/upload/",
>>>>>>> c68658a2372c7628c26ee623759fcc8ea396c84c
                5L);
        }

        public static ApplicationSources ApplicationSourceFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<ApplicationSources>(directory, fileName) as ApplicationSources;
        }
    }
}
