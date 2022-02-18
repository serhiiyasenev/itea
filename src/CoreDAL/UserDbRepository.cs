using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDAL
{
    public class UserDbRepository : IUserRepository
    {
        private readonly EfCoreContext _dbContext;

        public UserDbRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(UserDto user)
        {
            _dbContext.Add(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _dbContext.Users;
        }

        public UserDto GetUserById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserDto RemoveUserById(Guid id)
        {
            var dbUser = GetUserById(id);

            if (dbUser != null)
            {
                var index = _dbContext.Users.ToList().IndexOf(dbUser);
                _dbContext.Remove(index);
                return dbUser;
            }

            return null;
        }

        public UserDto UpdateUserById(UserDto user)
        {
            var dbUser = GetUserById(user.Id);

            if (dbUser != null)
            {
                var index = _dbContext.Users.ToList().IndexOf(dbUser);
                _dbContext.Users.ToList()[index] = user;
                return dbUser;
            }

            return null;
        }
    }
}
