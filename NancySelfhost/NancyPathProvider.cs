using Nancy;
using System;
using System.IO;

namespace NancySelfHost
{
    class NancyPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return Startup.IsDebug() ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")
                : AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
