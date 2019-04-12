using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public sealed class RestUrlRepository
    {
        private static string server = "http://localhost:8080";

        public static string Server
        {
            get { return server; }
            //set { server = value; }
        }

        private RestUrlRepository()
        {
        }

        public static RestUrl GetAdminAuthorized()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/login/users")
                .AddPostUrl("/login")
                .AddPutUrl("")
                .AddDeleteUrl("");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetUserAuthorized()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/login")
                .AddPutUrl("")
                .AddDeleteUrl("");
            //.AddDeleteUrl("/logout");
        }

        public static RestUrl GetLogout()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/logout")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetTokenLifetime()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/tokenlifetime")
                .AddPostUrl("")
                .AddPutUrl("/tokenlifetime")
                .AddDeleteUrl("");
        }
        //  <<<SERHII
        public static RestUrl UserItem()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item")
                .AddPostUrl("/item")
                .AddPutUrl("/item")
                .AddDeleteUrl("/item");
        }

        public static RestUrl GetUserItems()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item/user")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetItem()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetALLItems()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/items")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetALLItemsIndexes()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/itemindexes")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }
        //  SERHII>>>

        public static RestUrl GetUser()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/user")
                .AddPostUrl("/user")
                .AddPutUrl("/user")
                .AddDeleteUrl("/user");
        }
    }
}
