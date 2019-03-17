using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;

//程序集标签，程序启动的时候会在所有程序集中查找此标签，如有此标签，则会在Global.asax中的Application_Start方法前执行此方法
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LinkToFeature.Web.UnityMvcActivator), nameof(LinkToFeature.Web.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(LinkToFeature.Web.UnityMvcActivator), nameof(LinkToFeature.Web.UnityMvcActivator.Shutdown))]

namespace LinkToFeature.Web
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}