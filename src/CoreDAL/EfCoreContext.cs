using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace CoreDAL
{
    public class EfCoreContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
        public DbSet<CarDto> Cars { get; set; }
        public DbSet<UsersCarDto> UsersCars { get; set; }


        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDto>().HasKey(user => user.Id);
            modelBuilder.Entity<CarDto>().HasKey(car => car.Id);
            modelBuilder.Entity<UsersCarDto>().HasKey(e => new {e.UserId, e.CarId});
        }

    }
}
