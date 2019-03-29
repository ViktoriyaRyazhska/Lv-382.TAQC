using OpenCart_Testing.Tools;

namespace OpenCart_Testing.TestData.WishListMessage
{
    public sealed class WishListMessageRepository
    {
        private volatile static WishListMessageRepository exemplar;
        private static object lockObject = new object();
        private static string directory = "WishListMessages";

        private WishListMessageRepository()
        {

        }

        public static WishListMessageRepository Get()
        {
            if (exemplar == null)
            {
                lock (lockObject)
                {
                    if (exemplar == null)
                    {
                        exemplar = new WishListMessageRepository();
                    }
                }
            }
            return exemplar;
        }

        public WishListMessage WishListFromJson(string filename)
        {
            return JsonParser.DeserializeFromFile<WishListMessage>(directory, filename);
        }
    }
}
