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
        protected AuthorizedResource authorizedResource;
        protected TokenLifetimeResource tokenLifetimeResource;

        public GuestService()
        {
            authorizedResource = new AuthorizedResource();
            tokenLifetimeResource = new TokenLifetimeResource();
        }

        public Lifetime GetCurrentTokenlifetime()
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

        public void SuccessfulUserLogin(IUser user)
        {
            // TODO
        }

        public AdminService SuccessfulAdminLogin(IUser adminUser)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("name", adminUser.Name)
                .AddParameters("password", adminUser.Password);
            SimpleEntity simpleEntity = authorizedResource.HttpPostAsObject(null, null, bodyParameters);
            adminUser.Token = simpleEntity.content;
            return new AdminService(adminUser);
        }

    }
}
