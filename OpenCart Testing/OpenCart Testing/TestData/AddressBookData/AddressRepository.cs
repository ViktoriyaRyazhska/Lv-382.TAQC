using OpenCart_Testing.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IAddress Registered()
        {
            return Address.Get()
                .SetFirstname("Firstname8")
                .SetLastname("Lastname8")
                .SetAddress1("8Address1")
                .SetCity("City8")
                .SetPostcode("54321")
                .SetCountry("Country8")
                .SetRegionState("RegionState8")
                .SetCompany("Company")
                .SetAddress2("Address2")
                .SetDefault(false)
                .Build();
        }

        public IAddress NewAddressFromJson(string fileName)
        {
            return JsonParser.DeserializeFromFile<Review>(directory, fileName) as IAddress;
        }
    }
}
