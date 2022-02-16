using CoreDAL.Entries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDAL
{
    public class UserListRepository : IUserRepository
    {
        private static List<UserDto> _users;

        public void Add(UserDto user)
        {
            _users.Add(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _users;
        }

        public UserDto GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public UserDto RemoveUserById(Guid id)
        {
            var dbUser = _users.FirstOrDefault(u => u.Id == id);

            if (dbUser != null)
            {
                var index = _users.IndexOf(dbUser);
                _users.RemoveAt(index);
                return dbUser;
            }

            return null;
        }

        public UserDto UpdateUserById(UserDto user)
        {
            var dbUser = GetUserById(user.Id);

            if (dbUser != null)
            {
                var index = _users.IndexOf(dbUser);
                _users[index] = user;
                return dbUser;
            }

            return null;
        }
    }
}
