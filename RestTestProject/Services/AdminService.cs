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
    public class AdminService : UserService
    {
        protected UserItemResource userItemResource;

        public AdminService(IUser adminUser) : base(adminUser)
        {
            userItemResource = new UserItemResource();
        }

        public bool UpdateTokenlifetime(Lifetime lifetime)
        {
            //Console.WriteLine("lifetime = " + lifetime.Time + "   User = " + user);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index)
                .AddParameters("name", userWithItem.Name);
            SimpleEntity simpleEntity = userItemResource.HttpGetAsObject(urlParameters, pathParameters);
            //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

    }
}
