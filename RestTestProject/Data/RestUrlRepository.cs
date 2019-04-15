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
                .AddGetUrl("/login/users") //Ask Jaroslav
                .AddPostUrl("/login")
                .AddPutUrl("")
                .AddDeleteUrl("");
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
        //Roman
        public static RestUrl UnsuccessfulLogin()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("")
                .AddPostUrl("/login")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetCoolDownTime()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/cooldowntime")
                .AddPostUrl("")
                .AddPutUrl("/cooldowntime")
                .AddDeleteUrl("");
        }

        public static RestUrl GetLoginedAdmins()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/login/admins")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetLoginedUsers()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/login/users")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetAliveTockens()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/login/tockens")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }
        //////////////////////////////////////
        //  <<<SERHII
        public static RestUrl ManageItem()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item/111")
                .AddPostUrl("/item/111")
                .AddPutUrl("/item/111")
                .AddDeleteUrl("/item/111");
        }
        //public static RestUrl ManageItem()
        //{
        //    return new RestUrl()
        //        .AddBaseUrl(Server)
        //        .AddGetUrl("/item/")
        //        .AddPostUrl("/item/")
        //        .AddPutUrl("/item/")
        //        .AddDeleteUrl("/item/");
        //}

        public static RestUrl GetUserItems()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item/user/akimatc")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetUserItem()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/item/user/OKonokhtc")
                //.AddGetUrl("/item/users")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetAllItems()
        {
            return new RestUrl()
                .AddBaseUrl(Server)
                .AddGetUrl("/items") 
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetAllItemsIndexes()
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
