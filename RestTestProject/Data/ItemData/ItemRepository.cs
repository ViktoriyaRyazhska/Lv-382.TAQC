using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    
    public sealed class ItemRepository
    {
        public const string AGE = "Age";
        public const string CITY = "City";
        public const string COUNTRY = "Country";

        private ItemRepository()
        {
        }

        public static Item GetAge()
        {
            return new Item(AGE);
        }

        public static Item GetCity()
        {
            return new Item(CITY);
        }

        public static Item GetCountry()
        {
            return new Item(COUNTRY);
        }
    }
}
