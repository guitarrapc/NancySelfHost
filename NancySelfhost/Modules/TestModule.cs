using Nancy;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace NancySelfHost.Modules
{
    /// <summary>
    /// Index Pageに関するModuleです
    /// </summary>
    public class TestAPIModule : NancyModule
    {
        /// <summary>
        /// Index Pageを返却します。
        /// </summary>
        public TestAPIModule() : base("/api")
        {
            var hostName = System.Net.Dns.GetHostName();
            Get["/test"] = parameters =>
            {
                var model = new
                {
                    HostName = hostName,
                    IPAddress = Dns.GetHostAddresses(hostName).FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork).ToString()
                };
                return View["test", model];
            };
        }
    }
}
