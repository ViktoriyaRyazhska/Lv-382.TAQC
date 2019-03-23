namespace OpenCart_Testing.TestData
{
    public interface IReview
    {
        string Name { get; }
        string Text { get; }
        int Rating { get; }
        string Date { get; }
    }
}
