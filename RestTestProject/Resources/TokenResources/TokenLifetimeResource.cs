﻿using RestSharp;
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
    public class TokenLifetimeResource : ARestCrud<SimpleEntity>
    {
        public TokenLifetimeResource() : base(RestUrlRepository.GetTokenLifetime())
        {
        }

        public override IRestResponse HttpPostAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            ThrowException(RestUrlKeys.POST.ToString());
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