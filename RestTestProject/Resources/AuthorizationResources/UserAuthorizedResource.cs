using RestSharp;
using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Rules;

namespace RestTestProject.Resources
{
    public class UserAuthorizedResource : ARestCrud<SimpleEntity>
    {
        public UserAuthorizedResource() : base(RestUrlRepository.GetUserAuthorized())
        {
        }

        public override IRestResponse HttpGetAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables)
        {
            ThrowException(RestUrlKeys.GET.ToString());
            return null;
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
