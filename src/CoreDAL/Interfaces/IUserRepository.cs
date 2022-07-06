using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDAL.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// Newly created user
        /// </returns>
        Task<UserDto> Add(UserDto user);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>
        /// Users collection or empty collection
        /// </returns>
        Task<IEnumerable<UserDto>> GetAll();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// User with pointed it or null if user was not found by id
        /// </returns>
        Task<UserDto> GetById(Guid id);

        /// <summary>
        /// Update user by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>
        /// Updated user or null if user was not found by id
        /// </returns>
        Task<UserDto> UpdateById(Guid id, UserDto user);

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if user was deleted successfully or 0 if user was not found by id
        /// </returns>
        Task<int> RemoveById(Guid id);
    }
}
