using Microsoft.Practices.Unity;
using RideshareAdmin.Services;
using System.Web.Http;
using Unity.WebApi;

namespace RideshareAdmin.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICoordinateService, CoordinateService>();
            container.RegisterType<IRidehistoriesService, RidehistoriesService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}