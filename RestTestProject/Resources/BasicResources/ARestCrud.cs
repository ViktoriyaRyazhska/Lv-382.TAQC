using RestSharp;
using RestTestProject.Data;
using RestTestProject.Rules;
using RestTestProject.Tools;
using System;
using System.Collections.Generic;


namespace RestTestProject.Resources
{
    public abstract class ARestCrud<T>
    {
        //----------------------------Error message--------------------------------
        private const string NOT_SUPPORT_MESSAGE = "Method {0} not Support for {1} Resource";
        //---------------------------------------------------------------------------
        private const string URL_PARAMETERS_SEPARATOR = "?";
        private const string NEXT_PARAMETERS_SEPARATOR = "&";
        private const string KEY_VALUE_SEPARATOR = "=";
        //
        private RestUrl restUrl;
        private RestClient client;
        private Dictionary<RestUrlKeys, RestSharp.Method> dictionaryMethods;

        public ARestCrud(RestUrl restUrl)
        {
            this.restUrl = restUrl;
            client = new RestClient(restUrl.ReadBaseUrl());
            InitDictionaryMethods();
        }

        private void InitDictionaryMethods()
        {
            dictionaryMethods = new Dictionary<RestUrlKeys, RestSharp.Method>();
            dictionaryMethods.Add(RestUrlKeys.GET, Method.GET);
            dictionaryMethods.Add(RestUrlKeys.POST, Method.POST);
            dictionaryMethods.Add(RestUrlKeys.PUT, Method.PUT);
            dictionaryMethods.Add(RestUrlKeys.DELETE, Method.DELETE);
        }

        private string PrepareUrlParameters(string urlTemplate, RestParameters urlParameters)
        {
            if (urlParameters != null)
            {
                bool isFirstParameter = true;
                foreach (KeyValuePair<string, string> current in urlParameters.Parameters)
                {
                    if (isFirstParameter)
                    {
                        urlTemplate = urlTemplate + URL_PARAMETERS_SEPARATOR;
                        isFirstParameter = false;
                    }
                    else
                    {
                        urlTemplate = urlTemplate + NEXT_PARAMETERS_SEPARATOR;
                    }
                    urlTemplate = urlTemplate + current.Key + KEY_VALUE_SEPARATOR + current.Value;
                }
            }
            return urlTemplate;
        }

        private RestRequest PreparePathVariables(RestRequest request, RestParameters pathVariables)
        {
            if (pathVariables != null)
            {
                foreach (KeyValuePair<string, string> current in pathVariables.Parameters)
                {
                    request.AddUrlSegment(current.Key, current.Value);
                }
            }
            return request;
        }

        private RestRequest prepareRequestBody(RestRequest request, RestParameters bodyParameters)
        {
            if (bodyParameters != null)
            {
                foreach (KeyValuePair<string, string> current in bodyParameters.Parameters)
                {
                    request.AddParameter(current.Key, current.Value);
                }
            }
            return request;
        }

        private RestRequest CreateRestRequest(RestUrlKeys restUrlKeys, RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            string url = PrepareUrlParameters(restUrl.ReadBaseUrl() + restUrl.GetUrl(restUrlKeys), urlParameters);
            RestRequest request = new RestRequest(url, dictionaryMethods[restUrlKeys]);
            request = PreparePathVariables(request, pathVariables);
            request = prepareRequestBody(request, bodyParameters);
            return request;
        }

        private IRestResponse ExecuteRequest(RestRequest request)
        {
            return client.Execute(request);
        }

        protected void ThrowException(string message)
        {
            string resourceName = this.GetType().ToString();
            throw new Exception(string.Format(NOT_SUPPORT_MESSAGE, message, resourceName));
        }

        // Http Get - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpGetAsResponse(RestParameters urlParameters, RestParameters pathVariables)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.GET, urlParameters, pathVariables, null));
        }

        public string HttpGetAsString(RestParameters urlParameters, RestParameters pathVariables)
        {
            return HttpGetAsResponse(urlParameters, pathVariables).Content;
        }

        public T HttpGetAsObject(RestParameters urlParameters, RestParameters pathVariables)
        {
            return JsonParser.ConvertToResource<T>(HttpGetAsResponse(urlParameters, pathVariables));
        }

        // Http Post - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpPostAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.POST, urlParameters, pathVariables, bodyParameters));
        }

        public string HttpPostAsString(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return HttpPostAsResponse(urlParameters, pathVariables, bodyParameters).Content;
        }

        public T HttpPostAsObject(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return JsonParser.ConvertToResource<T>(HttpPostAsResponse(urlParameters, pathVariables, bodyParameters));
        }

        // Http Put - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpPutAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.PUT, urlParameters, pathVariables, bodyParameters));
        }

        public string HttpPutAsString(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return HttpPutAsResponse(urlParameters, pathVariables, bodyParameters).Content;
        }

        public T HttpPutAsObject(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return JsonParser.ConvertToResource<T>(HttpPutAsResponse(urlParameters, pathVariables, bodyParameters));
        }

        // Http Delete - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpDeleteAsResponse(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return ExecuteRequest(CreateRestRequest(RestUrlKeys.DELETE, urlParameters, pathVariables, bodyParameters));
        }

        public string HttpDeleteAsString(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return HttpDeleteAsResponse(urlParameters, pathVariables, bodyParameters).Content;
        }

        public T HttpDeleteAsObject(RestParameters urlParameters,
                    RestParameters pathVariables, RestParameters bodyParameters)
        {
            return JsonParser.ConvertToResource<T>(HttpDeleteAsResponse(urlParameters, pathVariables, bodyParameters));
        }

    }
}
