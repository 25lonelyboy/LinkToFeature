using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LinkToFeature.Core.Infrastructure
{
    public interface IDenpendencyRegister
    {
        void RegisterTypes(IUnityContainer container);
    }
}
