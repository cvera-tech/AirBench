using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Mvc5Resolver = Unity.Mvc5.UnityDependencyResolver;
using ApiResolver = Unity.WebApi.UnityDependencyResolver;
using AirBench.Data.Repositories;

namespace AirBench
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IBenchRepository, BenchRepository>();

            DependencyResolver.SetResolver(new Mvc5Resolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new ApiResolver(container);
        }
    }
}