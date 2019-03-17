using FluentValidation;
using LinkToFeature.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace LinkToFeature.Web.Validator
{
    /// <summary>
    /// 不懂
    /// 验证规则注入到哪里？
    /// 怎么替换掉原有的验证器？
    /// 怎么读取设置的验证失败提示？
    /// </summary>
    public class ValidatorRegister : IDenpendencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            var validatorTypes = this.GetType().Assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)));
            foreach (var validatorType in validatorTypes)
            {
                //各个参数是什么意思?
                container.RegisterType(typeof(IValidator<>), validatorType, validatorType.BaseType.GetGenericArguments().First().FullName, new ContainerControlledLifetimeManager());
            }
        }
    }
}