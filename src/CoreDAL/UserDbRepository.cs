using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class UserDbRepository : IUserRepository
    {
        private readonly EfCoreContext _dbContext;

        public UserDbRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Add(UserDto user)
        {
            user.Id = Guid.NewGuid();
            var userEntity = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return userEntity.Entity;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserDto> GetById(Guid id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserDto> UpdateById(Guid id, UserDto user)
        {
            var updated = await _dbContext.Users.Where(u => u.Id == id)
                .UpdateFromQueryAsync(u => new UserDto {FirstName = user.FirstName, LastName = user.LastName, BirthDate = user.BirthDate});
            if (updated > 0)
            {
                user.Id = id;
                await _dbContext.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<int> RemoveById(Guid id)
        {
            var result = await _dbContext.Users.Where(u => u.Id == id).DeleteFromQueryAsync();
            if (result > 0)
            {
                await _dbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
