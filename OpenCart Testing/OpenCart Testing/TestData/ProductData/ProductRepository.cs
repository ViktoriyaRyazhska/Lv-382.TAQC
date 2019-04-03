using OpenCart_Testing.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData
{
    public sealed class ProductRepository
    {
        private volatile static ProductRepository instance;
        private static object lockingObject = new object();
        public string GetProductEmptyListMessage() => "There is no product that matches the search criteria.";
        public string GetProductMaxLengthMessage() => "Search text maximum length is 255 characters. Please make a different search request.";
        private static string directory = "Products";

        private ProductRepository()
        {
        }

        public static ProductRepository Get()
        {
            if (instance == null)  //
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new ProductRepository();
                    }
                }
            }
            return instance;
        }

        public Product NewProductFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<Product>(directory, fileName);
        }

        public static IList<Product> NewProductArrayFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<IList<Product>>(directory, fileName);
        }

        public Product GetIphone()
        {
            return new Product("iPhone",
                "iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping a nam..",
                101.0m);
        }
    }
}
