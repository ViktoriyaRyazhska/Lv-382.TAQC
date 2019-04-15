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
            return new ItemTemplate("my information", "123");
        }

    }
}
