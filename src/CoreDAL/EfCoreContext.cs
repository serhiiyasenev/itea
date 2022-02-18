using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDAL
{
    public class EfCoreContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }

        public EfCoreContext(DbContextOptions options) : base(options)
        {
        }

    }
}
