using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Server
{
    public class UserRepository
    {
        private List<User> users;
        public List<User> Users => users;

        public UserRepository()
        {
            this.users = new List<User>();
        }

        public User AddUser(User user)
        {
            this.users.Add(user);
            return user;
        }

        public void RemoveUser(User user)
        {
            this.users.Remove(user);
        }

        public bool Exists(User user)
        {
            return this.users.Any(x => x.Id == user.Id);
        }
    }

}
