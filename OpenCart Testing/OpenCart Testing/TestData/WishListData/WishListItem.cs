using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData.WishListData
{
    public class WishListItem
    {
        public string Name { get; set; }
        public WishListItem(string itemName)
        {
            Name = itemName;
        }
        public string GetItemName()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            WishListItem temp = obj as WishListItem;
            return (temp.Name == this.Name);
        }
    }
}
