using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes;

        public RoutingTable()
        {
            routes = new()
            {
                [Method.Get] = new Dictionary<string, Response>(),
                [Method.Post] = new Dictionary<string, Response>(),
                [Method.Put] = new Dictionary<string, Response>(),
                [Method.Delete] = new Dictionary<string, Response>(),
            };
        }

        public IRoutingTable Map(string url, Method method, Response response)
        {
            return method switch
            {
                Method.Get => MapGet(url, response),
                Method.Post => MapPost(url, response),
                _ => throw new InvalidOperationException($"Method '{method}' is not supported.")
            };
        }

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.Get][url] = response;

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.Post][url] = response;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            Method requestMethod = request.Method;
            string requestUrl = request.Url;

            if (!routes.ContainsKey(requestMethod) || !routes[requestMethod].ContainsKey(requestUrl)) {
                return new NotFoundResponse();
            }

            return routes[requestMethod][requestUrl];
        }
    }
}
