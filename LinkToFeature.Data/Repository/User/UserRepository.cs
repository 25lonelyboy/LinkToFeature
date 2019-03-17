using LinkToFeature.Core.Entity;
using LinkToFeature.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkToFeature.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User() { ID = 1, Name = "user1", Age = 22, Sex = true });
            users.Add(new User() { ID = 2, Name = "user2", Age = 23, Sex = false });
            return users;
        }
    }
}
