using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkToFeature.Web.Infrastructure
{
    /// <summary>
    /// AutoMapper初始化配置类
    /// 使用静态方法的方式
    /// 需要在Global.asax中的Application_Start中调用
    /// </summary>
    public class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}