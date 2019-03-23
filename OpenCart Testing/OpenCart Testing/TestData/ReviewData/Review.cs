namespace OpenCart_Testing.TestData
{

    public interface IName
    {
        IText SetName(string name);
    }

    public interface IText
    {
        IRating SetText(string text);
    }

    public interface IRating
    {
        IUserBuild SetRating(int rating);
    }

    public interface IUserBuild
    {
        IUserBuild SetDate(string date);
        IReview Build();
    }

    public enum ReviewField : int
    {
        Name = 0,
        Text,
        Rating,
        Date
    }


    public class Review : IName, IText, IRating, IUserBuild, IReview
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string Date { get; set; }


        private Review()
        {

        }

        public static IName Get()
        {
            return new Review();
        }


        public IText SetName(string name)
        {
            Name = name;
            return this;
        }

        public IRating SetText(string text)
        {
            Text = text;
            return this;
        }

        public IUserBuild SetRating(int rating)
        {
            Rating = rating;
            return this;
        }

        public IUserBuild SetDate(string date)
        {
            Date = date;
            return this;
        }

        public IReview Build()
        {
            return this;
        }

    }

}

