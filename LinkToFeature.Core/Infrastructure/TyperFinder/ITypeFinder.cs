using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkToFeature.Core.Infrastructure
{
    public interface ITypeFinder
    {
        IList<Assembly> Assemblies { get; }

        IList<Type> Types { get; }

        /// <summary>
        /// 获取程序集中实现了某接口的所有类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<Type> GetAllImpl<T>() where T : class;

        /// <summary>
        /// 获取指定类型集合中实现某接口的所有类（不包含抽象类）
        /// </summary>
        /// <param name="interfaceType">接口</param>
        /// <param name="types">指定类型集合，可为空，为空则为程序集中所有类型</param>
        /// <returns></returns>
        IList<Type> GetAllImpl(Type interfaceType, IList<Type> types = null);

        /// <summary>
        /// 获取程序集中实现了某接口的所有类的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<T> GetAllImplInstance<T>() where T : class;

        /// <summary>
        /// 获取指定类型集合中某基类的所有继承类（不包含抽象类）
        /// </summary>
        /// <typeparam name="T">基类</typeparam>
        /// <param name="types">指定类型集合，可为空，为空则为程序集中所有类型</param>
        /// <returns></returns>
        IList<Type> GetAllSubType<T>(IList<Type> types = null);

        /// <summary>
        /// 获取指定类型集合中某基类的所有继承类（不包含抽象类）
        /// </summary>
        /// <param name="baseType">基类</param>
        /// <param name="types">指定类型集合，可为空，为空则为程序集中所有类型</param>
        /// <returns></returns>
        IList<Type> GetAllSubType(Type baseType, IList<Type> types = null);

        /// <summary>
        /// 获取指定类型集合中某基类的所有继承类的实例（不包含抽象类）
        /// </summary>
        /// <param name="baseType"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IList<T> GetAllSubTypeInstance<T>(IList<Type> types = null) where T : class, new();
    }
}
