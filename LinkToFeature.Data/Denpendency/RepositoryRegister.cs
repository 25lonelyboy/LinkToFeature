using LinkToFeature.Core.Infrastructure;
using LinkToFeature.Data.IRepository;
using LinkToFeature.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LinkToFeature.Data.Denpendency
{
    public class RepositoryRegister : IDenpendencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
