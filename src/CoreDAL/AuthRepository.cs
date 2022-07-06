using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class AuthRepository : IAuthRepository
    {
        private EfCoreContext _dbContext;

        public AuthRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(bool success, string result)> CreateAuthToken(Credentials credentials)
        {
            var items =  await _dbContext.Users.Where(u => u.Login == credentials.Login && u.Password == credentials.Login).ToListAsync();
            if (items.Any())
            {
                var token = GenerateToken();
                return (true, token);
            }
            return (false, "Invalid credentials");

        }

        private string GenerateToken()
        {
            return "token";
        }
    }
}
