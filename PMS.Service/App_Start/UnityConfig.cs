using Microsoft.Practices.Unity;
using PMS.Common;
using PMS.Common.Patterns.Dependncy;
using System.Web.Http;
using Unity.WebApi;
using PMS.Service.Helpers;

namespace PMS.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

            container.RegisterType<IMongo, Mongo>(new HierarchicalLifetimeManager());

            container.RegisterType<PMSContext>(new PerHttpRequestLifetime());

            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}