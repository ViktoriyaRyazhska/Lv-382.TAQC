using OpenCart_Testing.Tools;
using System.Collections.Generic;

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

        public static List<string> AddressFirstnameFromJson(string fileName)
        {
            IList<Address> addressArray = JsonParser.DeserializeFromFile<IList<Address>>(directory, fileName);
            List<string> firstnameArray = new List<string>();
            foreach (Address addr in addressArray)
            {
                firstnameArray.Add(addr.Firstname);
            }
            return firstnameArray;
        }

        public static IList<Address> NewAddressArrayFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<IList<Address>>(directory, fileName);
        }
    }
}
