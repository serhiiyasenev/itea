using CoreBL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBL.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(Guid id);

        Task<User> UpdateUserById(Guid id, User user);

        Task<int> RemoveUserById(Guid id);
    }
}
