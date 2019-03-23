﻿namespace OpenCart_Testing.TestData
{
    public sealed class ReviewsRepository
    {
        private volatile static ReviewsRepository instance;
        private static object lockingObject = new object();

        private ReviewsRepository()
        {
        }

        public static ReviewsRepository Get()
        {
            if (instance == null)  //
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new ReviewsRepository();
                    }
                }
            }
            return instance;
        }

        public IReview Invalid()
        {
            return Review.Get().SetName("aa").SetText("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").SetRating(4).Build();
        }

        //public IReview NewReviewFromJson()
        //{

        //}

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
