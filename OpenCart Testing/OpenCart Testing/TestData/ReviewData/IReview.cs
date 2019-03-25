namespace OpenCart_Testing.TestsData
{
    public interface IReview
    {
        string Name { get; }
        string Text { get; }
        int Rating { get; }
        string Date { get; }
    }
}
