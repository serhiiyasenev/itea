using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class UserListRepository : IUserRepository
    {
        static readonly List<UserDto> Users;

        static UserListRepository()
        {
            Users = new List<UserDto>();
        }

        public async Task<UserDto> Add(UserDto user)
        {
            user.Id = Guid.NewGuid();
            Users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await Task.FromResult(Users);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            return await Task.FromResult(Users.FirstOrDefault(x => x.Id == id));
        }

        public async Task<UserDto> UpdateById(Guid id, UserDto user)
        {
            var listUser = await GetById(id);

            if (listUser != null)
            {
                user.Id = id;
                var index = Users.IndexOf(listUser);
                Users[index] = user;
                return await Task.FromResult(Users[index]);
            }

            return await Task.FromResult((UserDto)null);
        }

        public async Task<int> RemoveById(Guid id)
        {
            var user = await GetById(id);

            if (user != null)
            {
                Users.Remove(user);
                return await Task.FromResult(0);
            }

            return await Task.FromResult(1);
        }
    }
}
