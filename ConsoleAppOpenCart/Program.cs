using OpenCartTestProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpenCart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Use Constructor
            //User user = new User("firstname1", "lastname1",
            //    "email1", "telephone1", "fax1",
            //    "company1", "1address1", "1address2",
            //    "city1", "postcode1", "country1",
            //    "region1", "password1", true);
            //Console.WriteLine("user.Lastname" + user.Lastname);
            //
            // 2. Default Constructor and Setters
            //User user = new User();
            //user.SetFirstname("firstname2");
            //user.SetLastname("lastname2");
            //user.SetEmail("email2");
            //user.SetTelephone("telephone2");
            //user.SetFax("fax2");
            //user.SetCompany("company2");
            //user.SetAddress1("2address1");
            //user.SetAddress2("2address2");
            //user.SetCity("city2");
            //user.SetPostcode("postcode2");
            //user.SetCountry("country2");
            //user.SetRegionState("regionState2");
            //user.SetPassword("password2");
            //user.SetSubscribe(true);
            //Console.WriteLine("user.Lastname" + user.Lastname);
            //
            // 3. Add Fluent Interface
            //User user = new User()
            //    .SetFirstname("firstname3")
            //    .SetLastname("lastname3")
            //    .SetEmail("email3")
            //    .SetTelephone("telephone3")
            //    .SetFax("fax3")
            //    .SetCompany("company3")
            //    .SetAddress1("3address1")
            //    .SetAddress2("3address2")
            //    .SetCity("city3")
            //    .SetPostcode("postcode3")
            //    .SetCountry("country3")
            //    .SetRegionState("regionState3")
            //    .SetPassword("password3")
            //    .SetSubscribe(true);
            //Console.WriteLine("user.Lastname" + user.Lastname);
            //
            // 4. Add Static Factory
            User user = User.Get()
                .SetFirstname("firstname4")
                .SetLastname("lastname4")
                .SetEmail("email4")
                .SetTelephone("telephone4")
                .SetFax("fax4")
                .SetCompany("company4")
                .SetAddress1("4address1")
                .SetAddress2("4address2")
                .SetCity("city4")
                .SetPostcode("postcode4")
                .SetCountry("country4")
                .SetRegionState("regionState4")
                .SetPassword("password4")
                .SetSubscribe(true);
            Console.WriteLine("user.Lastname" + user.Lastname);
            //
            Console.WriteLine("\nDone.");
        }
    }
}
