using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Mvc5Resolver = Unity.Mvc5.UnityDependencyResolver;
using ApiResolver = Unity.WebApi.UnityDependencyResolver;
using AirBench.Data.Repositories;
using AirBench.Data;

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
            container.RegisterType<IBenchContext, BenchContext>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IBenchRepository, BenchRepository>();
            container.RegisterType<IReviewRepository, ReviewRepository>();

            DependencyResolver.SetResolver(new Mvc5Resolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new ApiResolver(container);
        }
    }
}