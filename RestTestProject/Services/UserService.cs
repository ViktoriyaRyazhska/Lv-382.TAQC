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
        protected ItemResource itemResource;

        public UserService(IUser user) : base()
        {
            this.user = user;
            logoutResource = new LogoutResource();
            itemResource = new ItemResource();
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

        public bool AddItem(ItemTemplate itemTemplate)
        {
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("item", itemTemplate.Item);
            SimpleEntity simpleEntity = itemResource.HttpPostAsObject(null, pathParameters, bodyParameters);
            // TODO if ...
            //Console.WriteLine("\t***AddItem(): simpleEntity = " + simpleEntity);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public ItemTemplate GetItem(ItemTemplate itemTemplate)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index);
            SimpleEntity simpleEntity = itemResource.HttpGetAsObject(urlParameters, pathParameters);
            //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }
    }
}
