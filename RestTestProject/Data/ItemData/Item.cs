using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{ 
    public class Item
    {
        public string Text { get; set; }

        public Item()
        {
            Text = string.Empty;
        }

        public Item(string text)
        {
            Text = text;
        }
    }
}
