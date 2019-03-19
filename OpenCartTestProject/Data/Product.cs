using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Data
{
    public class Product
    {
        public string SearchKeyword { get; private set; }
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public decimal PriceTax { get; private set; }

        public Product(string searchKeyword, string name, string shortDescription, decimal priceTax)
        {
            SearchKeyword = searchKeyword;
            Name = name;
            ShortDescription = shortDescription;
            PriceTax = priceTax;
        }

        public override bool Equals(object obj)
        {
            Product compare = obj as Product;
            return Name.Equals(compare.Name)
                && ShortDescription.Equals(compare.ShortDescription)
                && PriceTax == compare.PriceTax;
        }

        public static IList<string> GetProductListNames(IList<Product> productList)
        {
            IList<string> productNames = new List<string>();
            foreach (Product currentProduct in productList)
            {
                productNames.Add(currentProduct.Name);
            }
            return productNames;
        }
    }
}
