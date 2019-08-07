using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UserRegistration.Data.Maps;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Data
{
    public class UserRegistrationContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.Development.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("UserRegistrationDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
