using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace DeliciousDishes.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("version")]
        public IHttpActionResult Version()
        {
            var webAssembly = this.GetType().Assembly;
            var configuration = string.Empty;

            var configurationAttribute = webAssembly.GetCustomAttributes(typeof(AssemblyConfigurationAttribute)).OfType<AssemblyConfigurationAttribute>().ToList();
            if (configurationAttribute.Any())
            {
                configuration = configurationAttribute.First().Configuration;
            }
            
            var assemblyDate = System.IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);

            return this.Json(new VersionDto
            {
                ProductVersion = webAssembly.GetName().Version.ToString(),
                Build = webAssembly.GetName().Version.Revision.ToString(CultureInfo.CurrentCulture),
                BuildDateTime = string.Format("{0:yyyyMMdd-HHmmss}", assemblyDate),
                Configuration = configuration
            });
        }
    }

    public class VersionDto
    {
        public string ProductVersion { get; set; }
        public string BuildDateTime { get; set; }
        public string Build { get; set; }
        public string Configuration { get; set; }
    }
}
