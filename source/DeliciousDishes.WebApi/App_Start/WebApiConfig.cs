using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using DeliciousDishes.WebApi.Infrastructure;

namespace DeliciousDishes.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Start clean by replacing with filter provider for global configuration.
            // For these globally added filters we need not do any ordering as filters are 
            // executed in the order they are added to the filter collection
            config.Services.Replace(typeof(IFilterProvider), new ConfigurationFilterProvider());

            // Custom action filter provider which does ordering
            config.Services.Add(typeof(IFilterProvider), new OrderedFilterProvider());
        }
    }
}
