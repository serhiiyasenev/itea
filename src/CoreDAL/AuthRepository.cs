using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class AuthRepository
    {
        private EfCoreContext _dbContext;

        public AuthRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Login(Credentials credentials)
        {
            var items =  await _dbContext.Users.Where(u => u.Login == credentials.Login && u.Password == credentials.Password).ToListAsync();
            return items.Any();
        }
    }
}
