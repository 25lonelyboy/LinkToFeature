using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkToFeature.Core.Infrastructure
{
    /// <summary>
    /// 低配版类型查找器,需要在web.config中配置程序集名称
    /// </summary>
    public class CommonTypeFinder : ITypeFinder
    {
        public IList<Assembly> Assemblies
        {
            get
            {
                var assemblies = new List<Assembly>();
                if (!string.IsNullOrEmpty(SysConfig.Assemblies))
                {
                    foreach (var assembly in SysConfig.Assemblies.Split(','))
                    {
                        assemblies.Add(Assembly.Load(assembly));
                    }
                }
                return assemblies;
            }
        }

        public IList<Type> Types
        {
            get
            {
                var types = new List<Type>();
                foreach (var assembly in Assemblies)
                {
                    types.AddRange(assembly.GetTypes().Where(t => t.IsPublic));
                }
                return types;
            }
        }

        public IList<Type> GetAllImpl<T>() where T : class
        {
            return GetAllImpl(typeof(T));
        }

        public IList<Type> GetAllImpl(Type interfaceType, IList<Type> types = null)
        {
            if (types == null)
            {
                types = Types;
            }
            var result = new List<Type>();
            foreach (var type in types)
            {
                if (type.GetInterface(interfaceType.Name, true) != null && !type.IsAbstract)
                {
                    result.Add(type);
                }
            }
            return result;
        }

        public IList<T> GetAllImplInstance<T>() where T : class
        {
            var result = new List<T>();
            var types = GetAllImpl<T>();
            foreach (var type in types)
            {
                result.Add(Activator.CreateInstance(type) as T);
            }
            return result;
        }

        public IList<Type> GetAllSubType<T>(IList<Type> types = null)
        {
            return GetAllSubType(typeof(T), types);
        }

        public IList<Type> GetAllSubType(Type baseType, IList<Type> types = null)
        {
            if (types == null)
            {
                types = Types;
            }
            var result = new List<Type>();
            foreach (var type in types)
            {
                if ((type.IsSubclassOf(baseType) || type == baseType) && !type.IsAbstract)
                {
                    result.Add(type);
                }
            }
            return result;
        }

        public IList<T> GetAllSubTypeInstance<T>(IList<Type> types = null) where T : class, new()
        {
            var alltypes = GetAllSubType<T>(types);
            var result = new List<T>();
            foreach (var type in alltypes)
            {
                result.Add(Activator.CreateInstance(type) as T);
            }
            return result;
        }
    }
}
