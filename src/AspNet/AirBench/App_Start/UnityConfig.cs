using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Mvc5Resolver = Unity.Mvc5.UnityDependencyResolver;
using ApiResolver = Unity.WebApi.UnityDependencyResolver;
using AirBench.Data.Repositories;
using AirBench.Data;
using AirBench.Api.Repositories;

namespace AirBench
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // MVC dependencies
            container.RegisterType<IBenchContext, BenchContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IBenchRepository, BenchRepository>();
            container.RegisterType<IReviewRepository, ReviewRepository>();

            // Web API dependencies
            container.RegisterType<IBenchApiRepository, BenchApiRepository>();
            container.RegisterType<IReviewApiRepository, ReviewApiRepository>();

            DependencyResolver.SetResolver(new Mvc5Resolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new ApiResolver(container);
        }
    }
}