
namespace OpenCart_Testing.TestData
{
    public interface ISearchCriteria
    {
        string Keyword { get; }
        bool Description { get; }
        string Category { get; }
        bool Subcategory { get; }
    }
}
