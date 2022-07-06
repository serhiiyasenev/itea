using CoreDAL.Entities;
using CoreDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDAL.Repositories
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
            var result = await _dbContext.Users.Include(u => u.Car).ToListAsync();
            return result;
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
