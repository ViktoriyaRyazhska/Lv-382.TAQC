﻿using RestTestProject.Data;
using RestTestProject.Data.RequestData;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;
using System;
using System.Collections.Generic;

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
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.name.ToString(), userForDelete.Name);
            SimpleEntity entity = userResorce.HttpDeleteAsObject(null, null, bodyParameters);
            return entity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UpdateTokenlifetime(Lifetime lifetime)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.time.ToString(), lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        public bool UpdateCoolDowntime(CoolDowntime cooldowntime)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token)
                .AddParameters(RequestParametersKeys.time.ToString(), cooldowntime.Time);
            SimpleEntity simpleEntity = coolDownTimeResource.HttpPutAsObject(null, null, bodyParameters);
            return simpleEntity.content.ToLower().Equals(true.ToString().ToLower());
        }

        //Roman TODO
        public SimpleEntity GetLoginedAdmins()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = loginedAdminsResourse.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetLoginedUsers()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = loginedUsersResourse.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public SimpleEntity GetAliveTockens()
        {
            RestParameters urlParameters = new RestParameters()
               .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            SimpleEntity simpleEntity = aliveTockensResource.HttpGetAsObject(urlParameters, null);
            return simpleEntity;
        }

        public ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.index.ToString(), itemTemplate.Index)
                .AddParameters(RequestParametersKeys.name.ToString(), userWithItem.Name);
            SimpleEntity simpleEntity = getUserItemResource.HttpGetAsObject(urlParameters, pathParameters);
            Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        public List<string> GetUserItems(IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.token.ToString(), user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters(RequestParametersKeys.name.ToString(), userWithItem.Name);
            SimpleEntity simpleEntity = getUserItemsResource.HttpGetAsObject(urlParameters, pathParameters);
            Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            return new List<string>(simpleEntity.content.Split('\n'));
        }
        
    }
}
