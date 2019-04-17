using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public class ItemTemplate
    {
        public string Item { get; private set; }
        public string Index { get; private set; }

        public ItemTemplate(string item, string index)
        {
            Item = item;
            Index = index;
        }

        public override string ToString()
        {
            return Index + "       " + Item;
        }
    }
}
