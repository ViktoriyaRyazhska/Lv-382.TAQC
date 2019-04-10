using RestTestProject.Data;
using RestTestProject.Entity;
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

        public UserService(IUser user) : base()
        {
            this.user = user;
        }

        public GuestService Logout()
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", user.Name);
            SimpleEntity simpleEntity = authorizedResource.HttpDeleteAsObject(null, null, bodyParameters);
            if (simpleEntity.content.ToLower().Equals("true"))
            {
                user.Token = string.Empty;
            }
            return new GuestService();
        }
    }
}
