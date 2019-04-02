using OpenCart_Testing.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData.SimpleSearchData
{
    class SimpleSearchRepository
    {
        private static string directory = "SimpleSearch";
 
        public static SimpleSearch NewSearchDataFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<SimpleSearch>(directory, fileName);
        }

        public static IList<SimpleSearchView> NewDataListFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<IList<SimpleSearchView>>(directory, fileName);
        }
    }
}
