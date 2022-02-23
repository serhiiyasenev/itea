using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class UserRepository : IUserRepository
    {
        private readonly EfCoreContext _dbContext;

        public UserRepository(EfCoreContext dbContext)
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
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<UserDto> UpdateById(Guid id, UserDto user)
        {
            user.Id = id;
            _dbContext.Attach(user);
            _dbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }
            return user;
        }

        public async Task<int> RemoveById(Guid id)
        {
            var user = new UserDto { Id = id };
            _dbContext.Attach(user);
            _dbContext.Entry(user).State = EntityState.Deleted;
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return 0;
            }
        }
    }
}
