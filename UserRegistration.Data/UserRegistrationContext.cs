using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UserRegistration.Data.Maps;
using UserRegistration.Data.Entities;

namespace UserRegistration.Data
{
    public class UserRegistrationContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.Development.json")
            //    .Build();

            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("UserRegistrationDatabase"));

            optionsBuilder.UseSqlServer(@"Server=tcp:rdev.database.windows.net,1433;Initial Catalog=UserRegistration;
                                            Persist Security Info=False;User ID=ronye.rocha;Password=Spl@Engine#22;
                                            MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;
                                            Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
