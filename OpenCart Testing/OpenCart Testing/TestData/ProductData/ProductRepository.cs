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

    }
}
