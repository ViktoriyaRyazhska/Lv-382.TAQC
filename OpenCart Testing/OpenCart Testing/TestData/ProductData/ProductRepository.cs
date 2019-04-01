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
        private const string productEmptyListMessage = "There is no product that matches the search criteria.";
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
        public Product GetIphone()
        {
            return new Product("iPhone",
                "iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping a nam..",
                101.0m);
        }



        ///////////////////////////////////
        public static Product GetDefault()
        {
            return GetMacBook();
        }

        public static IList<Product> GetMacListProducts()
        {
            return new List<Product>() { GetIMac(), GetMacBook(), GetMacBookAir(), GetMacBookPro() };
        }

        public static Product GetMacBook()
        {
            return new Product("mac", "MacBook",
                "Intel Core 2 Duo processor Powered by an Intel Core 2 Duo processor at speeds up to 2.1..",
                500.0m);
        }

        public static Product GetIMac()
        {
            return new Product("mac", "iMac",
                "Just when you thought iMac had everything, now there´s even more. More powerful Intel Core 2 Duo ..",
                100.0m);
        }

        public static Product GetMacBookAir()
        {
            return new Product("mac", "MacBook Air",
                "MacBook Air is ultrathin, ultraportable, and ultra unlike anything else. But you don’t lose..",
                1000.0m);
        }

        public static Product GetMacBookPro()
        {
            return new Product("mac", "MacBook Pro",
                "Latest Intel mobile architecture Powered by the most advanced mobile processors ..",
                2000.0m);
        }

        public static string GetProductEmptyListMessage()
        {
            return productEmptyListMessage;
        }

    }
}
