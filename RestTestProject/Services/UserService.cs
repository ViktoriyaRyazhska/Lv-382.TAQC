using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Services
{
    public class UserService : GuestService
    {
        protected IUser user;
        protected LogoutResource logoutResource;
        //
        protected ALLItemsIndexesResource allItemsIndexesResource;
        protected ALLItemsResource allItemsResource;
        protected ItemResource itemResource;
        protected UserItemResource userItemResource;
        protected UserItemsResource userItemsResource;


        public UserService(IUser user) : base()
        {
            this.user = user;
            logoutResource = new LogoutResource();
            //
            allItemsIndexesResource = new ALLItemsIndexesResource();
            allItemsResource = new ALLItemsResource();
            itemResource = new ItemResource();
            userItemResource = new UserItemResource();
            userItemsResource = new UserItemsResource();
        }

        public bool IsLoggined()
        {
            return (user != null) && (!string.IsNullOrEmpty(user.Token));
        }

        public GuestService Logout()
        {
            //Console.WriteLine("\t***Logout(): user = " + user);
            //
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", user.Name);
            SimpleEntity simpleEntity = logoutResource.HttpPostAsObject(null, null, bodyParameters);
            //Console.WriteLine("\t***Logout(): simpleEntity = " + simpleEntity);
            if (simpleEntity.content.ToLower().Equals(true.ToString().ToLower()))
            {
                user.Token = string.Empty;
            }
            //Console.WriteLine("\t***Logout(): DONE ");
            return new GuestService();
        }
        
    }
}
