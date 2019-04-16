using RestTestProject.Data;
using RestTestProject.Data.RequestData;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;
using System;

namespace RestTestProject.Services
{
    public class AdminService : UserService
    {
        LoginedAdminsResourse loginedAdminsResourse;
        LoginedUsersResourse loginedUsersResourse;
        AliveTockensResource aliveTockensResource;
        GetUserItemResource getUserItemResource;

        public AdminService(IUser adminUser) : base(adminUser)
        {
            loginedAdminsResourse = new LoginedAdminsResourse();
            loginedUsersResourse = new LoginedUsersResourse();
            aliveTockensResource = new AliveTockensResource();
            getUserItemResource = new GetUserItemResource();
        }

        public bool CreateUser(IUser newUser)
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
               .AddParameters(RequestParametersKeys.name.ToString(), newUser.Name)
               .AddParameters(RequestParametersKeys.password.ToString(), newUser.Password)
               .AddParameters(RequestParametersKeys.rights.ToString(), newUser.Rights);
            SimpleEntity entity = userResorce.HttpPostAsObject(null, null, bodyParameters);
            return entity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool DeleteUser(IUser userForDelete)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", userForDelete.Name);
            SimpleEntity entity = userResorce.HttpDeleteAsObject(null, null, bodyParameters);
            return entity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UpdateTokenlifetime(Lifetime lifetime)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UpdateCoolDowntime(CoolDowntime cooldowntime)
        {
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

        public ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index)
                .AddParameters("name", userWithItem.Name);
            SimpleEntity simpleEntity = manageItemResource.HttpGetAsObject(urlParameters, pathParameters);
            //SimpleEntity simpleEntity = getUserItemResource.HttpGetAsObject(urlParameters, pathParameters);
            Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        //public ItemTemplate GetUserItems(ItemTemplate itemTemplate, IUser userWithItem)
        //{
        //    RestParameters urlParameters = new RestParameters()
        //        .AddParameters("token", user.Token);
        //    RestParameters pathParameters = new RestParameters()
        //        .AddParameters("name", userWithItem.Name);
        //    SimpleEntity simpleEntity = manageItemResource.HttpGetAsObject(urlParameters, pathParameters);
        //    //SimpleEntity simpleEntity = getUserItemResource.HttpGetAsObject(urlParameters, pathParameters);
        //    //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
        //    return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        //}
    }
}
