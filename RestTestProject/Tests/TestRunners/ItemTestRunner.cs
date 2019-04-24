using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Tests
{
    public class ItemTestRunner : BaseTestRunner
    {
        protected IUser simpleUser = UserRepository.Get().ExistingUser();

        [OneTimeSetUp]
        public void BeforeItemTests()
        {
            userService = new GuestService().SuccessfulUserLogin(simpleUser);
        }
    }
}
