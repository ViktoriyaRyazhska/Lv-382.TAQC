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
    class JsonParser
    {
        public static T DeserializeFromFile<T>(string filePath)
        {
            filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, filePath);
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
