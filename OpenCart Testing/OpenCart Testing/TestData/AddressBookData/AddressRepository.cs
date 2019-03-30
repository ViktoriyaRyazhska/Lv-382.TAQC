using OpenCart_Testing.Tools;

namespace OpenCart_Testing.TestData.AddressBookData
{
    public sealed class AddressRepository
    {
        private volatile static AddressRepository instance;
        private static object lockingObject = new object();
        private static string directory = "Addresses";

        private AddressRepository()
        {
        }

        public static AddressRepository Get()
        {
            if (instance == null)  //
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new AddressRepository();
                    }
                }
            }
            return instance;
        }

        public IAddress NewAddressFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<Address>(directory, fileName) as IAddress;
        }
    }
}
