using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using SampleSmartContractCallApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SampleSmartContractCallApp.Service
{
    public class CommonAPIRequestService
    {
        private readonly ILogger<APIRequestResponse> logger;
        public CommonAPIRequestService()
        {

        }
        public async Task<APIRequestResponse> GetRequestAsync(string apiendpoint, string path, string query = null)
        {           
            var restClient = new RestClient(BuildUri(apiendpoint, path, query));
            var restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = await restClient.ExecuteAsync(restRequest).ConfigureAwait(false);
            var isSuccess = restResponse.StatusCode.Equals(HttpStatusCode.OK);
            return new APIRequestResponse
            {
                IsSuccess = isSuccess,
                Content = JsonConvert.DeserializeObject(restResponse.Content)
            };
        }

        public async Task<APIRequestResponse> PostRequestAsync(string endpoint, string path, object body, Method method = Method.POST)
        {
            using (var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(5)))
            {
                var restClient = new RestClient(BuildUri(endpoint, path));
                var restRequest = new RestRequest(method);
                restRequest.AddHeader("Content-type", "application/json");
                restRequest.AddJsonBody(body);
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest, cancellationToken.Token).ConfigureAwait(false);

                var isSuccess = restResponse.StatusCode.Equals(HttpStatusCode.OK);

                return new APIRequestResponse
                {
                    IsSuccess = isSuccess,
                    Content = JsonConvert.DeserializeObject(restResponse.Content)
                };
            }
        }
        public static Uri BuildUri(string endpoint, string path = null, string query = null) => new UriBuilder(endpoint)
        {
            Path = path,
            Query = query
        }.Uri;
    }
}
