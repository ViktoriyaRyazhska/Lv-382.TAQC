using OpenCart_Testing.Tools;
using System.Collections.Generic;

namespace OpenCart_Testing.TestData.SimpleSearchData
{
    class SimpleSearchRepository
    {
        private static string directory = "SimpleSearch";
 
        public static SimpleSearch NewSearchDataFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<SimpleSearch>(directory, fileName);
        }

        public static IList<SimpleSearch> NewDataListFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<IList<SimpleSearch>>(directory, fileName);
        }
    }
}
