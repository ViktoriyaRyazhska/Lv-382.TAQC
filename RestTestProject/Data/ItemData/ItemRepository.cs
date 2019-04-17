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
            return new ItemTemplate("FirstItem", "1");
        }
        public static ItemTemplate GetSecond()
        {
            return new ItemTemplate("SecondItem", "2");
        }
        public static ItemTemplate GetThird()
        {
            return new ItemTemplate("ThirdItem", "3");
        }
        public static ItemTemplate GetForUpdate()
        {
            return new ItemTemplate("UpdatedItem", "3");
        }

        public static IList<ItemTemplate> GetAllItems()
        {
            return new List<ItemTemplate>() { GetFirst(), GetSecond(), GetThird()};
        }

    }
}
