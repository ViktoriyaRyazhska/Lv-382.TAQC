using Newtonsoft.Json;
using NLog;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace ConsoleAppOpenCart
{
    // For RestSharp
    public class RestResult
    {
        public string content { get; set; }

        public override string ToString()
        {
            return "class RestResult.ToString(): " + content;
        }
    }

    // For Newtonsoft.Json
    public class RestResult2
    {
        [JsonProperty("content")]
        public string Answer { get; set; }

        public override string ToString()
        {
            return "class RestResult2.ToString(): " + Answer;
        }
    }

    public class RestResultOrgsDotnetReposArray
    {
        public string html_url { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return "class RestResultOrgsDotnetReposArray.ToString():"
                + "\nhtml_url: " + html_url
                + "\ndescription: " + description;
        }
    }

    public class RestResultOrgsDotnet2
    {
        [JsonProperty("login")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string HtmlUrl { get; set; }

        public string MyInfo { get; set; } = "Running";

        public override string ToString()
        {
            return "class RestResultOrgsDotnetReposArray.ToString():"
                + "\nlogin: " + Description
                + "\nemail: " + HtmlUrl
                + "\nMyInfo: " + MyInfo;
        }
    }
    public class RestResultOrgsDotnet
    {
        public string login { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return "class RestResultOrgsDotnet.ToString():"
                + "\nlogin: " + login
                + "\nemail: " + email;
        }
    }

    public class Program
    {
        //private static ILog log = LogManager.GetLogger("Program");
        //private static Logger log = LogManager.GetLogger("Program");
        //private static Logger log = LogManager.GetCurrentClassLogger();
        //
        //public static ILog log = LogManager.GetLogger(typeof(Program));   // log4net
        //public static Logger log = LogManager.GetCurrentClassLogger();    // nlog
        public static Logger log = LogManager.GetLogger("rolling0");        // nlog

        public static void Main(string[] args)
        {
            // 1. Use Constructor
            //User user = new User("firstname1", "lastname1",
            //    "email1", "telephone1", "fax1",
            //    "company1", "1address1", "1address2",
            //    "city1", "postcode1", "country1",
            //    "region1", "password1", true);
            //Console.WriteLine("user.Lastname " + user.Lastname);
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
            //Console.WriteLine("user.Lastname " + user.Lastname);
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
            //Console.WriteLine("user.Lastname " + user.Lastname);
            //
            // 4. Add Static Factory
            //User user = User.Get()
            //    .SetFirstname("firstname4")
            //    .SetLastname("lastname4")
            //    .SetEmail("email4")
            //    .SetTelephone("telephone4")
            //    .SetFax("fax4")
            //    .SetCompany("company4")
            //    .SetAddress1("4address1")
            //    .SetAddress2("4address2")
            //    .SetCity("city4")
            //    .SetPostcode("postcode4")
            //    .SetCountry("country4")
            //    .SetRegionState("regionState4")
            //    .SetPassword("password4")
            //    .SetSubscribe(true);
            //Console.WriteLine("user.Lastname " + user.Lastname);
            //
            // 5. Add Builder
            //User user = User.Get()
            //    .SetFirstname("Firstname5")
            //    .SetLastname("Lastname5")
            //    .SetEmail("Email5")
            //    .SetTelephone("123456")
            //    .SetAddress1("5Address1")
            //    .SetCity("City5")
            //    .SetPostcode("54321")
            //    .SetCountry("Country5")
            //    .SetRegionState("RegionState5")
            //    .SetPassword("Password5")
            //    .SetSubscribe(true)
            //    .SetFax("Fax5")
            //    .Build();
            //Console.WriteLine("user.Lastname " + user.Lastname);
            // Code
            //user.SetLastname("12345");  // Defect
            //Console.WriteLine("user.Lastname " + user.Lastname);
            //
            // 6. Dependency Inversion
            //IUser user = User.Get()
            //    .SetFirstname("Firstname6")
            //    .SetLastname("Lastname6")
            //    .SetEmail("Email6")
            //    .SetTelephone("123456")
            //    .SetAddress1("6Address1")
            //    .SetCity("City6")
            //    .SetPostcode("54321")
            //    .SetCountry("Country6")
            //    .SetRegionState("RegionState6")
            //    .SetPassword("Password6")
            //    .SetSubscribe(true)
            //    .SetFax("Fax6")
            //    .Build();
            //Console.WriteLine("user.Lastname " + user.Lastname);
            // Code
            //user.SetLastname("12345");  // Compile Error
            //((User)user).SetLastname("12345");  // Code Smell
            //Console.WriteLine("user.Lastname " + user.Lastname);
            //
            // 7. Singleton
            // 8. Repository
            //IUser user = UserRepository.Get().Registered();
            //Console.WriteLine("user.Lastname " + user.Lastname);
            //
            //// REST
            ////
            ////string url = "https://api.github.com";
            //string url = "http://localhost:8080";
            //var client = new RestClient(url);
            ////
            ////var request = new RestRequest("/orgs/dotnet/repos", Method.GET);
            ////var request = new RestRequest("/orgs/dotnet", Method.GET);
            ////var request = new RestRequest("/tokenlifetime", Method.GET);
            ////var request = new RestRequest("/", Method.GET);
            ////
            //var request = new RestRequest("/login", Method.POST);
            //request.AddParameter("name", "admin");
            //request.AddParameter("password", "qwerty");
            ////
            ////var request = new RestRequest("/tokenlifetime", Method.PUT);
            ////request.AddParameter("token", "HNPQ9A0Q455EDPAUV8FIL232AQ7RICBT");
            ////request.AddParameter("time", "700000");
            ////
            //IRestResponse response = client.Execute(request);
            //var content = response.Content;
            //Console.WriteLine("content: " + content);
            ////
            ////JsonDeserializer deserial = new JsonDeserializer();
            ////var obj = deserial.Deserialize<RestResult>(response);
            ////var obj = JsonConvert.DeserializeObject<RestResult2>(response.Content);
            ////Console.WriteLine("\nDeserialize content: " + obj);
            ////
            ////JsonDeserializer deserial = new JsonDeserializer();
            ////var obj = deserial.Deserialize<RestResultOrgsDotnet>(response);
            //var obj = JsonConvert.DeserializeObject<RestResultOrgsDotnet2>(response.Content);
            //Console.WriteLine("\nDeserialize content: " + obj);
            ////
            ////JsonDeserializer deserial = new JsonDeserializer();
            ////var obj = deserial.Deserialize <List<RestResultOrgsDotnetReposArray>>(response);
            ////foreach (RestResultOrgsDotnetReposArray current in obj)
            ////{
            ////    Console.WriteLine("\nDeserialize content: " + current);
            ////}
            //

            //string someStr = "1    asdsads \n2    sadnsajd \n";
            ////Console.WriteLine(someStr);

            //List<string> elems = new List<string>(someStr.Split('\n'));
            //foreach(string elemnt in  elems)
            //    Console.WriteLine(elemnt);
            //Console.ReadKey();

            //BasicConfigurator.Configure();
            //XmlConfigurator.Configure();  // log4net
            //
            log.Trace("NLOG: Trace Level test"); // nlog
            log.Debug("2*Debug Level test");
            log.Info("2*Info Level");
            log.Warn("2*Warn Level");
            log.Error("2*Error Level1");
            log.Error("2*Error Level2 test");
            //log.Fatal("2*Fatal Level");
            Console.ReadKey();
            Console.WriteLine("\nDone.");
        }
    }
}
