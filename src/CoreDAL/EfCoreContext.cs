using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace CoreDAL
{
    public class EfCoreContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }

        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDto>().HasKey(user => user.Id);
            modelBuilder.Entity<CarDto>().HasKey(user => user.Id);
        }

    }
}
