
namespace OpenCart_Testing.TestData
{
    public interface IKeyword
    {
        IDescription SetKeyword(string keyword);
    }

    public interface IDescription
    {
        ICategory ChoiceDescription(bool description);
    }

    public interface ICategory
    {
        ISubcategory ChoiceCategory(string category);
    }

    public interface ISubcategory
    {
        ISearchBuild ChoiceSubcategory(bool subcategory);
    }

    public interface ISearchBuild
    {
        ISearchCriteria Build();
    }

    public enum SearchCriteriaField : int
    {
        Keyword = 0,
        Description,
        Category,
        Subcategory
    }

    public class SearchCriteria : IKeyword, IDescription, ICategory, ISubcategory, ISearchBuild, ISearchCriteria
    {
        public string Keyword { get; set; }
        public bool Description { get; set; }
        public string Category { get; set; }
        public bool Subcategory { get; set; }


        private SearchCriteria()
        {

        }

        public static IKeyword Get()
        {
            return new SearchCriteria();
        }


        public IDescription SetKeyword(string keyword)
        {
            Keyword = keyword;
            return this;
        }

        public ICategory ChoiceDescription(bool description)
        {
            Description = description;
            return this;
        }

        public ISubcategory ChoiceCategory(string category)
        {
            Category = category;
            return this;
        }

        public ISearchBuild ChoiceSubcategory(bool subcategory)
        {
            Subcategory = subcategory;
            return this;
        }

        public ISearchCriteria Build()
        {
            return this;
        }

    }
}
