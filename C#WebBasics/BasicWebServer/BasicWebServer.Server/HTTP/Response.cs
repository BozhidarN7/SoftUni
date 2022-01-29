using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;

            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public CookieCollection Cookies { get; } = new CookieCollection();

        public string Body { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)StatusCode} {StatusCode}");

            foreach (Header header in Headers)
            {
                result.AppendLine(header.ToString());
            }

            foreach (Cookie cookie in Cookies)
            {
                result.AppendLine($"{Header.SetCookie}: {cookie}");
            }

                result.AppendLine();

            if (!string.IsNullOrEmpty(Body))
            {
                result.AppendLine(Body);
            }

            return result.ToString();
        }
    }
}
