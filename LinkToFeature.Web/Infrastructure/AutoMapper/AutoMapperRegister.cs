using AutoMapper;
using LinkToFeature.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace LinkToFeature.Web.Infrastructure
{
    /// <summary>
    /// AutoMapper初始化配置类
    /// 使用依赖注入的方式，通过反射设置映射配置
    /// </summary>
    public class AutoMapperRegister : IDenpendencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            var profileTypes = this.GetType().Assembly.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t));
            var profileInstances = profileTypes.Select(t => (Profile)Activator.CreateInstance(t));
            //设置映射配置
            //MapperConfiguration configuration = new MapperConfiguration(cfg => profileInstances.ToList().ForEach(p => cfg.AddProfile(p)));
            //实例注入，单例吗模式，项目中其他地方通过Unity注入拿到的MapperConfiguration、IMapper都是同一个对象
            MapperConfiguration configuration = new MapperConfiguration(cfg => profileInstances.ToList());
            container.RegisterInstance<MapperConfiguration>(configuration);
            container.RegisterInstance<IMapper>(configuration.CreateMapper());
        }
    }
}