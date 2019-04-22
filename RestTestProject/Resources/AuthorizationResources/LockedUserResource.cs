using RestSharp;
using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Rules;

namespace RestTestProject.Resources.AuthorizationResources
{
    class LockedUserResource : ARestCrud<SimpleEntity>
    {
        public LockedUserResource() : base(RestUrlRepository.LockedUsers())
        { }

        public override IRestResponse HttpDeleteAsResponse(RestParameters urlParameters, RestParameters pathVariables, RestParameters bodyParameters)
        {
            ThrowException(RestUrlKeys.DELETE.ToString());
            return null;
        }
    }
}

