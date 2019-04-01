using OpenCart_Testing.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData
{
    public sealed class SearchCriteriasRepository
    {
        private volatile static SearchCriteriasRepository instance;
        private static object lockingObject = new object();
        private const string searchCriteriaEmptyListMessage = "There is no product that matches the search criteria.";
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

        public ISearchCriteria Qwerty()
        {
            return SearchCriteria.Get().SetKeyword("qwerty").ChoiceDescription(true).ChoiceCategory("Desktops").ChoiceSubcategory(true).Build();
        }

        public string GetSearchCriteriaEmptyListMessage()
        {
            return searchCriteriaEmptyListMessage;
        }


        public ISearchCriteria NewSearchCriteriaFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<SearchCriteria>(directory, fileName) as ISearchCriteria;
        }



        //public IList<IReview> ListReviewsFromJson()
        //{

        //}

        //public IList<IUser> FromCsv(string filename)
        //{
        //    return User.GetAllUsers(new CSVReader(filename).GetAllCells());
        //}

        //public IList<IUser> FromExcel()
        //{
        //    return FromExcel("users.xlsx");
        //}

        //public IList<IUser> FromExcel(string filename)
        //{
        //    return User.GetAllUsers(new ExcelReader(filename).GetAllCells());
        //}
    }
}
