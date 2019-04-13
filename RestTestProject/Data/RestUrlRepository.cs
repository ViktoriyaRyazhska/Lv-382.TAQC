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
        //Roman
        public static RestUrl GetUnsuccessfulLoginMessage()
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
    }
}
