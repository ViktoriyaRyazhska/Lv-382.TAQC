using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Services;

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
