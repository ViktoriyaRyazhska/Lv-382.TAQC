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
        protected LoginedAdminsResourse loginedAdminsResourse;
        protected LoginedUsersResourse loginedUsersResourse;
        protected AliveTockensResource aliveTockensResource;

        public AdminService(IUser adminUser) : base(adminUser)
        {
            loginedAdminsResourse = new LoginedAdminsResourse();
            loginedUsersResourse = new LoginedUsersResourse();
            aliveTockensResource = new AliveTockensResource();
        }

        public SimpleEntity RemoveUser(string userName)
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("name", userName);
            return userResorce.HttpDeleteAsObject(null,null, bodyParameters);
        }

        public bool CreateUser(string newUserName, string newUserPassword, string newUserRights)
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters("token", user.Token)
               .AddParameters("name", newUserName)
               .AddParameters("password", newUserPassword)
               .AddParameters("rights", newUserRights);
            SimpleEntity entity = userResorce.HttpPostAsObject(null, null, bodyParameters);
            //TODO
            return entity.content.ToLower().Equals(true.ToString().ToLower());
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

        public bool UpdateCoolDowntime(CoolDowntime cooldowntime)
        {
            //Console.WriteLine("lifetime = " + lifetime.Time + "   User = " + user);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", cooldowntime.Time);
            SimpleEntity simpleEntity = coolDownTimeResource.HttpPutAsObject(null, null, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        //Roman TODO
        public SimpleEntity GetLoginedAdmins()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = loginedAdminsResourse.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetLoginedUsers()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = loginedUsersResourse.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetAliveTockens()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters("token", user.Token);
            SimpleEntity simpleEntity = aliveTockensResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }
    }
}
