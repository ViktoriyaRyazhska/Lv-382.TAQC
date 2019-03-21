using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Data
{
    public class User
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
        private User()
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Telephone = string.Empty;
            Fax = string.Empty;
            Company = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            City = string.Empty;
            Postcode = string.Empty;
            Country = string.Empty;
            RegionState = string.Empty;
            Password = string.Empty;
            Subscribe = true;
        }

        // 4. Add Static Factory
        public static User Get()
        {
            return new User();
        }

        // setters

        // 2. Default Constructor and Setters
        //public void SetFirstname(string firstname)
        // 3. Add Fluent Interface
        public User SetFirstname(string firstname)
        {
            Firstname = firstname;
            return this;
        }

        public User SetLastname(string lastname)
        {
            Lastname = lastname;
            return this;
        }

        public User SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public User SetTelephone(string telephone)
        {
            Telephone = telephone;
            return this;
        }

        public User SetFax(string fax)
        {
            Fax = string.Empty;
            return this;
        }

        public User SetCompany(string company)
        {
            Company = string.Empty;
            return this;
        }

        public User SetAddress1(string address1)
        {
            Address1 = address1;
            return this;
        }

        public User SetAddress2(string address2)
        {
            Address2 = string.Empty;
            return this;
        }

        public User SetCity(string city)
        {
            City = city;
            return this;
        }

        public User SetPostcode(string postcode)
        {
            Postcode = postcode;
            return this;
        }

        public User SetCountry(string country)
        {
            Country = country;
            return this;
        }

        public User SetRegionState(string regionState)
        {
            RegionState = regionState;
            return this;
        }

        public User SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public User SetSubscribe(bool subscribe)
        {
            Subscribe = subscribe;
            return this;
        }

    }

}
