using BasicWebServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Session
    {
        public const string SessionCookieName = "MyWebServerSID";
        public const string SessionCurrentDateKey = "CurrentDate";
        public const string SessionUserKey = "AuthenticatedUserId";

        private Dictionary<string, string> data;

        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            Id = id;

            data = new Dictionary<string, string>();
        }

        public string Id { get; init; }

        public string this[string key]
        {
            get => data[key];
            set => data[key] = value;
        }

        public bool ContainsKey(string key) => data.ContainsKey(key);

        public void Clear() => data.Clear();
    }
}
