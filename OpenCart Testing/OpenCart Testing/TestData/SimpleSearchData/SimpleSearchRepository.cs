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
        //private volatile static SimpleSearchRepository instance;
        //private static object lockingObject = new object();
        //private const string reviewEmptyListMessage = "There are no reviews for this product.";
        private static string directory = "SimpleSearch";
 
        public ISimpleSearch NewSearchDataFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<SimpleSearch>(directory, fileName) as ISimpleSearch;
        }
    }
}
