using Dotnet21.IncorrectContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dotnet21.IncorrectContext
{
    public class IncorrectContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public IncorrectContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(nameof(IncorrectContext)));
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.Id);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(p => p.Profile)
                .HasForeignKey<User>(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}