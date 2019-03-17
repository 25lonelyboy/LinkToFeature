using LinkToFeature.Core.Infrastructure;
using LinkToFeature.Data.Denpendency;
using LinkToFeature.Service.Denpendency;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using Unity;

namespace LinkToFeature.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //使用xml配置进行注入
            //UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //section.Configure(container, "defualt");

            //通过反射的方式,得到Register进行注入
            var typeFinder = new CommonTypeFinder();
            var registers = typeFinder.GetAllImplInstance<IDenpendencyRegister>();
            foreach (var register in registers)
            {
                register.RegisterTypes(container);
            }
        }
    }
}