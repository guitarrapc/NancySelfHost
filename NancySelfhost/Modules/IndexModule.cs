using Nancy;
using System.IO;

namespace NancySelfHost.Modules
{
    /// <summary>
    /// Index Pageに関するModuleです
    /// </summary>
    public class IndexModule : NancyModule
    {
        /// <summary>
        /// Index Pageを返却します。
        /// </summary>
        public IndexModule() : base("/")
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}
