using NUnit.Framework;
using RestTestProject.Data;
using RestTestProject.Resources;
using RestTestProject.Services;

namespace RestTestProject.Tests
{
    [TestFixture]
    public class LifeTimeTest
    {
        [Test]
        public void CheckTimeChange()
        {
            string changedLifetime = new GuestService().SuccessfulAdminLogin(UserRepository.Get().Admin()).UpdateTokenlifetime(new Lifetime("800000"));
            Assert.AreEqual("800000", changedLifetime, "Time Error");
        }
    }
}
