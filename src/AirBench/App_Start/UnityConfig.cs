using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Mvc5Resolver = Unity.AspNet.Mvc.UnityDependencyResolver;
using ApiResolver = Unity.AspNet.WebApi.UnityDependencyResolver;

namespace AirBench
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new Mvc5Resolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new ApiResolver(container);
        }
    }
}