using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<UserDto> GetById(Guid id)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserDto> UpdateById(Guid id, UserDto user)
        {
            var dbUser = await GetById(id);

            if (dbUser != null)
            {
                user.Id = id;
                var update = _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return update.Entity;
            }

            return null;
        }

        public async Task<Guid?> RemoveById(Guid id)
        {
            var dbUser = await GetById(id);
            // do we need to check null here?
            if (dbUser != null)
            {
                var userEntity = _dbContext.Users.Remove(dbUser);
                await _dbContext.SaveChangesAsync();
                return userEntity.Entity.Id;
            }

            return null;
        }

    }
}
