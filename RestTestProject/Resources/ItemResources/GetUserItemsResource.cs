﻿using RestSharp;
using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Rules;

namespace RestTestProject.Resources
{
    public class GetUserItemsResource : ARestCrud<SimpleEntity>
    {
        public GetUserItemsResource() : base(RestUrlRepository.GetUserItems())
        {
        }

        public override IRestResponse HttpPostAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            ThrowException(RestUrlKeys.POST.ToString());
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
