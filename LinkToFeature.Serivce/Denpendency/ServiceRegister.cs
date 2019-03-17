using LinkToFeature.Core.Infrastructure;
using LinkToFeature.Service.IService;
using LinkToFeature.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LinkToFeature.Service.Denpendency
{
    public class ServiceRegister : IDenpendencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>();
        }
    }
}
