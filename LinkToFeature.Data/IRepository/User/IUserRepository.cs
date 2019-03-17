using LinkToFeature.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkToFeature.Data.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
