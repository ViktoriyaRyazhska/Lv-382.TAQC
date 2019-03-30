
namespace OpenCart_Testing.TestData.AddressBookData
{
    public interface IFirstname
    {
        ILastname SetFirstname(string firstname);
    }

    public interface ILastname
    {
        IAddress1 SetLastname(string lastname);
    }

    public interface IAddress1
    {
        ICity SetAddress1(string address1);
    }

    public interface ICity
    {
        IPostcode SetCity(string city);
    }

    public interface IPostcode
    {
        ICountry SetPostcode(string postcode);
    }

    public interface ICountry
    {
        IRegionState SetCountry(string country);
    }

    public interface IRegionState
    {
        IAddressBuild SetRegionState(string regionState);
    }

    public interface IAddressBuild
    {
        IAddressBuild SetCompany(string company);
        IAddressBuild SetAddress2(string address2);
        IAddressBuild SetDefault(bool isDefault);
        IAddress Build();
    }

    public enum AddressFields : int
    {
        Firstname = 0,
        Lastname,
        Address1,
        City,
        Postcode,
        Country,
        RegionState,
        Company,
        Address2,
        Default
    }

    public class Address : IFirstname, ILastname, IAddress1, ICity, IPostcode, ICountry, IRegionState, IAddressBuild, IAddress
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Postcode { get;  set; }
        public string Country { get;  set; }
        public string RegionState { get; set; }
        public bool Default { get; set; }

        private Address()
        {
            Company = string.Empty;
            Address2 = string.Empty;
            Default = false;
        }

        public static IFirstname Get()
        {
            return new Address();
        }

        public ILastname SetFirstname(string firstname)
        {
            Firstname = firstname;
            return this;
        }

        public IAddress1 SetLastname(string lastname)
        {
            Lastname = lastname;
            return this;
        }

        public ICity SetAddress1(string address1)
        {
            Address1 = address1;
            return this;
        }

        public IPostcode SetCity(string city)
        {
            City = city;
            return this;
        }

        public ICountry SetPostcode(string postcode)
        {
            Postcode = postcode;
            return this;
        }

        public IRegionState SetCountry(string country)
        {
            Country = country;
            return this;
        }

        public IAddressBuild SetRegionState(string regionState)
        {
            RegionState = regionState;
            return this;
        }

        public IAddressBuild SetCompany(string company)
        {
            Company = company;
            return this;
        }

        public IAddressBuild SetAddress2(string address2)
        {
            Address2 = address2;
            return this;
        }

        public IAddressBuild SetDefault(bool isDefault)
        {
            Default = isDefault;
            return this;
        }
        
        public IAddress Build()
        {
            return this;
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname
                + "\nLastname = " + Lastname
                + "\nCompany = " + Company
                + "\nAddress1 = " + Address1
                + "\nAddress2 = " + Address2
                + "\nCity = " + City
                + "\nPostcode = " + Postcode
                + "\nCountry = " + Country
                + "\nRegionState = " + RegionState
                + "\nDefault = " + Default.ToString();
        }

        //public static IAddress GetAddress(IList<string> row)
        //{
        //    IList<string> fields = new List<string>(row);
        //    for (int i = fields.Count; i < ((AddressFields[])Enum.GetValues(typeof(AddressFields))).Length; i++)
        //    {
        //        fields.Add("");
        //    }
        //    return Get()
        //        .SetFirstname(fields[(int)AddressFields.Firstname])
        //        .SetLastname(fields[(int)AddressFields.Lastname])
        //        .SetAddress1(fields[(int)AddressFields.Address1])
        //        .SetCity(fields[(int)AddressFields.City])
        //        .SetPostcode(fields[(int)AddressFields.Postcode])
        //        .SetCountry(fields[(int)AddressFields.Country])
        //        .SetRegionState(fields[(int)AddressFields.RegionState])
        //        .SetCompany(fields[(int)AddressFields.Company])
        //        .SetAddress2(fields[(int)AddressFields.Address2])
        //        .SetDefault(Boolean.Parse(fields[(int)AddressFields.Default]))
        //        .Build();
        //}

        //public static IList<IAddress> GetAllAddresses(IList<IList<string>> rows)
        //{
        //    IList<IAddress> addresses = new List<IAddress>();

        //    foreach (IList<string> row in rows)
        //    {
        //        addresses.Add(GetAddress(row));
        //    }
        //    return addresses;
        //}
    }
}
