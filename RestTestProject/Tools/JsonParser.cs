using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.IO;

namespace RestTestProject.Tools
{
    public class JsonParser : AExternalReader
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

        public static T ConvertToResource<T>(IRestResponse response)
        {
            T result = default(T);
            try
            {
                result = new JsonDeserializer().Deserialize<T>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(CONVERT_OBJECT_ERROR, ex.Message, ex.StackTrace));
            }
            return result;
        }
    }
}
