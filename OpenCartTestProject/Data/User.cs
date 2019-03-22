using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Data
{
    public interface IFirstname
    {
        ILastname SetFirstname(string firstname);
    }

    public interface ILastname
    {
        IEmail SetLastname(string lastname);
    }

    public interface IEmail
    {
        ITelephone SetEmail(string email);
    }

    public interface ITelephone
    {
        IAddress1 SetTelephone(string telephone);
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
        IPassword SetRegionState(string regionState);
    }

    public interface IPassword
    {
        ISubscribe SetPassword(string password);
    }

    public interface ISubscribe
    {
        IUserBuild SetSubscribe(bool subscribe);
    }

    public interface IUserBuild
    {
        IUserBuild SetFax(string fax);

        IUserBuild SetCompany(string company);

        IUserBuild SetAddress2(string address2);

        // 5. Add Builder
        //User Build();
        // 6. Dependency Inversion
        IUser Build();
    }

    public enum UserFields : int
    {
        Firstname = 0,
        Lastname,
        Email,
        Telephone,
        Address1,
        City,
        Postcode,
        Country,
        RegionState,
        Password,
        Subscribe,
        Fax,
        Company,
        Address2
    }


    public class User : IFirstname, ILastname, IEmail, ITelephone,
        IAddress1, ICity, IPostcode, ICountry, IRegionState,
        IPassword, ISubscribe, IUserBuild, IUser
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }
        // 1. Use Constructor
        //public string Fax { get; set; }         // not required
        // 2. Default Constructor and Setters
        public string Fax { get; private set; }         // not required
        // 1. Use Constructor
        //public string Company { get; set; }     // not required
        // 2. Default Constructor and Setters
        public string Company { get; private set; }     // not required
        public string Address1 { get; private set; }
        // 1. Use Constructor
        //public string Address2 { get; set; }    // not required
        // 2. Default Constructor and Setters
        public string Address2 { get; private set; }    // not required
        public string City { get; private set; }
        public string Postcode { get; private set; }
        public string Country { get; private set; }
        public string RegionState { get; private set; }
        public string Password { get; private set; }
        public bool Subscribe { get; private set; }

        // 1. Use Constructor
        //public User(string firstname, string lastname,
        //        string email, string telephone, string fax,
        //        string company, string address1, string address2,
        //        string city, string postcode, string country,
        //        string region, string password, bool subscribe)
        //{
        //    Firstname = firstname;
        //    Lastname = lastname;
        //    Email = email;
        //    Telephone = telephone;
        //    Fax = fax;
        //    Company = company;
        //    Address1 = address1;
        //    Address2 = address2;
        //    City = city;
        //    Postcode = postcode;
        //    Country = country;
        //    RegionState = region;
        //    Password = password;
        //    Subscribe = subscribe;
        //}

        //public User(string firstname, string lastname,
        //       string email, string telephone,
        //       string address1,
        //       string city, string postcode, string country,
        //       string region, string password, bool subscribe)
        //{
        //    Firstname = firstname;
        //    Lastname = lastname;
        //    Email = email;
        //    Telephone = telephone;
        //    Fax = string.Empty;
        //    Company = string.Empty;
        //    Address1 = address1;
        //    Address2 = string.Empty;
        //    City = city;
        //    Postcode = postcode;
        //    Country = country;
        //    RegionState = region;
        //    Password = password;
        //    Subscribe = subscribe;
        //}

        // 2. Default Constructor and Setters
        //public User()
        // 4. Add Static Factory
        //private User()
        //{
        //    Firstname = string.Empty;
        //    Lastname = string.Empty;
        //    Email = string.Empty;
        //    Telephone = string.Empty;
        //    Fax = string.Empty;
        //    Company = string.Empty;
        //    Address1 = string.Empty;
        //    Address2 = string.Empty;
        //    City = string.Empty;
        //    Postcode = string.Empty;
        //    Country = string.Empty;
        //    RegionState = string.Empty;
        //    Password = string.Empty;
        //    Subscribe = true;
        //}

        // 5. Add Builder
        private User()
        {
            Fax = string.Empty;
            Company = string.Empty;
            Address2 = string.Empty;
        }

        // 4. Add Static Factory
        //public static User Get()
        // 5. Add Builder
        public static IFirstname Get()
        {
            return new User();
        }

        // setters

        // 2. Default Constructor and Setters
        //public void SetFirstname(string firstname)
        // 3. Add Fluent Interface
        //public User SetFirstname(string firstname)
        // 5. Add Builder
        public ILastname SetFirstname(string firstname)
        {
            Firstname = firstname;
            return this;
        }

        public IEmail SetLastname(string lastname)
        {
            Lastname = lastname;
            return this;
        }

        public ITelephone SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public IAddress1 SetTelephone(string telephone)
        {
            Telephone = telephone;
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

        public IPassword SetRegionState(string regionState)
        {
            RegionState = regionState;
            return this;
        }

        public ISubscribe SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public IUserBuild SetSubscribe(bool subscribe)
        {
            Subscribe = subscribe;
            return this;
        }

        public IUserBuild SetFax(string fax)
        {
            Fax = fax;
            return this;
        }

        public IUserBuild SetCompany(string company)
        {
            Company = company;
            return this;
        }

        public IUserBuild SetAddress2(string address2)
        {
            Address2 = address2;
            return this;
        }

        // 5. Add Builder
        //public User Build()
        // 6. Dependency Inversion
        public IUser Build()
        {
            return this;
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname
                + "\nLastname = " + Lastname
                + "\nEmail = " + Email
                + "\nTelephone = " + Telephone
                + "\nFax = " + Fax
                + "\nCompany = " + Company
                + "\nAddress1 = " + Address1
                + "\nAddress2 = " + Address2
                + "\nCity = " + City
                + "\nPostcode = " + Postcode
                + "\nCountry = " + Country
                + "\nRegionState = " + RegionState
                + "\nPassword = " + Password
                + "\nSubscribe = " + Subscribe.ToString();
        }

        public static IUser GetUser(IList<string> row)
        {
            IList<string> fields = new List<string>(row);
            for (int i = fields.Count; i < ((UserFields[])Enum.GetValues(typeof(UserFields))).Length; i++)
            {
                fields.Add("");
            }
            return Get()
                .SetFirstname(fields[(int)UserFields.Firstname])
                .SetLastname(fields[(int)UserFields.Lastname])
                .SetEmail(fields[(int)UserFields.Email])
                .SetTelephone(fields[(int)UserFields.Telephone])
                .SetAddress1(fields[(int)UserFields.Address1])
                .SetCity(fields[(int)UserFields.City])
                .SetPostcode(fields[(int)UserFields.Postcode])
                .SetCountry(fields[(int)UserFields.Country])
                .SetRegionState(fields[(int)UserFields.RegionState])
                .SetPassword(fields[(int)UserFields.Password])
                //.SetSubscribe(fields[(int)UserFields.Subscribe].ToLower().Equals("true"))
                .SetSubscribe(Boolean.Parse(fields[(int)UserFields.Subscribe]))
                .SetFax(fields[(int)UserFields.Fax])
                .SetCompany(fields[(int)UserFields.Company])
                .SetAddress2(fields[(int)UserFields.Address2])
                .Build();
        }

        public static IList<IUser> GetAllUsers(IList<IList<string>> rows)
        {
            //logger.Debug("Start GetAllUsers, path = " + path);
            IList<IUser> users = new List<IUser>();
            //if ((rows[0][(int)UserFields.Email] != null)
            //    && (!rows[0][(int)UserFields.Email].Contains(EMAIL_SEPARATOR)))
            //{
            //    rows.Remove(rows[0]);
            //}
            foreach (IList<string> row in rows)
            {
                if (!row[(int)UserFields.Email].Contains("@"))
                {
                    continue;
                }
                users.Add(GetUser(row));
            }
            return users;
        }

    }

}
