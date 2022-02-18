using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDAL
{
    public interface IUserRepository
    {
        Task<UserDto> Add(UserDto user);

        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDto> GetById(Guid id);

        Task<UserDto> UpdateById(Guid id, UserDto user);

        Task<Guid?> RemoveById(Guid id);
    }
}
