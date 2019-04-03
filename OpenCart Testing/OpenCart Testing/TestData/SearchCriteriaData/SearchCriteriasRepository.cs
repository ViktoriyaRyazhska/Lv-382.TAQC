using OpenCart_Testing.Tools;
using System.Collections.Generic;

namespace OpenCart_Testing.TestData
{
    public sealed class SearchCriteriasRepository
    {
        private volatile static SearchCriteriasRepository instance;
        private static object lockingObject = new object();
        private static string directory = "SearchCriteria";


        private SearchCriteriasRepository()
        {
        }

        public static SearchCriteriasRepository Get()
        {
            if (instance == null)  //
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new SearchCriteriasRepository();
                    }
                }
            }
            return instance;
        }

        public ISearchCriteria Mac()
        {
            return SearchCriteria.Get().SetKeyword("mac").ChoiceDescription(false).ChoiceCategory("All Categories").ChoiceSubcategory(true).Build();
        }
        
        public ISearchCriteria NewSearchCriteriaFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<SearchCriteria>(directory, fileName) as ISearchCriteria;
        }

        public static IList<SearchCriteria> NewSearchCriteriaArrayFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<IList<SearchCriteria>>(directory, fileName);
        }

    }
}
