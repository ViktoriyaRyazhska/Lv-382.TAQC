//using System;
////using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
//using RestSharp;
//using RestSharp.Serialization.Json;
//using RestTestProject.Data;
//using RestTestProject.Services;

//namespace RestTestProject
//{
//    public class RestResult
//    {
//        public string content { get; set; }

//        public RestResult()
//        {
//            content = string.Empty;
//        }

//        public override string ToString()
//        {
//            return content;
//        }
//    }

//    //[TestClass]
//    [TestFixture]
//    public class SimpleTest
//    {
//        private string tokenAdmin;

//        //[Test]
//        public void CheckRest()
//        {
//            // RestClient
//            //string url = "https://api.github.com/";
//            string url = "http://localhost:8080/";
//            var client = new RestClient(url);
//            //
//            // client.Authenticator = new HttpBasicAuthenticator(username, password);
//            // var request = new RestRequest("orgs/dotnet/repos", Method.GET);
//            //
//            //var request = new RestRequest("/", Method.GET);
//            //var request = new RestRequest("item/125", Method.POST);
//            //var request = new RestRequest("item/125", Method.PUT);
//            //var request = new RestRequest("item/125", Method.DELETE);
//            //var request = new RestRequest("/users", Method.GET);
//            var request = new RestRequest("/login", Method.POST);
//            //var request = new RestRequest(Method.GET);
//            //
//            //request.RequestFormat = DataFormat.Json;
//            //
//            // Add HTTP Headers
//            //request.AddHeader("header", "value");
//            //
//            //request.AddBody(new Item
//            //{
//            //    ItemName = "someName",
//            //    Price = 19.99
//            //});
//            //
//            //request.AddParameter("name", "value");
//            request.AddParameter("name", "admin");
//            request.AddParameter("password", "qwerty");
//            //request.AddParameter("token", "9HVFA4SO13VSY4GQX0UY97HG3S7Y2MEM");
//            //
//            // Adds to POST or URL querystring based on Method
//            //var request = new RestRequest("resource/{id}", Method.POST);
//            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
//            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
//            //
//            // Sdd files to upload (works with compatible verbs)
//            //request.AddFile(path);
//            //
//            // Execute the Request
//            IRestResponse response = client.Execute(request);
//            //
//            // Aontent as String
//            var content = response.Content;
//            Console.WriteLine("content: " + content);
//            //
//            // Automatically Deserialize Result
//            //RestResponse<Person> response2 = client.Execute<Person>(request);
//            // var name = response2.Data.Name;
//            //
//            // Async Support
//            // client.ExecuteAsync(request, response => {
//            //    Console.WriteLine(response.Content);
//            //});
//            //
//            // Async with Deserialization
//            //var asyncHandle = client.ExecuteAsync<Person>(request, response => {
//            //    Console.WriteLine(response.Data.Name);
//            //});
//            //
//            // abort the request on demand
//            // asyncHandle.Abort();
//            //
//            Console.WriteLine("done");
//        }

//        //[Test]
//        public void CheckTime()
//        {
//            string url = "http://localhost:8080/";
//            var client = new RestClient(url);
//            //
//            var request = new RestRequest("/login", Method.POST);
//            request.AddParameter("name", "admin");
//            request.AddParameter("password", "qwerty");
//            IRestResponse response = client.Execute(request);
//            //
//            JsonDeserializer deserial = new JsonDeserializer();
//            string adminToken = deserial.Deserialize<RestResult>(response).content;
//            Assert.IsTrue(adminToken.Length > 0, "Login Error");
//            //
//            request = new RestRequest("/tokenlifetime", Method.GET);
//            response = client.Execute(request);
//            string time = deserial.Deserialize<RestResult>(response).content;
//            Assert.AreEqual("300000", time, "Time Error");
//            //
//            request = new RestRequest("/tokenlifetime", Method.PUT);
//            request.AddParameter("token", adminToken);
//            request.AddParameter("time", "800000");
//            response = client.Execute(request);
//            string result = deserial.Deserialize<RestResult>(response).content;
//            StringAssert.AreEqualIgnoringCase("true", result, "Update Time Error");
//            //Assert.AreEqual("true", result, "Update Time Error");
//            //
//            request = new RestRequest("/logout", Method.POST);
//            request.AddParameter("name", "admin");
//            request.AddParameter("token", adminToken);
//            response = client.Execute(request);
//            result = deserial.Deserialize<RestResult>(response).content;
//            StringAssert.AreEqualIgnoringCase("true", result, "Logout Error");
//            //
//            request = new RestRequest("/tokenlifetime", Method.GET);
//            response = client.Execute(request);
//            time = deserial.Deserialize<RestResult>(response).content;
//            Assert.AreEqual("800000", time, "Time Error");
//        }

//        //[Test]
//        public void VerifyLogin()
//        {
//            var client = new RestClient("http://localhost:8080/login");
//            var request = new RestRequest(Method.POST);
//            request.AddParameter("name", "admin");
//            request.AddParameter("password", "qwerty");
//            IRestResponse response = client.Execute(request);
//            //
//            JsonDeserializer deserial = new JsonDeserializer();
//            tokenAdmin = deserial.Deserialize<RestResult>(response).content;
//            Assert.IsTrue(tokenAdmin.Length > 0, "Login Error");
//        }

//        [Test]
//        public void CheckTimeChange()
//        {
//            IUser admin = UserRepository.Get().Admin();
//            AdminService loggedAdmin = new GuestService().SuccessfulAdminLogin(admin);
//            string newTime = loggedAdmin.UpdateTokenlifetime(new Lifetime("800000"));
//            Assert.AreEqual("800000", newTime, "Time Error");
//        }

//        //[Test, Order(2)]
//        public void VerifyTime()
//        {
//            var client = new RestClient("http://localhost:8080/tokenlifetime");
//            var request = new RestRequest(Method.GET);
//            IRestResponse response = client.Execute(request);
//            //
//            JsonDeserializer deserial = new JsonDeserializer();
//            string time = deserial.Deserialize<RestResult>(response).content;
//            Assert.AreEqual("800000", time, "Time Error");
//        }

//        //[Test, Order(3)]
//        public void VerifyUpdateTime()
//        {
//            var client = new RestClient("http://localhost:8080/tokenlifetime");
//            var request = new RestRequest(Method.PUT);
//            request.AddParameter("token", tokenAdmin);
//            request.AddParameter("time", "300000");
//            IRestResponse response = client.Execute(request);
//            //
//            JsonDeserializer deserial = new JsonDeserializer();
//            string result = deserial.Deserialize<RestResult>(response).content;
//            StringAssert.AreEqualIgnoringCase("true", result, "Update Time Error");
//        }

//        //[Test, Order(4)]
//        public void VerifyLogout()
//        {
//            var client = new RestClient("http://localhost:8080/logout");
//            var request = new RestRequest(Method.POST);
//            request.AddParameter("name", "admin");
//            request.AddParameter("token", tokenAdmin);
//            IRestResponse response = client.Execute(request);
//            //
//            JsonDeserializer deserial = new JsonDeserializer();
//            string result = deserial.Deserialize<RestResult>(response).content;
//            StringAssert.AreEqualIgnoringCase("true", result, "Logout Error");
//        }

//    }
//}
