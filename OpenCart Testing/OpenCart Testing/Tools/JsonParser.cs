using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tools
{
    class JsonParser : AExternalReader
    {
        public static T DeserializeFromFile<T>(string repository,string fileName)
        {
            try
            {
                string json = File.ReadAllText(GetPath(repository,fileName));
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                throw new Exception($"Cant Deserialize from file: {GetPath(repository, fileName)}");
            }

        }
    }
}
