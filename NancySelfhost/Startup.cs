using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using System.Web.Http.ValueProviders;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;

[assembly: OwinStartup(typeof(NancySelfHost.Startup))]
namespace NancySelfHost
{
    public class Startup
    {
        public string ServiceName { get; set; }
        private static IDisposable _application;

        public Startup(string serviceName)
        {
            this.ServiceName = serviceName;
        }

        /// <summary>
        /// TopShelfからの開始用
        /// </summary>
        public void Start()
        {
            string uri = string.Format("http://localhost:8080/");
            _application = WebApp.Start<Startup>(uri); ;
        }

        /// <summary>
        /// TopShelfからの停止用
        /// </summary>
        public void Stop()
        {
            _application?.Dispose();
        }

        public void Configuration(IAppBuilder application)
        {
            // API 用の読み込みだよ
            UseWebApi(application);

            // Nancy つかうぉ
            application.UseNancy(options => options.Bootstrapper = new NancyBootstrapper());
        }

        /// <summary>
        /// Provide API Action
        /// </summary>
        /// <param name="application"></param>
        private static void UseWebApi(IAppBuilder application)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            application.UseWebApi(config);
        }

        /// <summary>
        /// Check Directory is exist or not
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool IsDirectoryExist(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Provide Current Build Status is Debug or not
        /// </summary>
        /// <returns></returns>
        public static bool IsDebug()
        {

#if DEBUG
            return true;
#endif
            return false;

        }
    }
}
