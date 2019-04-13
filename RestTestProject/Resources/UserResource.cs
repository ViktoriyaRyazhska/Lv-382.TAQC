using RestTestProject.Data;
using RestTestProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Resources
{
    public class UserResource : ARestCrud<SimpleEntity>
    {
        public UserResource() : base(RestUrlRepository.GetUser())
        {
        }
    }
}
