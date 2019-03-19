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
        public string Fax { get; private set; }         // not required
        public string Company { get; private set; }     // not required
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }    // not required
        public string City { get; private set; }
        public string Postcode { get; private set; }
        public string Country { get; private set; }
        public string RegionState { get; private set; }
        public string Password { get; private set; }
        public bool Subscribe { get; private set; }

        public User(string firstname, string lastname,
                string email, string telephone, string fax,
                string company, string address1, string address2,
                string city, string postcode, string country,
                string region, string password, bool subscribe)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Telephone = telephone;
            Fax = fax;
            Company = company;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Postcode = postcode;
            Country = country;
            RegionState = region;
            Password = password;
            Subscribe = subscribe;
        }
    }

}
