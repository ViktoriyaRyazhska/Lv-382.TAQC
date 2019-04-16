using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{

    public sealed class ItemRepository
    {
        private ItemRepository()
        {
        }

        public static ItemTemplate GetFirst()
        {
            return new ItemTemplate("my information", "1");
        }
        public static ItemTemplate GetSecond()
        {
            return new ItemTemplate("more information ", "2");
        }
        public static ItemTemplate GetForUpdate()
        {
            return new ItemTemplate("MY INFO ", "1");
        }

        public static IList<ItemTemplate> GetAllItems()
        {
            return new List<ItemTemplate>() { GetFirst(), GetSecond(), GetForUpdate()};
        }

    }
}
