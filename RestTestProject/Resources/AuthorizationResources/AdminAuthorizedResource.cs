using RestSharp;
using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Rules;

namespace RestTestProject.Resources
{
    public class AdminAuthorizedResource : ARestCrud<SimpleEntity>
    {
        public AdminAuthorizedResource() : base(RestUrlRepository.GetAdminAuthorized())
        {
        }

        public override IRestResponse HttpPutAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            ThrowException(RestUrlKeys.PUT.ToString());
            return null;
        }

        public override IRestResponse HttpDeleteAsResponse(RestParameters urlParameters,
            RestParameters pathVariables, RestParameters bodyParameters)
        {
            ThrowException(RestUrlKeys.DELETE.ToString());
            return null;
        }

    }
}
