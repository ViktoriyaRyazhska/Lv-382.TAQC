using RestTestProject.Data;
using RestTestProject.Entity;

namespace RestTestProject.Resources
{
    public class UserResource : ARestCrud<SimpleEntity>
    {
        public UserResource() : base(RestUrlRepository.GetUser())
        {
        }
    }
}
