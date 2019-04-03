using Newtonsoft.Json;
using System;
using System.IO;

namespace OpenCart_Testing.Tools
{
    class JsonParser : AExternalReader
    {
        public static T DeserializeFromFile<T>(string repository, string fileName)
        {
            try
            {
                string json = File.ReadAllText(GetPath(repository, fileName));
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                throw new Exception($"Cant Deserialize from file: {GetPath(repository, fileName)}");
            }
        }
    }
}
