using OpenCart_Testing.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData.WishListData
{
    public sealed class WishListItemsRepository
    {
        private volatile static WishListItemsRepository instance;
        private static object lockingObject = new object();
        private static string directory = "WishListItems";

        private WishListItemsRepository()
        {
        }

        public static WishListItemsRepository Get()
        {
            if (instance == null) 
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new WishListItemsRepository();
                    }
                }
            }
            return instance;
        }
      
        public WishListItem WishListItemFromJson(string filename)
        {
            return JsonParser.DeserializeFromFile<WishListItem>(directory, filename);
        }

        public IList<WishListItem> WishListItemsFromJson(string filename)
        {
            return JsonParser.DeserializeFromFile<IList<WishListItem>>(directory, filename);
        }

    }
}
