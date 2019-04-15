﻿using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Resources;
using RestTestProject.Rules;

namespace RestTestProject.Services
{
    public class GuestService
    {
        private string UNSUCCESSFUL_LOGIN_ERROR_MESSAGE;
        protected AdminAuthorizedResource adminAuthorizedResource;
        protected UserAuthorizedResource userAuthorizedResource;
        protected TokenLifetimeResource tokenLifetimeResource;
        //
        protected CoolDownTimeResource coolDownTimeResource;

        public GuestService()
        {
            UNSUCCESSFUL_LOGIN_ERROR_MESSAGE = string.Empty;
            adminAuthorizedResource = new AdminAuthorizedResource();
            userAuthorizedResource = new UserAuthorizedResource();
            tokenLifetimeResource = new TokenLifetimeResource();
            coolDownTimeResource = new CoolDownTimeResource();
        }

        public Lifetime GetCurrentTokenLifetime()
        {
            Lifetime lifetime = new Lifetime();
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpGetAsObject(null, null);
            lifetime.Time = simpleEntity.content;
            return lifetime;
        }

        public CoolDowntime GetCurrentCoolDowntime()
        {
            CoolDowntime cooldowntime = new CoolDowntime();
            SimpleEntity simpleEntity = coolDownTimeResource.HttpGetAsObject(null, null);
            cooldowntime.Time = simpleEntity.content;
            return cooldowntime;
        }

        //--------------Login functionality----------------------------
        public string UnsuccessfulUserLogin(IUser user)  
        {
            RestParameters bodyParameters = new RestParameters()
               .AddParameters("name", user.Name)
               .AddParameters("password", user.Password);
            SimpleEntity simpleEntity = userAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            return simpleEntity.content;
        }
       
        public UserService SuccessfulUserLogin(IUser user)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("name", user.Name)
                .AddParameters("password", user.Password);
            SimpleEntity simpleEntity = userAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            user.Token = simpleEntity.content;
            return new UserService(user);
        }

        public AdminService SuccessfulAdminLogin(IUser adminUser)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("name", adminUser.Name)
                .AddParameters("password", adminUser.Password);
            SimpleEntity simpleEntity = adminAuthorizedResource.HttpPostAsObject(null, null, bodyParameters);
            adminUser.Token = simpleEntity.content;
            return new AdminService(adminUser);
        }
        ////-----------------------------------------------------------
    }
}
