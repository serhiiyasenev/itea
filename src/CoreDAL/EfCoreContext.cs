using CoreDAL.Entries;
using Microsoft.EntityFrameworkCore;

namespace CoreDAL
{
    public class EfCoreContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
    }
}
