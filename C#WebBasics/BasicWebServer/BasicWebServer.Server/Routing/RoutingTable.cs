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
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable()
        {
            routes = new()
            {
                [Method.Get] = new(),
                [Method.Post] = new(),
                [Method.Put] = new(),
                [Method.Delete] = new(),
            };
        }

        public IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            routes[method][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFunction)
            => Map(Method.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction)
            => Map(Method.Post, path, responseFunction);

        public Response MatchRequest(Request request)
        {
            Method requestMethod = request.Method;
            string requestUrl = request.Url;

            if (!routes.ContainsKey(requestMethod) || !routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            Func<Request, Response> responseFunction = routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
