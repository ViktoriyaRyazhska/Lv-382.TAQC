using RestSharp;
using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Resources
{
    public class UnsuccessfulLoginMessageResource : ARestCrud<SimpleEntity>
    {
        public UnsuccessfulLoginMessageResource() : base(RestUrlRepository.GetUnsuccessfulLoginMessage())
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
