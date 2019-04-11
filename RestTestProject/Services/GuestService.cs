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
    public class GuestService
    {
        protected AdminAuthorizedResource adminAuthorizedResource;
        protected UserAuthorizedResource userAuthorizedResource;
        protected TokenLifetimeResource tokenLifetimeResource;

        public GuestService()
        {
            adminAuthorizedResource = new AdminAuthorizedResource();
            userAuthorizedResource = new UserAuthorizedResource();
            tokenLifetimeResource = new TokenLifetimeResource();
        }

        public Lifetime GetCurrentTokenLifetime()
        {
            Lifetime lifetime = new Lifetime();
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpGetAsObject(null, null);
            lifetime.Time = simpleEntity.content;
            return lifetime;
        }

        public void UnsuccessfulLogin(IUser user)
        {
            // TODO
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

    }
}
