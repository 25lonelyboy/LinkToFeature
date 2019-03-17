using LinkToFeature.Core.Entity;
using LinkToFeature.Data.IRepository;
using LinkToFeature.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkToFeature.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IList<User> GetUsers()
        {
            return userRepository.GetUsers();
        }
    }
}
