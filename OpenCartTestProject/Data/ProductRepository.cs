using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Data
{
    public sealed class ProductRepository
    {
        private ProductRepository() { }

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

    }
}
